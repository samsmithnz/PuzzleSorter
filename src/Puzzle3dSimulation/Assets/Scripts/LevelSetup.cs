using Assets.Scripts.Common;
using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    public static void DeleteObjectsByTag(string tag)
    {
        //Delete all existing highlighted objects
        GameObject[] highlightedObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject item in highlightedObjects)
        {
            Destroy(item);
        }
    }

    public static void SetupMap(GameObject parentGameObject, string[,] map, bool showLinesOnFloor, bool showCoordOnFloor)
    {
        Font arialFont = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        int width = map.GetLength(0);
        int length = map.GetLength(1);

        //setup the map object and create the map
        GameObject parentFloor = new GameObject
        {
            name = "parentFloor"
        };
        parentFloor.transform.parent = parentGameObject.transform;

        //Draw the map on the screen
        for (int x = 0; x <= width - 1; x++)
        {
            for (int z = 0; z <= length - 1; z++)
            {
                //Create map floor
                GameObject newFloorObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newFloorObject.transform.position = new Vector3(x, -0.5f, z);
                newFloorObject.name = Utility.CreateName("floor_type_" + map[x, z], newFloorObject.transform.position);
                newFloorObject.transform.parent = parentFloor.transform;

                if (showCoordOnFloor == true)
                {
                    GameObject newFloorCanvasObject = new GameObject
                    {
                        name = "Canvas"
                    };
                    newFloorCanvasObject.transform.parent = newFloorObject.transform;
                    Canvas floorCanvas = newFloorCanvasObject.AddComponent<Canvas>();
                    floorCanvas.transform.localPosition = Vector3.zero;
                    floorCanvas.renderMode = RenderMode.WorldSpace;
                    floorCanvas.worldCamera = Camera.main;

                    GameObject newFloorTextObject = new GameObject
                    {
                        name = "Text"
                    };
                    newFloorTextObject.transform.SetParent(newFloorCanvasObject.transform);
                    UnityEngine.UI.Text floorText = newFloorTextObject.transform.gameObject.AddComponent<UnityEngine.UI.Text>();
                    floorText.transform.localPosition = new Vector3(0f, 0.501f, 0f);
                    floorText.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                    floorText.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                    //floorText.transform.parent = floorCanvas.transform;
                    floorText.rectTransform.sizeDelta = new Vector2(100f, 100f);
                    floorText.color = Color.black;
                    floorText.alignment = TextAnchor.MiddleCenter;
                    floorText.fontSize = 24;
                    floorText.font = arialFont;
                    floorText.text = "x" + x.ToString() + ",y" + z.ToString();
                }

                //GameObject newObject = GameObject.Instantiate(Resources.Load<GameObject>("PolygonStarter/Prefabs/SM_PolygonPrototype_Buildings_Block_1x1_01P"), Vector3.zero, Quaternion.identity) as GameObject;


                ////Create map objects, if exists
                //if (map[x, y, z] != "")
                //{
                //    CreateCoverObject(new Vector3(x, y, z), map[x, y, z], newFloorObject.transform);
                //}

                if (showLinesOnFloor == true)
                {
                    //Draw line renderers
                    if (x == 0 && z != length - 1)
                    {
                        LineRenderer xGuideLine = newFloorObject.AddComponent<LineRenderer>();
                        xGuideLine.material = new Material(Shader.Find("Sprites/Default"));
                        xGuideLine.widthMultiplier = 0.01f;
                        xGuideLine.startColor = Color.cyan;
                        xGuideLine.endColor = Color.cyan;
                        xGuideLine.SetPosition(0, new Vector3(-0.5f, 0.01f, z + 0.5f));
                        xGuideLine.SetPosition(1, new Vector3(width - 0.5f, 0.01f, z + 0.5f));
                    }
                    else if (z == length - 1 && x != 0)
                    {
                        LineRenderer zGuideLine = newFloorObject.AddComponent<LineRenderer>();
                        zGuideLine.material = new Material(Shader.Find("Sprites/Default"));
                        zGuideLine.widthMultiplier = 0.01f;
                        zGuideLine.startColor = Color.cyan;
                        zGuideLine.endColor = Color.cyan;
                        zGuideLine.SetPosition(0, new Vector3(x - 0.5f, 0.01f, -0.5f));
                        zGuideLine.SetPosition(1, new Vector3(x - 0.5f, 0.01f, length - 0.5f));
                    }
                }

            } //end z for
        } //end x for
    }

    //public static void CreateCoverObject(Vector3 location, string mapItem, Transform parentTransform)
    //{
    //    bool newModel = false;
    //    GameObject newObject = null;
    //    //GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //    float newObjectY = 0f;
    //    switch (mapItem)
    //    {
    //        case CoverType.HalfCover:
    //            newModel = true;
    //            newObjectY = 0.5f;
    //            newObject = Instantiate(Resources.Load(PrefabResources.CratePrefabName),
    //               new Vector3(location.x, newObjectY, location.z),
    //               Quaternion.identity,
    //               parentTransform) as GameObject;
    //            newObject.name = Utility.CreateName("CoverObject_", location);
    //            newObject.transform.localScale = new Vector3(1f, 1f, 1f);

    //            //newObject = GameObject.CreatePrimitive(PrimitiveType.Cube); // GameObject.Instantiate(highCoverPrefab);
    //            //newObjectY = 0.5f;
    //            //newObject.transform.localScale = new Vector3(1f, 1f, 1f);
    //            ////newObject.tag = Tag_Destructible;
    //            break;
    //        case CoverType.FullCover:
    //            newModel = true;
    //            newObjectY = 0.5f;
    //            newObject = Instantiate(Resources.Load(PrefabResources.CratePrefabName),
    //               new Vector3(location.x, newObjectY, location.z),
    //               Quaternion.identity,
    //               parentTransform) as GameObject;
    //            newObject.name = Utility.CreateName("CoverObject_", location);
    //            newObject.transform.localScale = new Vector3(1f, 1f, 1f);

    //            newObjectY = 1.5f;
    //            GameObject newObject2 = Instantiate(Resources.Load(PrefabResources.CratePrefabName),
    //               new Vector3(location.x, newObjectY, location.z),
    //               Quaternion.identity,
    //               parentTransform) as GameObject;
    //            newObject2.name = Utility.CreateName("CoverObject2_", location);
    //            newObject2.transform.localScale = new Vector3(1f, 1f, 1f);

    //            //newModel = false;
    //            //newObject = GameObject.CreatePrimitive(PrimitiveType.Cube); //GameObject.Instantiate(lowCoverPrefab);
    //            //newObjectY = 1f;
    //            //newObject.transform.localScale = new Vector3(1f, 2f, 1f);
    //            ////newObject.tag = Tag_Destructible;
    //            break;
    //    }
    //    if (newObject != null && newModel == false)
    //    {
    //        newObject.transform.position = new Vector3(location.x, newObjectY, location.z);
    //        newObject.transform.parent = parentTransform;
    //        newObject.name = Utility.CreateName("CoverObject_", location);
    //        //newObject.transform.localScale = Vector3.one;
    //    }
    //}

    public static string[,,] InitializeMap(int xMax, int yMax, int zMax)
    {
        string[,,] map = new string[xMax, yMax, zMax];

        //Initialize the map
        int y = 0;
        for (int z = 0; z < zMax; z++)
        {
            for (int x = 0; x < xMax; x++)
            {
                map[x, y, z] = "";
            }
        }

        return map;
    }
}