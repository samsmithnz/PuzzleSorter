# Physical Robot Build Plan: PuzzleSorter

A plan to build real hardware that executes the algorithm implemented in `src/PuzzleSolver`
(`Board`, `Robot`, `Piece`, `PathFinding`, `SortedDropZones`, `ImageColorGroups`).

---

## 1. How the software maps to hardware

| Software concept | Hardware equivalent |
| --- | --- |
| `MapCore` / `MapTile` grid | Physical sorting table divided into a coordinate grid |
| `Robot.Location` (`Vector2`) | Gantry XY position (or mobile robot odometry) |
| `Robot.PickupLocation` | Infeed / piece presentation area |
| `Piece.Image` + `ImageStats` | Overhead camera capture + color analysis |
| `SortedDropZones` | Physical bin at a fixed grid coordinate |
| `PathFinding` (A*) | Motion planner producing waypoint list |
| `RobotStatusEnum` states | Firmware state machine (idle / moving / picking / analyzing / delivering) |
| `TimeLine` / `Turn` | Real-time scheduler loop, one command block per robot per cycle |

---

## 2. Architecture options

Four candidate architectures are described below. See **section 11 for the final
recommendation**, which depends on whether the goal is sorting throughput or faithfully
running the multi-agent algorithm on real hardware.

The algorithm's "multiple agents" model is really about parallel throughput. Multi-robot
adds collision avoidance, charging, and localization problems that are far harder in the
physical world than in the simulator.

### Option A — Cartesian gantry sorter (recommended v1)
A CoreXY/Cartesian gantry over a flat table with a vacuum pick head. Bins arranged around
the perimeter. Overhead camera + backlit inspection window.

- Pros: rigid, repeatable coordinates, cheap, maps 1:1 to the `Vector2` grid, no localization.
- Cons: single pick head limits throughput; work area limited by frame size.

### Option B — Conveyor + delta/SCARA cells (v2 scale-up)
Infeed hopper → vibratory singulator → conveyor past a line-scan camera → 2–4 delta arm
cells, each owning a subset of bins. This is the true "multiple specialized robots" model
and directly matches the multi-agent scheduler in `TimeLine`.

- Pros: high throughput, genuinely parallel agents, matches the future-state flowchart.
- Cons: much more expensive, needs conveyor tracking and inter-cell handoff logic.

### Option C — Naive fleet of small mobile robots
Small differential-drive bots on a marked floor grid, each carrying its own camera and
pick-and-place mechanism. Closest to a literal reading of the simulation.

- Not recommended: localization drift, battery management, and collision handling dominate
  the effort, and onboarding a camera and gripper makes each robot large and short-lived.
- **Superseded by Option D**, which keeps the fleet idea but strips the expensive subsystems
  off the robots.

### Option D — Swarm shuttle with fixed stations (recommended for multi-agent fidelity)
Many very small "dumb shuttle" robots that only transport pieces, combined with fixed
stations that do all sensing and actuation: an infeed singulator, a passive flip station,
a scan lightbox, and the bins. Detailed in **section 10**.

- Pros: robots shrink to roughly 45 × 40 × 25 mm; genuinely exercises `PathFinding` and
  multi-agent collision avoidance; no onboard camera or gripper.
- Cons: lowest throughput per dollar; needs a position mat and multi-robot coordination.

---

## 3. Subsystem breakdown (Option A)

1. **Frame & motion** — 500×500 mm working area, CoreXY belts, plus a Z axis for the pick head.
2. **Singulation / infeed** — vibrating tray or sloped hopper that presents one piece at a time
   to the pickup location. This is the hardest mechanical problem; budget the most iteration here.
3. **Vision** — fixed overhead camera for locating pieces on the infeed; a second downward camera
   (or a lightbox station the head visits) for the per-piece `ImageStats` analysis.
4. **End effector** — vacuum cup on a compliant spring mount; venturi or diaphragm pump with a
   solenoid valve for fast release. Vacuum sensor confirms a successful pick (grip feedback).
5. **Bins / drop zones** — 3D-printed chutes at fixed grid coordinates, one per `SortedDropZone`.
6. **Control** — a Raspberry Pi 5 running the .NET code (vision, planning, scheduling) issuing
   G-code / serial commands to a motion controller board that handles steppers and endstops.

---

## 4. Parts to buy

### Motion
- 2020 aluminium extrusion, ~10 m, plus corner brackets and T-nuts
- 3× NEMA 17 stepper motors (X, Y, Z), 1.5 A
- GT2 belt (~5 m) + 20T pulleys + idler pulleys
- Linear rails: 2× MGN12H 500 mm (X/Y), 1× MGN9 150 mm (Z)
- Lead screw + anti-backlash nut for Z (T8, 150 mm)
- 4–6× mechanical or optical endstop switches

