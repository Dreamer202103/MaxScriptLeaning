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
        if(GUILayout.Button("Set Material"))
        {
            Setmaterial1(Prefab,CarShowPrefab);
        }
        if(GUILayout.Button("Test"))
        {
            PrintAllChildrenName(Prefab.transform);
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
                        AssetDatabase.SaveAssets();
                        // Debug.Log(carGameObject.transform.GetChild(j).name);
                    }
                    
                    Setmaterial(preGameObject.transform.GetChild(i).gameObject,carGameObject.transform.GetChild(j).gameObject);
                }
                
            }
        }
        
        // AssetDatabase.Refresh();
    }

    public void Setmaterial1(GameObject preGameObject,GameObject carGameObject)
    {
        for(int i = 0; i < preGameObject.transform.childCount; i++)
        {
            for (int j = 0; j < carGameObject.transform.childCount; j++)
            {
                if(i == j)
                {
                    if(preGameObject.transform.GetChild(i).GetComponent<Renderer>() != null && carGameObject.transform.GetChild(j).GetComponent<Renderer>() != null) 
                    {
                        Renderer carRenderer = carGameObject.transform.GetChild(j).GetComponent<Renderer>();
                        Material carMaterial = carRenderer.sharedMaterial;
                        Renderer preRenderer = preGameObject.transform.GetChild(i).GetComponent<Renderer>();
                        preRenderer.sharedMaterial = carMaterial;
                        // AssetDatabase.SaveAssets();
                        // Debug.Log(carGameObject.transform.GetChild(j).name);
                    }
                    
                    Setmaterial1(preGameObject.transform.GetChild(i).gameObject,carGameObject.transform.GetChild(j).gameObject);
                }
            }
        }
    }
    public void Setmaterial2(GameObject preGameObject,GameObject carGameObject)
    {
        for(int i = 0; i < preGameObject.transform.childCount; i++)
        {
            for (int j = 0; j < carGameObject.transform.childCount; j++)
            {
                if(preGameObject.transform.GetChild(i).childCount>=1& carGameObject.transform.GetChild(j).childCount>=1)
                {
                    if(preGameObject.transform.GetChild(i).GetComponent<Renderer>() != null && carGameObject.transform.GetChild(j).GetComponent<Renderer>() != null) 
                    {
                        // 找到最后一个下划线的位置
                        int preLastIndex = preGameObject.transform.GetChild(i).name.LastIndexOf('_');
                        int carlastIndex = carGameObject.transform.GetChild(j).name.LastIndexOf('_');
                        // 如果找不到下划线或只找到一个下划线，返回整个文件名或根据需要处理
                        if (preLastIndex == -1 || preGameObject.transform.GetChild(i).name.IndexOf('_', 0, preLastIndex) == -1)
                        {
                            // 根据需求，返回整个文件名、抛出异常或进行其他处理
                            //Debug.Log(preGameObject.transform.GetChild(i).name); // 这里我们选择返回整个文件名
                        }
                        else
                        {
                            // 找到倒数第二个下划线的位置（通过找到最后一个下划线之前的部分中的最后一个下划线）
                            int secondLastIndex = preGameObject.transform.GetChild(i).name.LastIndexOf('_', preLastIndex - 1);
                            
                            // 返回从倒数第二个下划线之后的所有字符
                            preGameObject.transform.GetChild(i).name = preGameObject.transform.GetChild(i).name.Substring(secondLastIndex + 1);
                        }
                        if (carlastIndex == -1 || carGameObject.transform.GetChild(j).name.IndexOf('_', 0, carlastIndex) == -1)
                        {
                            // 根据需求，返回整个文件名、抛出异常或进行其他处理
                            //Debug.Log(carGameObject.transform.GetChild(j).name); // 这里我们选择返回整个文件名
                        }
                        else
                        {
                            // 找到倒数第二个下划线的位置（通过找到最后一个下划线之前的部分中的最后一个下划线）
                            int secondLastIndex = carGameObject.transform.GetChild(j).name.LastIndexOf('_', carlastIndex - 1);
                            
                            // 返回从倒数第二个下划线之后的所有字符
                            carGameObject.transform.GetChild(j).name = carGameObject.transform.GetChild(j).name.Substring(secondLastIndex + 1);
                        }
                        if(preGameObject.transform.GetChild(i).name == carGameObject.transform.GetChild(j).name) 
                        {
                            
                        Debug.Log(carGameObject.transform.GetChild(j).name);
                        }
                        Setmaterial2(preGameObject.transform.GetChild(i).gameObject,carGameObject.transform.GetChild(j).gameObject);
                    }
                }
                
            }
        }
    }

    public void Setmaterial5(GameObject preGameObject,GameObject carGameObject)
    {
        for(int i = 0; i < preGameObject.transform.childCount; i++)
        {
            for (int j = 0; j < carGameObject.transform.childCount; j++)
            {
                if(preGameObject.transform.GetChild(i).childCount>=1& carGameObject.transform.GetChild(j).childCount>=1)
                {
                    if(preGameObject.transform.GetChild(i).GetComponent<Renderer>() != null && carGameObject.transform.GetChild(j).GetComponent<Renderer>() != null) 
                    {
                        // 找到最后一个下划线的位置
                        int preLastIndex = preGameObject.transform.GetChild(i).name.LastIndexOf('_');
                        int carlastIndex = carGameObject.transform.GetChild(j).name.LastIndexOf('_');
                        // 如果找不到下划线或只找到一个下划线，返回整个文件名或根据需要处理
                        if (preLastIndex == -1 || preGameObject.transform.GetChild(i).name.IndexOf('_', 0, preLastIndex) == -1)
                        {
                            // 根据需求，返回整个文件名、抛出异常或进行其他处理
                            //Debug.Log(preGameObject.transform.GetChild(i).name); // 这里我们选择返回整个文件名
                        }
                        else
                        {
                            // 找到倒数第二个下划线的位置（通过找到最后一个下划线之前的部分中的最后一个下划线）
                            int secondLastIndex = preGameObject.transform.GetChild(i).name.LastIndexOf('_', preLastIndex - 1);
                            
                            // 返回从倒数第二个下划线之后的所有字符
                            preGameObject.transform.GetChild(i).name = preGameObject.transform.GetChild(i).name.Substring(secondLastIndex + 1);
                        }
                        if (carlastIndex == -1 || carGameObject.transform.GetChild(j).name.IndexOf('_', 0, carlastIndex) == -1)
                        {
                            // 根据需求，返回整个文件名、抛出异常或进行其他处理
                            //Debug.Log(carGameObject.transform.GetChild(j).name); // 这里我们选择返回整个文件名
                        }
                        else
                        {
                            // 找到倒数第二个下划线的位置（通过找到最后一个下划线之前的部分中的最后一个下划线）
                            int secondLastIndex = carGameObject.transform.GetChild(j).name.LastIndexOf('_', carlastIndex - 1);
                            
                            // 返回从倒数第二个下划线之后的所有字符
                            carGameObject.transform.GetChild(j).name = carGameObject.transform.GetChild(j).name.Substring(secondLastIndex + 1);
                        }
                        if(preGameObject.transform.GetChild(i).name == carGameObject.transform.GetChild(j).name) 
                        {
                            
                        Debug.Log(carGameObject.transform.GetChild(j).name);
                        }
                        Setmaterial5(preGameObject.transform.GetChild(i).gameObject,carGameObject.transform.GetChild(j).gameObject);
                    }
                    else if(preGameObject.transform.GetChild(i).GetComponent<Renderer>() == null && carGameObject.transform.GetChild(j).GetComponent<Renderer>() == null
                            && preGameObject.transform.GetChild(i).childCount > 0 && carGameObject.transform.GetChild(j).childCount > 0)
                    {
                        // 找到最后一个下划线的位置
                        int preLastIndex = preGameObject.transform.GetChild(i).name.LastIndexOf('_');
                        int carlastIndex = carGameObject.transform.GetChild(j).name.LastIndexOf('_');
                        if (preLastIndex == -1 || preGameObject.transform.GetChild(i).name.IndexOf('_', 0, preLastIndex) == -1)
                        {
                            Setmaterial5(preGameObject.transform.GetChild(i).gameObject,carGameObject.transform.GetChild(j).gameObject);
                            // 根据需求，返回整个文件名、抛出异常或进行其他处理
                            Debug.Log(preGameObject.transform.GetChild(i).name); // 这里我们选择返回整个文件名
                        }
                        else
                        {
                            // 找到倒数第二个下划线的位置（通过找到最后一个下划线之前的部分中的最后一个下划线）
                            int secondLastIndex = preGameObject.transform.GetChild(i).name.LastIndexOf('_', preLastIndex - 1);
                            
                            // 返回从倒数第二个下划线之后的所有字符
                            preGameObject.transform.GetChild(i).name = preGameObject.transform.GetChild(i).name.Substring(secondLastIndex + 1);
                            Debug.Log(preGameObject.transform.GetChild(i).name);
                        }
                        // Debug.Log(preGameObject.transform.GetChild(i).name);
                        
                    }
                }
            
                
            }
        }
    }

    public void Setmaterial3(GameObject preGameObject)
    {
        printAllName(preGameObject.transform);
        // Debug.Log(l);
    }

    public void printAllName(Transform o)
    {
        string name = null;
        foreach(Transform j in o)
        {
            Debug.Log(j.name);
            printAllName(j);
            // name = j.name;
            // return(name);
        }
        // return(name);
    }
    public string[] childName(Transform t)
    {
        List<string> childNames = new List<string>();
        foreach(Transform j in t)
        {
            childNames.Add(j.name);
            printAllName(j);
            // name = j.name;
            // return(name);
        }
        return childNames.ToArray();
    }

    public void PrintAllChildrenName(Transform l)
    {
        Transform[] allTransforms = l.GetComponentsInChildren<Transform>(true);
        foreach(var i in allTransforms)
        {
            if(i.GetComponent<Renderer>() != null)
            {
                Debug.Log(i.GetComponent<Renderer>().sharedMaterial);
            }
            else
            {
                // Debug.Log(i.name);
            }
            // Debug.Log(i.GetComponent<Renderer>().name);
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
