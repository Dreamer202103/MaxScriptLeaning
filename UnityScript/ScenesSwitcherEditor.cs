using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ScenesSwitcherEditor
{
    [InitializeOnLoadMethod]
    static void InitSwitcher()
    {
        SceneView.duringSceneGui += (SceneView scene) =>
        {
            Handles.BeginGUI();
            {
                EditorGUILayout.LabelField("Scenes切换");
                if (GUILayout.Button("A_CarSettingUp", GUILayout.Width(120)))
                {

                    EditorSceneManager.OpenScene("Assets/Scenes/A_CarSettingUp.unity");

                }
                if (GUILayout.Button("Splash", GUILayout.Width(120)))
                {

                    EditorSceneManager.OpenScene("Assets/Scenes/Splash.unity");
                }

                // if (GUILayout.Button("Rotation_Door", GUILayout.Width(120)))
                // {
                //     // 遍历当前打开场景中的所有根物体  
                //     foreach (GameObject rootObject in SceneManager.GetActiveScene().GetRootGameObjects())
                //     {
                //         // 递归遍历每个根物体的所有子物体  
                //         TraverseChildren(rootObject.transform, "");
                //     }
                //     static void TraverseChildren(Transform parent, string prefix)
                //     {
                //         foreach (Transform child in parent)
                //         {
                //             string name = prefix + child.name; // 如果需要，可以添加前缀来显示层次结构  
                //             Debug.Log("Object Name: " + name);
                //             // 递归遍历子物体的子物体  
                //             TraverseChildren(child, name + "/");
                //         }
                //     }

                //     // EditorSceneManager.OpenScene("Assets/Scenes/Splash.unity");
                // }
                // if (GUILayout.Button("Rotation_Door", GUILayout.Width(120)))
                // {
                //     private GameObject model;
                //     model = EditorGUILayout.ObjectField(model, typeof(GameObject), true) as GameObject;

                //     // Transform targetObject = Selection.activeGameObject;
                //     // for (int i = 0; i < targetObject.childCount; i++)
                //     // {
                //     //     Transform child = targetObject.GetChild(i);
                //     //     // 在这里你可以对子物体进行操作，比如打印它们的名称  
                //     //     Debug.Log("Child Name: " + child.name);

                //     //     // 如果需要，你还可以递归遍历子物体的子物体  
                //     //     // TraverseDirectChildren(child); // 取消注释以递归遍历  
                //     // }
                // }
            }
            Handles.EndGUI();
        };

    }
}