### Control & power
- Motion controller: BigTreeTech Octopus / SKR (or Duet 3 Mini if you want higher quality)
- 4× TMC2209 stepper drivers (quiet, sensorless homing)
- 24 V 350 W PSU + 5 V buck converter
- Raspberry Pi 5 (8 GB) + NVMe or fast SD, plus PSU
- Emergency stop button, fuse, IEC inlet, wiring loom, drag chain

### Vision & lighting
- Overhead camera: Raspberry Pi HQ camera + 6 mm or 8 mm C-mount lens
- Inspection camera: second Pi camera or a USB global-shutter camera
- Diffuse LED ring light + a white LED light panel for the inspection lightbox
- Camera calibration target (checkerboard) — printable

### Pick head
- Vacuum pump (12 V diaphragm) or venturi ejector if you already have compressed air
- 12 V solenoid valve (3/2 way), vacuum reservoir, silicone tubing
- Vacuum nozzles/cups, assorted 4–10 mm silicone cups
- Vacuum pressure sensor (e.g. XGZP6847 or similar analog sensor)
- MOSFET relay board to switch pump and valve

### Misc
- M3/M5 fastener assortment, heat-set inserts
- Anti-static / matte black table surface (improves piece segmentation)
- Optional: small vibratory bowl or a 12 V vibration motor for the infeed tray

---

## 5. Parts to manufacture (3D print / laser cut / machine)

- CoreXY corner idler blocks and motor mounts
- Z-axis carriage and vacuum head mount with compliance spring pocket
- Vacuum cup quick-change adapter (so cup size can change per piece type)
- Camera mounts: overhead boom mount and inspection-station mount
- Lightbox enclosure (laser-cut acrylic + diffuser sheet)
- Sorting bin chutes, one per drop zone, keyed to grid coordinates
- Infeed tray with sloped ramp and vibration motor pocket
- Cable drag-chain end brackets
- Calibration fiducial plate: a flat plate with printed ArUco markers at known grid coordinates,
  used to map camera pixels to the `MapCore` grid
- Electronics enclosure with fan mounts

---

## 6. Software work required in this repo

1. **Hardware abstraction layer** — new project `PuzzleSolver.Hardware` with interfaces
   `IMotionController`, `IGripper`, `ICamera`, so the simulator and real machine share
   the existing planner.
2. **Coordinate transform** — map `Vector2` grid tiles to millimetre machine coordinates,
   calibrated from the fiducial plate.
3. **Real vision pipeline** — replace pre-cropped images with live capture, segmentation,
   and centroid/rotation extraction, feeding the existing `ImageStats` / `ImageColorGroups`.
4. **Executor** — translate `Robot.RobotPath` and `RobotStatusEnum` transitions into
   motion commands, replacing the turn-based `TimeLine` with a real-time loop.
5. **Failure handling** — vacuum sensor says no piece: retry, then flag as jam. The
   simulator currently assumes every pick succeeds.
6. **Teleop / jog UI** — extend `PuzzleSolver.App` with manual jog, homing, and calibration.

---

## 7. Suggested build order

1. Frame + XY motion, homing, jog from the Pi.
2. Add Z axis and vacuum head; hand-typed pick/place coordinates.
3. Add overhead camera + fiducial calibration; pick a piece the camera located.
4. Add inspection station and wire in the existing color-analysis code.
5. Add bins and drive the whole loop from the existing algorithm.
6. Add infeed singulation for unattended operation.
7. Only then evaluate Option B for multi-agent throughput.

---

## 8. Risks

- **Singulation** is the top risk; overlapping pieces defeat the vision step.
- **Lighting consistency** — the color grouping code is sensitive to white balance; lock
  camera exposure and white balance manually.
- **Piece flip** — the machine cannot tell a face-down piece; add a brightness/edge check
  and route face-down pieces to a reject bin.
- **Vacuum on textured pieces** — cardboard puzzle backs seal poorly; have a fallback
  small-gripper head design.

---

## 9. Option A dimensions and envelope

Derived from the 500 × 500 mm working area in section 3.

### Footprint

| Dimension | Size | Why |
| --- | --- | --- |
| Working area (XY) | 500 × 500 mm | The addressable grid where pieces and bins live |
| Frame footprint | ~700 × 700 mm | Working area plus ~100 mm per side for rails, idlers, motor mounts, endstops |
| Bench space needed | ~900 × 800 mm | Frame plus electronics enclosure and the infeed hopper overhanging one side |

### Height

