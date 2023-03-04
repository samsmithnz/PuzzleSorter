using Assets.Scripts.Common;
using PuzzleSolver.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private const float _movementTime = 0.25f;

    public IEnumerator MovePiece(GameObject pieceObject, List<Vector3> path, Transform robotTransform)
    {
        if (path != null && path.Count > 0)
        {
            MoveObject moveObjectScript = pieceObject.GetComponent<MoveObject>();
            if (moveObjectScript == null)
            {
                moveObjectScript = pieceObject.AddComponent<MoveObject>();
            }
            for (int i = 0; i < path.Count; i++)
            {
                if (i < path.Count - 1)
                {
                    Vector3 start = path[i];
                    Vector3 end = path[i + 1];
                    yield return StartCoroutine(moveObjectScript.MoveObjectWithNoRotation(pieceObject.transform,
                    start,
                    end,
                    _movementTime / 4f));
                    //yield return new WaitForSeconds(_movementTime);
                }
            }
            //Attach/detach to the robot parent
            if (robotTransform != null)
            {
                pieceObject.transform.parent = robotTransform;
            }
            else
            {
                Debug.LogWarning("Detaching piece " + pieceObject.name);
                pieceObject.transform.parent = null;
            }
        }
        yield return null;
    }

    public IEnumerator MoveRobot(GameObject robotObject, System.Numerics.Vector2 startLocation, PathFindingResult path)
    {
        if (path != null && path.Path.Count > 0)
        {
            MoveObject moveObjectScript = robotObject.GetComponent<MoveObject>();
            if (moveObjectScript == null)
            {
                moveObjectScript = robotObject.AddComponent<MoveObject>();
            }
            //Debug.Log("Walking from: (" + startLocation.X.ToString() + "," + startLocation.Y.ToString() + ") for " + path.Path.Count + " tiles");

            float robotY = 0.5f;
            Vector3 start = Utility.ConvertToUnity3DV3(startLocation, robotY);
            Vector3 end = Utility.ConvertToUnity3DV3(path.Path[0], robotY);
            yield return StartCoroutine(moveObjectScript.MoveObjectWithNoRotation(robotObject.transform,
            start,
            end,
            _movementTime));
            //yield return new WaitForSeconds(_movementTime);

            for (int i = 0; i < path.Path.Count; i++)
            {
                if (i < path.Path.Count - 1)
                {
                    start = Utility.ConvertToUnity3DV3(path.Path[i], robotY);
                    end = Utility.ConvertToUnity3DV3(path.Path[i + 1], robotY);
                    // Debug.Log("Position " + i + ": (" + end.x.ToString() + "," + end.z.ToString() + ")");
                    // Debug.Log("Moving from " + start.ToString() + " to " + end.ToString());
                    yield return StartCoroutine(moveObjectScript.MoveObjectWithNoRotation(robotObject.transform,
                    start,
                    end,
                    _movementTime));
                    //yield return new WaitForSeconds(_movementTime);
                }
            }
        }
        yield return null;
    }

    public IEnumerator MoveRobot2(GameObject robotObject, System.Numerics.Vector2 startLocation, System.Numerics.Vector2 endLocation)
    {
        if (robotObject != null)
        {
            MoveObject moveObjectScript = robotObject.GetComponent<MoveObject>();
            if (moveObjectScript == null)
            {
                moveObjectScript = robotObject.AddComponent<MoveObject>();
            }
            //Debug.Log("Walking from: (" + startLocation.X.ToString() + "," + startLocation.Y.ToString() + ") for " + path.Path.Count + " tiles");

            float robotY = 0.5f;
            Vector3 start = Utility.ConvertToUnity3DV3(startLocation, robotY);
            Vector3 end = Utility.ConvertToUnity3DV3(endLocation, robotY);
            yield return StartCoroutine(moveObjectScript.MoveObjectWithNoRotation(robotObject.transform,
                start,
                end,
                _movementTime));
            //yield return new WaitForSeconds(time);
        }
        yield return null;
    }

}
