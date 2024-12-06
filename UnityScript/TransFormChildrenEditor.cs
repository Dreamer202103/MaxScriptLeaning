using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TransFormChildrenEditor : EditorWindow
{
    [MenuItem("DreamerTools/Modify Child Transfor &t", false, 6)]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<TransFormChildrenEditor>("Doors Open");
    }
    void OnGUI()
    {
 
        if (GUILayout.Button("Left Door Rotation"))
        {
            ApplyTransformChangesToChildren("Door_LB", 0, 65, 0);
            ApplyTransformChangesToChildren("Door_LF", 0, 65, 0);
        }
        if (GUILayout.Button("Right Door Rotation"))
        {
            ApplyTransformChangesToChildren("Door_RB",0,-65,0);
            ApplyTransformChangesToChildren("Door_RF", 0, -65, 0);
        }
        if (GUILayout.Button("Trunk Door Up Rotation"))
        {
            ApplyTransformChangesToChildren("Trunk_Body", 65, 0, 0);
      
        }
        if (GUILayout.Button("Trunk Door Left Rotation"))
        {
            ApplyTransformChangesToChildren("Trunk_Body", 0, 65, 0);

        }
        if (GUILayout.Button("Trunk Door Right Rotation"))
        {
            ApplyTransformChangesToChildren("Trunk_Body", 0, -65, 0);

        }
        if (GUILayout.Button("Reset Doors Rotation"))
        {
            ApplyTransformChangesToChildren("Door_RB", 0, 0, 0);
            ApplyTransformChangesToChildren("Door_RF", 0, 0, 0);
            ApplyTransformChangesToChildren("Door_LB", 0, 0, 0);
            ApplyTransformChangesToChildren("Door_LF", 0, 0, 0);
            ApplyTransformChangesToChildren("Trunk_Body", 0, 0, 0);
        }
    }

    void ApplyTransformChangesToChildren(string Name, int angleValueX,int angleValueY, int angleValueZ)
    {
        
        var selectedObjects = Selection.gameObjects;

        if (selectedObjects.Length > 0)
        {
            foreach (var selectedObject in selectedObjects)
            {
                
                foreach (Transform childTransform in selectedObject.transform)
                {
                    foreach(Transform littleChildTransform in childTransform.transform)
                    {
                        if (littleChildTransform.name == Name)
                        {
                            littleChildTransform.rotation = Quaternion.Euler(angleValueX, angleValueY, angleValueZ);
                        }
                    }

                }

             
                Undo.RecordObject(selectedObject, "Modify Child Transforms");
 
                EditorUtility.SetDirty(selectedObject);
                SceneView.RepaintAll();
            }
        }
        else
        {
            Debug.Log("No objects selected in the scene.");
        }
    }
}
