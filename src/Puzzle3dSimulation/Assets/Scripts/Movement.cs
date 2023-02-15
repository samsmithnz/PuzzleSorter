using Assets.Scripts.Common;
using PuzzleSolver.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public IEnumerator MovePiece(GameObject pieceObject, List<Vector3> path, Transform robotTransform)
    {
        const float time = 0.5f;
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
                        time));
                }
            }
            if (robotTransform != null)
            {
                pieceObject.transform.parent = robotTransform;
            }
            else
            {
                pieceObject.transform.parent = null;
            }
        }
        yield return null;
    }

    public IEnumerator MoveRobot(GameObject robotObject, System.Numerics.Vector2 startLocation, PathFindingResult path)
    {
        const float time = 0.5f;
        if (path != null && path.Path.Count > 0)
        {
            MoveObject moveObjectScript = robotObject.GetComponent<MoveObject>();
            if (moveObjectScript == null)
            {
                moveObjectScript = robotObject.AddComponent<MoveObject>();
            }
            //Debug.LogWarning("Walking from: (" + startLocation.X.ToString() + "," + startLocation.Y.ToString() + ") for " + path.Path.Count + " tiles");

            float robotY = 0.5f;
            Vector3 start = Utility.ConvertToUnity3DV3(startLocation, robotY);
            Vector3 end = Utility.ConvertToUnity3DV3(path.Path[0], robotY);
            yield return StartCoroutine(moveObjectScript.MoveObjectWithNoRotation(robotObject.transform,
                start,
                end,
                time));

            for (int i = 0; i < path.Path.Count; i++)
            {
                if (i < path.Path.Count - 1)
                {
                    start = Utility.ConvertToUnity3DV3(path.Path[i], robotY);
                    end = Utility.ConvertToUnity3DV3(path.Path[i + 1], robotY);
                    // Debug.LogWarning("Position " + i + ": (" + end.x.ToString() + "," + end.z.ToString() + ")");
                    //Debug.LogWarning("Moving from " + start.ToString() + " to " + end.ToString());
                    yield return StartCoroutine(moveObjectScript.MoveObjectWithNoRotation(robotObject.transform,
                        start,
                        end,
                        time));
                }
            }
        }
        yield return null;
    }

}
