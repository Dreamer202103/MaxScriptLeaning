using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Find : EditorWindow
{
    public GameObject L;
    [MenuItem("Tools/Find Unuse")]
    static void ShowMaterialNames()
    {
        EditorWindow.GetWindow<Find>();
    }

    private GameObject model;
    public void OnGUI()
    {
        GUILayout.Label("请将carShow预制体拖入到下方(可选，为空查询全部):");
        model = EditorGUILayout.ObjectField(model, typeof(GameObject), true) as GameObject;
        if (GUILayout.Button("Find UnUse Materials File"))
        {

        }
    }
}
