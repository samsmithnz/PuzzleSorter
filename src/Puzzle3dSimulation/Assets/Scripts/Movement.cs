using Assets.Scripts.Common;
using PuzzleSolver.Map;
using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public IEnumerator MovePiece()
    {
        yield return null;
    }

    public IEnumerator MoveRobot(GameObject robotObject, System.Numerics.Vector2 startLocation, PathFindingResult path)
    {
        if (path!= null && path.Path.Count > 0)
        {
            MoveObject moveObjectScript = robotObject.GetComponent<MoveObject>();
            if (moveObjectScript == null)
            {
                moveObjectScript = robotObject.AddComponent<MoveObject>();
            }
            Debug.LogWarning("Position 0: (" + startLocation.X.ToString() + "," + startLocation.Y.ToString() + ")");

            float robotY = 0.5f;
            Vector3 start = Utility.ConvertToUnity3DV3(startLocation, robotY);
            Vector3 end = Utility.ConvertToUnity3DV3(path.Path[1], robotY);
            for (int i = 0; i < path.Path.Count - 1; i++)
            {
                if (i > 0 && i < path.Path.Count - 1)
                {
                    start = Utility.ConvertToUnity3DV3(path.Path[i], robotY);
                    end = Utility.ConvertToUnity3DV3(path.Path[i + 1], robotY);
                    Debug.LogWarning("Position " + i + ": (" + end.x.ToString() + "," + end.z.ToString() + ")");
                }
                //Debug.LogWarning("Moving from " + start.ToString() + " to " + end.ToString());
                yield return StartCoroutine(moveObjectScript.MoveObjectWithNoRotation(robotObject.transform,
                          start,
                          end,
                          1f));

            }
        }
        yield return null;
    }

    //public IEnumerator MoveRobot(System.Numerics.Vector3 source, 
    //    System.Numerics.Vector3 destination, 
    //    MainLoop mainLoopScript, 
    //    Team opponentTeam)
    //{
    //    //Setup the movement
    //    Character character = mainLoopScript.CurrentCharacter.CharacterLogic;
    //    Team characterTeam = mainLoopScript.CurrentCharacter.CharacterTeam;
    //    GameObject characterGameObject = mainLoopScript.CurrentCharacter.CharacterGameObject;
    //    MoveObject moveObjectScript = gameObject.GetComponent<MoveObject>();
    //    if (moveObjectScript == null)
    //    {
    //        moveObjectScript = gameObject.AddComponent<MoveObject>();
    //    }

    //    //Get the movement logic
    //    List<MovementAction> movementActions = mainLoopScript.Mission.MoveCharacter(character, characterTeam, opponentTeam, destination);

    //    //Center the camera over the character (Don't put a start coroutine here)
    //    mainLoopScript.MoveCameraOverPlayer(Utility.ConvertToUnity3DV3(source));
    //    //Move both the camera and the character
    //    mainLoopScript.LockCameraToCurrentPlayer = true;
    //    //Perform the movement
    //    Utility.LogWithTime("Moving from " + source.ToString() + " to " + destination.ToString());
    //    foreach (MovementAction item in movementActions)
    //    {
    //        Utility.LogWithTime(item.Log[0]);
    //        Vector3 adjustedStartLocation = Utility.ConvertToUnity3DV3(item.StartLocation);
    //        adjustedStartLocation.y = 1f;
    //        Vector3 adjustedEndLocation = Utility.ConvertToUnity3DV3(item.EndLocation);
    //        adjustedEndLocation.y = 1f;
    //        yield return StartCoroutine(moveObjectScript.MoveObjectWithNoRotation(characterGameObject.transform,
    //              adjustedStartLocation,
    //              adjustedEndLocation,
    //              0.25f));
    //        mainLoopScript.CurrentCharacter.CharacterLogic.SetLocationAndRange(mainLoopScript.Mission.Map, item.EndLocation, mainLoopScript.CurrentCharacter.CharacterLogic.FOVRange, opponentTeam.Characters);
    //        mainLoopScript.UpdateFOV();

    //        //if this move results in an overwatch encounter
    //        if (item.OverwatchEncounterResults != null && item.OverwatchEncounterResults.Count > 0)
    //        {
    //            Utility.LogWithTime("Overwatch results for " + item.EndLocation.ToString() + " " + item.OverwatchEncounterResults.Count);
    //            foreach (EncounterResult overwatchEncounter in item.OverwatchEncounterResults)
    //            {
    //                //Log the event
    //                Utility.LogWithTime(overwatchEncounter.LogString);

    //                //zoom behind character
    //                Character3D sourceCharacter = Utility.FindCharacter3dObject(overwatchEncounter.SourceCharacter.Name, mainLoopScript.CharacterGameObjectList);
    //                Character3D targetCharacter = Utility.FindCharacter3dObject(overwatchEncounter.TargetCharacter.Name, mainLoopScript.CharacterGameObjectList);
    //                mainLoopScript.MoveCameraBehindPlayerToAim(sourceCharacter, targetCharacter);

    //                //take overwatch shot
    //                yield return StartCoroutine(mainLoopScript.ShootAtTarget(sourceCharacter, targetCharacter));
    //            }

    //            //zoom out and over character
    //            mainLoopScript.MoveCameraBackOverPlayer();
    //        }
    //    }
    //    mainLoopScript.LockCameraToCurrentPlayer = false;

    //    mainLoopScript.UpdateTargetCharacterList();
    //    if (character.ActionPointsCurrent <= 0 || character.HitpointsCurrent <= 0)
    //    {
    //        //Check if turn is over for current team
    //        mainLoopScript.CheckCharacterTurn();
    //    }
    //}
}
