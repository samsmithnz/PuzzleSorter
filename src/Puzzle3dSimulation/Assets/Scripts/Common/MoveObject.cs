using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public class MoveObject : MonoBehaviour
    {
        /// <summary>
        /// Move an object, rotating it to it's final destination
        /// </summary>
        /// <param name="transformToMove"></param>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <param name="startRot"></param>
        /// <param name="endRot"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public IEnumerator MoveObjectWithRotation(Transform transformToMove, Vector3 startPos, Vector3 endPos, Quaternion startRot, Quaternion endRot, float time)
        {
            float i = 0;
            float rate = 1 / time;
            while (i < 1)
            {
                if (transformToMove == null)
                {
                    break;
                }
                i += Time.deltaTime * rate;
                //transformToMove.position = Vector3.Lerp(startPos, endPos, i);
                //transformToMove.rotation = Quaternion.Slerp(startRot, endRot, i);
                transformToMove.SetPositionAndRotation(Vector3.Lerp(startPos, endPos, i), Quaternion.Slerp(startRot, endRot, i));
                yield return null;
            }
            yield return null;
        }

        public IEnumerator MoveObjectWithLocalRotation(Transform transformToMove, Vector3 startPos, Vector3 endPos, Quaternion startRot, Quaternion endRot, float time)
        {
            float i = 0;
            float rate = 1 / time;
            while (i < 1)
            {
                if (transformToMove == null)
                {
                    break;
                }
                i += Time.deltaTime * rate;
                transformToMove.position = Vector3.Lerp(startPos, endPos, i);
                transformToMove.localRotation = Quaternion.Slerp(startRot, endRot, i);
                yield return null;
            }
            yield return null;
        }

        /// <summary>
        /// Move an object locally, (against it's parent), rotating it to it's final destination
        /// </summary>
        /// <param name="transformToMove"></param>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <param name="startRot"></param>
        /// <param name="endRot"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public IEnumerator MoveObjectLocallyWithRotation(Transform transformToMove, Vector3 startPos, Vector3 endPos, Quaternion startRot, Quaternion endRot, float time)
        {
            float i = 0;
            float rate = 1 / time;
            while (i < 1)
            {
                if (transformToMove == null)
                {
                    break;
                }
                i += Time.deltaTime * rate;
                transformToMove.localPosition = Vector3.Lerp(startPos, endPos, i);
                transformToMove.rotation = Quaternion.Slerp(startRot, endRot, i);
                yield return null;
            }
            yield return null;
        }

        public IEnumerator MoveObjectLocallyWithLocalRotation(Transform transformToMove, Vector3 startPos, Vector3 endPos, Quaternion startRot, Quaternion endRot, float time)
        {
            float i = 0;
            float rate = 1 / time;
            while (i < 1)
            {
                if (transformToMove == null)
                {
                    break;
                }
                i += Time.deltaTime * rate;
                transformToMove.localPosition = Vector3.Lerp(startPos, endPos, i);
                transformToMove.localRotation = Quaternion.Slerp(startRot, endRot, i);
                yield return null;
            }
            yield return null;
        }

        /// <summary>
        /// Move an object with no rotation to it's destination. This means the object doesn't rotate at all
        /// </summary>
        /// <param name="transformToMove"></param>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public IEnumerator MoveObjectWithNoRotation(Transform transformToMove, Vector3 startPos, Vector3 endPos, float time)
        {
            float i = 0;
            float rate = 1f / time;
            while (i < 1f)
            {
                if (transformToMove == null)
                {
                    Debug.LogError("Transform to move not found");
                    break;
                }
                i += Time.deltaTime * rate;
                transformToMove.position = Vector3.Lerp(startPos, endPos, i);
                yield return null;
            }
        }

    }
}