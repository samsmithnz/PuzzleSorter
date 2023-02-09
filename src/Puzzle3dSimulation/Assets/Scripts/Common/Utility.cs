using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public static class Utility
    {
        public const string TAG_Highlight = "Highlight";
        public const string TAG_Path = "Path";
        public const string TAG_OutOfView = "OutOfView";
        public const string TAG_Player = "PlayerCharacter";
        public const string TAG_Enemy = "EnemyCharacter";
        public const string TAG_DestructibleTerrain = "DestructibleTerrain";
        public const string TAG_TargetingCrosshair = "TargetingCrosshair";

        //public static UnityEngine.Vector3 ConvertToUnity3DV3(System.Numerics.Vector3 vector3)
        //{
        //    return new UnityEngine.Vector3(vector3.X, vector3.Y, vector3.Z);
        //}

        //public static System.Numerics.Vector3 ConvertToNumericV3(UnityEngine.Vector3 vector3)
        //{
        //    return new System.Numerics.Vector3(vector3.x, vector3.y, vector3.z);
        //}

        //public static List<UnityEngine.Vector3> ConvertToUnity3DV3List(List<System.Numerics.Vector3> vector3List)
        //{
        //    List<UnityEngine.Vector3> results = new List<UnityEngine.Vector3>();
        //    foreach (System.Numerics.Vector3 item in vector3List)
        //    {
        //        results.Add(ConvertToUnity3DV3(item));
        //    }
        //    return results;
        //}

        //public static List<KeyValuePair<Vector3, int>> ConvertToUnity3DV3List(List<KeyValuePair<System.Numerics.Vector3, int>> vector3List)
        //{
        //    List<KeyValuePair<Vector3, int>> results = new List<KeyValuePair<Vector3, int>>();
        //    foreach (KeyValuePair<System.Numerics.Vector3, int> item in vector3List)
        //    {
        //        results.Add(new KeyValuePair<Vector3, int>(ConvertToUnity3DV3(item.Key), item.Value));
        //    }
        //    return results;
        //}

        //public static List<System.Numerics.Vector3> ConvertToNumericV3List(List<UnityEngine.Vector3> vector3List)
        //{
        //    List<System.Numerics.Vector3> results = new List<System.Numerics.Vector3>();
        //    foreach (UnityEngine.Vector3 item in vector3List)
        //    {
        //        results.Add(ConvertToNumericV3(item));
        //    }
        //    return results;
        //}

        public static string CreateName(string prefix, Vector2 location)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(prefix);
            sb.Append("_x");
            sb.Append(location.x.ToString());
            sb.Append("_y0");
            sb.Append("_z");
            sb.Append(location.y.ToString());
            return sb.ToString();
        }

        public static Vector3 AdjustYCoordinate(Vector3 location, float adjustment)
        {
            return new Vector3(location.x, location.y + adjustment, location.z);
        }

        public static void AddObjectMaterial(GameObject obj, Material material)
        {
            MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
            if (meshRenderer == null)
            {
                meshRenderer = obj.AddComponent<MeshRenderer>();
            }
            meshRenderer.material = material;
        }

        //public static GameObject FindCharacterGameObject(string name, List<KeyValuePair<string, Character3D>> characterGameObjectList)
        //{
        //    GameObject result = null;
        //    foreach (KeyValuePair<string, Character3D> item in characterGameObjectList)
        //    {
        //        if (item.Key == name)
        //        {
        //            result = item.Value.CharacterGameObject;
        //            break;
        //        }
        //    }
        //    return result;
        //}

        //public static Image FindCharacterPanelImage(string name, List<KeyValuePair<string, Character3D>> characterGameObjectList)
        //{
        //    Image result = null;
        //    foreach (KeyValuePair<string, Character3D> item in characterGameObjectList)
        //    {
        //        if (item.Key == name)
        //        {
        //            GameObject canvas = FindChildObject(item.Value.CharacterGameObject.transform, "CharacterCanvas_" + name);
        //            GameObject characterCover = FindChildObject(canvas.transform, "panCharacterPanel_" + name);
        //            result = characterCover.GetComponent<Image>();
        //            break;
        //        }
        //    }
        //    return result;
        //}
        //public static Text FindCharacterHPTextBox(string name, List<KeyValuePair<string, Character3D>> characterGameObjectList)
        //{
        //    Text result = null;
        //    foreach (KeyValuePair<string, Character3D> item in characterGameObjectList)
        //    {
        //        if (item.Key == name)
        //        {
        //            GameObject canvas = FindChildObject(item.Value.CharacterGameObject.transform, "CharacterCanvas_" + name);
        //            GameObject characterHP = FindChildObject(canvas.transform, "txtCharacterHP_" + name);
        //            result = characterHP.GetComponent<Text>();
        //            break;
        //        }
        //    }
        //    return result;
        //}

        //public static Image FindCharacterCoverImage(string name, List<KeyValuePair<string, Character3D>> characterGameObjectList)
        //{
        //    Image result = null;
        //    foreach (KeyValuePair<string, Character3D> item in characterGameObjectList)
        //    {
        //        if (item.Key == name)
        //        {
        //            GameObject canvas = FindChildObject(item.Value.CharacterGameObject.transform, "CharacterCanvas_" + name);
        //            GameObject characterCover = FindChildObject(canvas.transform, "imgCharacterCover_" + name);
        //            result = characterCover.GetComponent<Image>();
        //            break;
        //        }
        //    }
        //    return result;
        //}

        //public static Image FindCharacterCoverHalfImage(string name, List<KeyValuePair<string, Character3D>> characterGameObjectList)
        //{
        //    Image result = null;
        //    foreach (KeyValuePair<string, Character3D> item in characterGameObjectList)
        //    {
        //        if (item.Key == name)
        //        {
        //            GameObject canvas = FindChildObject(item.Value.CharacterGameObject.transform, "CharacterCanvas_" + name);
        //            GameObject characterCover = FindChildObject(canvas.transform, "imgCharacterCoverHalf_" + name);
        //            result = characterCover.GetComponent<Image>();
        //            break;
        //        }
        //    }
        //    return result;
        //}

        //public static Text FindCharacterActionPointsText(string name, List<KeyValuePair<string, Character3D>> characterGameObjectList)
        //{
        //    Text result = null;
        //    foreach (KeyValuePair<string, Character3D> item in characterGameObjectList)
        //    {
        //        if (item.Key == name)
        //        {
        //            GameObject canvas = FindChildObject(item.Value.CharacterGameObject.transform, "CharacterCanvas_" + name);
        //            GameObject characterActionPoints = FindChildObject(canvas.transform, "txtCharacterActionPoints_" + name);
        //            result = characterActionPoints.GetComponent<Text>();
        //            break;
        //        }
        //    }
        //    return result;
        //}

        //public static Character3D FindCharacter3dObject(string name, List<KeyValuePair<string, Character3D>> characterGameObjectList)
        //{
        //    Character3D result = null;
        //    foreach (KeyValuePair<string, Character3D> item in characterGameObjectList)
        //    {
        //        if (item.Key == name)
        //        {

        //            result = item.Value;
        //            break;
        //        }
        //    }
        //    return result;
        //}

        //public static GameObject FindCharacterGreenRoomGameObject(string name, List<KeyValuePair<string, GameObject>> characterGreenRoomGameObjectList)
        //{
        //    GameObject result = null;
        //    foreach (KeyValuePair<string, GameObject> item in characterGreenRoomGameObjectList)
        //    {
        //        if (item.Key == name)
        //        {
        //            result = item.Value;
        //            break;
        //        }
        //    }
        //    return result;
        //}

        public static GameObject FindChildObject(Transform transform, string name)
        {
            GameObject result = null;
            for (int i = 0; i <= transform.childCount - 1; i++)
            {
                if (transform.GetChild(i).name == name)
                {
                    result = transform.GetChild(i).gameObject;
                }
            }
            return result;
        }

        /// <summary>
        /// Used to calculate the middle between two targets to center the camera over them
        /// </summary>
        /// <param name="sourceObject"></param>
        /// <param name="targetObject"></param>
        /// <param name="divisor">The number of segments to make of the distance between source and target</param>
        /// <param name="position">Which segment to take. 1 = the first</param>
        /// <returns></returns>
        public static Vector3 GetMidPointBetweenTwoObjects(Vector3 sourceObject, Vector3 targetObject, int divisor = 2, int position = 1)
        {
            return sourceObject + (targetObject - sourceObject) / (float)divisor * (float)position;
        }

        public static void LogWithTime(string message)
        {
            Debug.Log(DateTime.Now.ToString("hh:mm:ss.fff") + " - " + message);
        }

        public static Material CreateMaterial(Material baseMaterial, Color color)
        {
            Material newMaterial = new Material(baseMaterial.shader); ;
            newMaterial.CopyPropertiesFromMaterial(baseMaterial);
            newMaterial.color = color;
            return baseMaterial;
        }

        public static IEnumerator WaitForNSeconds(int n)
        {
            yield return new WaitForSeconds(n);
        }

    }
}