| Element | Height |
| --- | --- |
| Base to gantry rails | ~200 mm (clearance for bins and Z stroke) |
| Z axis travel | 150 mm (matches the MGN9 rail in section 4) |
| Camera boom above bed | ~600–700 mm |
| **Total height** | **~800–900 mm** |

The camera boom drives total height. With a Pi HQ camera (~7.9 mm sensor diagonal), a 6 mm
lens needs roughly 600 mm standoff to cover the full 500 mm bed in one frame. An 8 mm lens
pushes that to ~800 mm; a 4 mm lens drops it to ~400 mm but adds barrel distortion the
fiducial calibration must correct.

### Practical framing

Comparable to a large desktop 3D printer (Prusa XL / Voron 2.4 350), but wider and flatter
since the work spreads horizontally rather than vertically. Fits on a standard 1500 mm desk.
Roughly 15–20 kg with the extrusion frame.

### Scaling levers

- **Grid resolution vs. bin count** is the real constraint, not raw area. With 40 mm bin
  chutes around the perimeter you get ~24 drop zones on a 500 mm bed. If `SortedDropZones`
  needs more color groups than that, either grow the bed or sort in two stages (coarse
  sort, then re-run each bin).
- **Growing to 750 × 750 mm** costs rigidity: step up to MGN15 rails, consider a second Y
  motor, and expect belt stretch to hurt positional repeatability.
- **Option B** is a different shape entirely — roughly 2–3 m long × 600 mm wide, making it a
  floor-standing machine rather than a benchtop one.

---

## 10. Option D — Swarm shuttle architecture

### 10.1 Only one role should be mobile

Decomposing into specialized robots is what makes them small, but the biggest size lever is
deciding which robots need to move at all.

| Role | Mobile? | Rationale |
| --- | --- | --- |
| **Mover** — transports pieces | **Yes**, many of them | The only job that inherently requires traversing the table |
| **Flipper** — turns pieces over | **No**, fixed station | A fixed transformation; on a robot it is dead weight ~60% of the time |
| **Scanner** — images the piece, picks its destination | **No**, fixed station | A camera plus controlled lighting is the most size-hostile payload there is |

The scanner is the critical call. `ImageStats` / `ImageColorGroups` need consistent white
balance, exposure, and focal distance, which means a diffuse lightbox at a fixed standoff.
Onboarding that adds a camera, lens, light panel, shroud, and the compute to run it — the
robot triples in size and battery life collapses.

Move all sensing and actuation into fixed stations and the mobile robot degenerates into a
**dumb shuttle: two motors, one tilt tray, a radio.** That is the smallest thing that can work.

### 10.2 Minimum mover size budget

The hard floor is the payload: a jigsaw piece is ~30 mm across, so the tray must be ~35 mm.
You cannot go smaller than the thing you are carrying. (Lego relaxes this — a 2×4 brick is
32 × 16 mm and small parts are far less, so a Lego-only sorter could shrink to ~30 mm.)

| Component | Part | Footprint | Height |
| --- | --- | --- | --- |
| MCU + radio | Seeed XIAO ESP32-C3 | 21 × 17.5 mm | 3.5 mm |
| Drive | 2× 6 mm coreless gearmotor | 6 × 15 mm ea. | 6 mm |
| Wheels | 20 mm silicone + rear ball caster | — | 20 mm |
| Tilt tray | 3.7 g micro servo or shape-memory wire actuator | 20 × 8 mm | 8 mm |
| Power | 1S 150 mAh LiPo **or** 5 F supercapacitor | 20 × 15 mm | 5 mm |
| Localization | Downward optical sensor | 10 × 10 mm | 4 mm |
| **Total** | | **~45 × 40 mm** | **~25 mm** |

About the size of a matchbox. Existing proof points at this scale: Sony **toio** robots are
32 mm cubes and Stanford **Zooids** are 26 mm in diameter — though neither carries a payload.

### 10.3 Localization — the real size driver

This is where the design succeeds or fails.

- **Overhead camera + ArUco tag per robot** — nothing onboard but a printed sticker, but the
  tag must be ~15 mm to resolve from 700 mm, and the control loop inherits camera latency.
  Accuracy ~2–3 mm.
- **Printed position mat + downward optical sensor** (the toio approach) — a finely printed
  dot pattern encodes absolute XY at every point. Sub-millimetre absolute position, no drift,
  no camera latency, genuinely small. **Recommended.** The mat *is* `MapCore`: a mat
  coordinate converts directly to a `MapTile` index.
- **Dead reckoning from encoders** — smallest and cheapest, but drift makes it unusable within
  a minute or two unless robots re-zero at every station.

### 10.4 Power — skip the battery

