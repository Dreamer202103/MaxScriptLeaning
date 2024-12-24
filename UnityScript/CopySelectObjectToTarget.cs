using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CopySelectObjectToTarget : EditorWindow
{
    [MenuItem("DreamerTools/Copy Object Below",false,22)]
    public static void ShowWindow()
    {
        GetWindow<CopySelectObjectToTarget>("Copy Object Below");
    }
    private GameObject TargetObject;
    private GameObject TargetObject1;
    private void OnGUI()
    {
        GUILayout.Label("请将复制到的目标物体的父级推进下面:");
        TargetObject = EditorGUILayout.ObjectField(TargetObject,typeof(GameObject), true) as GameObject;
        if(GUILayout.Button("Copy Object To Target"))
        {
            // Object[] selectedObjects = Selection.objects;
 
            // 创建一个列表来存储选中的GameObject
            // List<GameObject> selectedGameObjects = new List<GameObject>();
            // GameObject[] selectObjects = (GameObject)Selection.objects;
            // selectObjects = Selection.objects;
            GameObject selectedObject = Selection.activeGameObject;
            // foreach (var item in selectedGameObjects)
            // {
            //     Debug.Log(item.name);
            //     GameObject copy = Instantiate(item, TargetObject.transform.position, item.transform.rotation);
            //     copy.transform.SetParent(TargetObject.transform, false);
            //     Vector3 newScale = new Vector3(-1f, 1f, 1f);
            //     copy.transform.localScale = newScale;
            // }
            // GameObject selectedObject = Selection.activeGameObject;
            GameObject copy = Instantiate(selectedObject, TargetObject.transform.position, selectedObject.transform.rotation);
            copy.transform.SetParent(TargetObject.transform, false);
            Vector3 newScale = new Vector3(-1f, 1f, 1f);
            copy.transform.localScale = newScale;
            // Set the parent of the copy to the target object and adjust its position below the target
            // CopyObject(TargetObject,TargetObject1);
            // copy.transform.localPosition = new Vector3(0, -copy.GetComponent<Renderer>().bounds.size.y, 0);
        }
    }



}
