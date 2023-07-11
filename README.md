# PuzzleSorter
[![CI/CD](https://github.com/samsmithnz/PuzzleSorter/actions/workflows/workflow.yml/badge.svg)](https://github.com/samsmithnz/PuzzleSorter/actions/workflows/workflow.yml)

Question: With software, can we sort jigsaw puzzle pieces and/or Lego? 

Some early prototypes:

- Unity3d: ![image](https://user-images.githubusercontent.com/8389039/219825141-2eee9e7d-cbc8-457d-b0dc-b442656173ce.png)
- WinForms: ![image](https://user-images.githubusercontent.com/8389039/219825182-33c8538a-d21e-489f-9faa-053bd5cd8718.png)

# How it works
Based on the number of robots (agents that complete work), a timeline is created with the number of turns required. 
- Each turn enables each robot to run one action, either a move from adjacent tile to another tile, pickup a piece, or a dropoff a piece.

There are jobs:

```mermaid
flowchart TD
    id0[Start] --> id1[Looking for new job]
    id1[Looking for new job] --> idLook[Are there jobs]
    idLook[Are there jobs?] --yes--> id2[Moving to pick up location]
    id2[Moving to pick up location] --> id3[Picking up package]
    id3[Picking up package] --> id4[Moving to delivery location]
    id4[Moving to delivery location] --> id5[delivering package]
    id5[Delivering package] --> id1[Looking for new job]
    idLook[Are there jobs?] --no--> idEnd[End] 
```
