using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MaterialChecker : EditorWindow
{
    [MenuItem("DreamerTools/Material Checker", false, 7)]

    static void ShowMaterialChecker()
    {
        var window = GetWindow<MaterialChecker>();
        window.Show();
    }

    private GameObject model;
    public Material targetMaterial;
    public void OnGUI()
    {
        GUILayout.Label("请将要合并的预制体拖入下方:");
        model = EditorGUILayout.ObjectField(model, typeof(GameObject), true) as GameObject;
        if (GUILayout.Button("Checker Same Material Mesh"))
        {
            PrintChildName(model.transform);
        }

    }

    public void PrintChildName(Transform trans)
    {
        

        Debug.Log(trans.name);


        foreach (Transform item in trans.transform)
        {
            
            PrintChildName(item);
        }
    }
}