A 150 mAh cell at this size gives 10–15 minutes of driving, after which a dozen robots need
hand-charging. Instead use a **supercapacitor with contact charging pads at every station**.
The robot tops up for 2–3 seconds each time it docks at the scanner or a bin, which it does
constantly anyway. Indefinite runtime, no charge management, thinner and lighter than a LiPo.

### 10.5 Station designs

- **Infeed station** — fixed singulator drops exactly one piece onto a waiting shuttle's tray.
- **Flip station** — fully passive: a short chute with a 180° twist, or a spring-loaded flap
  the robot nudges. No motor, no controller.
- **Scan station** — fixed lightbox the robot drives under; the piece is imaged in place on
  the tray, so there is no transfer step.
- **Bins** — the robot drives to the drop zone and tilts its tray. Gravity does the unloading.

The shuttle therefore **never picks anything up**. Deleting the pick-and-place mechanism is
what takes the design from "small robot" to "very small robot".

### 10.6 Parts to buy (per shuttle, plus shared infrastructure)

Per shuttle:
- Seeed XIAO ESP32-C3 (or ESP32-C3 SuperMini)
- 2× 6 mm coreless gearmotor with 20 mm silicone wheels
- 1× micro ball caster
- 1× 3.7 g micro servo (tray tilt)
- Dual H-bridge motor driver (DRV8833 or similar)
- 5 F 2.7 V supercapacitor + charge-limiting circuit, or 1S 150 mAh LiPo
- Downward optical position sensor (position-mat reader)
- Spring contact pins for station charging

Shared infrastructure:
- Printed position mat sized to the table
- Fixed scan lightbox: Pi HQ camera + lens + diffuse LED panel
- Raspberry Pi 5 running the .NET fleet controller
- Wi-Fi access point or ESP-NOW coordinator radio
- Bench PSU for the station charging rails
- Vibratory singulator for the infeed station

### 10.7 Parts to manufacture

- Shuttle chassis (two-part 3D print: motor pods and tray deck)
- Tilt tray with 35 mm piece pocket and servo horn slot
- Charging contact bracket
- Passive flip chute with the 180° twist
- Scan lightbox with drive-under tunnel and diffuser
- Bin chutes with drive-up ramps, one per `SortedDropZone`
- Infeed singulator tray and drop gate
- Station charging rail contacts and mounts

### 10.8 Software work specific to Option D

This design exercises considerably more of the existing algorithm than the gantry does.

1. **Collision avoidance** — `PathFinding` becomes load-bearing. With a dozen robots on a
   shared grid you need reservation tables or cooperative A* over `MapCore`; single-robot
   A* will deadlock.
2. **New states** in `RobotStatusEnum`: `MovingToScanner`, `Scanning`, `MovingToFlipper`,
   `Flipping`.
3. **`Piece.IsFaceDown`** — routing to the flip station becomes a real decision the scanner
   makes, rather than a reject condition.
4. **Fleet transport** — an ESP-NOW / MQTT command channel replacing direct motion calls.
5. **`TimeLine` / `Turn` largely survives** — discrete grid steps map unusually well onto a
   mat-localized shuttle, so more of the existing turn-based model is reusable than expected.

### 10.9 Honest tradeoff

Throughput per dollar is worse than the gantry. Each shuttle carries **one** piece and spends
most of its time driving, whereas a gantry head completes a pick-and-place every ~2 seconds.
Matching one gantry would take roughly 8–12 shuttles, plus the mat and the stations. What you
buy is a far more interesting distributed-systems problem and a faithful implementation of the
multi-agent simulation — not raw sorting speed.

---

## 11. Final recommendation

**Build Option A (the gantry) if the goal is to sort the puzzle. Build Option D (the swarm
shuttle) if the goal is to run the multi-agent algorithm on real hardware.**

These are genuinely different projects, and the repo's README supports both readings: the
current implementation is a working sorter, while the future-state flowchart describes a
fleet of independent agents.

Suggested path:

1. **Start with Option A.** It is the cheapest, most rigid, and least risky build, and it
   validates the parts of the system that are common to every option — the vision pipeline,
   the color grouping, the grid-to-millimetre calibration, and the drop-zone mapping. None of
   that work is wasted if you later build Option D.
2. **Extract the hardware abstraction layer while building Option A** (section 6, item 1).
   `IMotionController` / `IGripper` / `ICamera` are what make the second machine cheap to
   attempt, because the planner and vision code carry over untouched.
3. **Then build Option D as v2** if the multi-agent behaviour is the interesting part.
   Prototype with two or three shuttles before committing to a dozen; collision avoidance and
   the position mat are the two things most likely to force a redesign.
4. **Treat Option B as a separate industrial-scale project.** It only pays off if throughput
   is the actual objective, and it is a floor-standing machine rather than a benchtop one.

Option C should be considered closed — Option D supersedes it in every respect.
