using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SetMaterialForPrefab : EditorWindow
{
    [MenuItem("DreamerTools/Set Material For Prefab", false, 15)]
    public static void ShowSetMaterialForPrefab()
    {
        EditorWindow.GetWindow<SetMaterialForPrefab>();
    }

    private GameObject Prefab;
    private GameObject CarShowPrefab;
    public void OnGUI()
    {
        GUILayout.Label("请将Prefab预制体拖入下方:");
        Prefab = EditorGUILayout.ObjectField(Prefab,typeof(GameObject), true) as GameObject;
        GUILayout.Label("请将CarShowPrefab预制体拖入下方:");
        CarShowPrefab = EditorGUILayout.ObjectField(CarShowPrefab,typeof(GameObject), true) as GameObject;
        if(GUILayout.Button("Set Material For Prefab"))
        {
            Setmaterial(Prefab,CarShowPrefab);
        }
    }

    public void Setmaterial(GameObject preGameObject,GameObject carGameObject)
    {
        for(int i = 0; i < preGameObject.transform.childCount; i++)
        {
            for (int j = 0; j < carGameObject.transform.childCount; j++)
            {
                if(preGameObject.transform.GetChild(i).name == carGameObject.transform.GetChild(j).name)
                {
                    if(preGameObject.transform.GetChild(i).GetComponent<Renderer>() != null && carGameObject.transform.GetChild(j).GetComponent<Renderer>() != null) 
                    {
                        Renderer carRenderer = carGameObject.transform.GetChild(j).GetComponent<Renderer>();
                        Material carMaterial = carRenderer.sharedMaterial;
                        Renderer preRenderer = preGameObject.transform.GetChild(i).GetComponent<Renderer>();
                        preRenderer.sharedMaterial = carMaterial;
                        
                        // Debug.Log(carGameObject.transform.GetChild(j).name);
                    }
                    
                    childName(preGameObject.transform.GetChild(i).gameObject,carGameObject.transform.GetChild(j).gameObject);
                }
            }
        }
    }

    // public void childName(GameObject preGameObject,GameObject carGameObject)
    // {
    //     foreach (Transform preChild in Prefab.transform)
    //     {
    //         foreach(Transform carChild in CarShowPrefab.transform)
    //         {
    //             if(preChild.name == carChild.name)
    //             {
    //                 Debug.Log(preChild.name);
    //                 // if(preChild.childCount>0)
    //                 // {
    //                 //     childName(preChild.gameObject,carChild.gameObject);
    //                 // }
                    
    //             }
                
    //         }
            
    //     }
    // }

    // public void SetMaterial(GameObject preGameObject,GameObject carGameObject)
    // {
    //     Material preMaterial = preGameObject.GetComponent<Material>();
    //     Material carMatterial = carGameObject.GetComponent<Material>();
    //     if (preMaterial != null && carMatterial != null)
    //     {
    //         Debug.Log(carMatterial.name);
    //     }
    // }

    // public void CollectObjectMaterialsName(GameObject preGameObject,GameObject carGameObject)
    // {
    //     Renderer carRenderer = null;
    //     // Renderer preRenderer = preGameObject.GetComponent<Renderer>();
    //     if(carGameObject.GetComponent<Renderer>() != null)
    //     {
    //         carRenderer = carGameObject.GetComponent<Renderer>();
    //     }
        
    //     // Material preMaterial = preRenderer.material;
    //     Material carMaterial = carRenderer.material;
    //     if (carMaterial != null)
    //     {
    //         Debug.Log(carMaterial.name);
    //     }

    //     // 递归检查子对象  
    //     foreach (Transform preChild in preGameObject.transform)
    //     {
    //         foreach(Transform carChild in carGameObject.transform)
    //         {
    //             if(preChild.name == carChild.name)
    //             {
    //                 CollectObjectMaterialsName(preChild.gameObject,carChild.gameObject);
    //             }
    //         }
            
    //     }
    // }
}
