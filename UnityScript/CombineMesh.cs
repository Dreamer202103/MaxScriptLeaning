using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CombineMesh : EditorWindow
{
    [MenuItem("DreamerTools/Same Material Combine mesh", false, 0)]
    static void ShowMesh()
    {
        var window = GetWindow<CombineMesh>();
        // window.minSize = new Vector2(0,)
        window.Show();
    }
    private GameObject model;
    void OnGUI()
    {
        GUILayout.Label("请将要合并的预制体拖入下方:");
        model = EditorGUILayout.ObjectField(model, typeof(GameObject), true) as GameObject;
        if (GUILayout.Button("Combine Mesh"))
        {
            foreach (Transform item in model.transform)
            {
                if (item.name == "Car_Body")
                {
                    foreach (Transform child in item.transform)
                    {
                        
                        if (child.name == "Body_Exterior")
                        {
                            foreach (Transform i in child.transform)
                            {
                                Debug.Log(i.name);
                            }
                        }
                        else
                        {
                            foreach (Transform i in child.transform)
                            {
                                Debug.Log(i.name);
                            }
                        }
                    }

                }
                
                
            }
        }
    }
}
