using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ScenesSwitcherEditorL
{
    [InitializeOnLoadMethod]
    static void InitSwitcher()
    {
        SceneView.duringSceneGui += (SceneView scene) =>
        {
            
            Handles.BeginGUI();
            {
                EditorGUILayout.LabelField("Scenes切换：");
                if (GUILayout.Button("A_CarSettingUp", GUILayout.Width(120)))
                {
                    //string t = AssetDatabase.AssetPathToGUID("Assets/Scenes/A_CarSettingUp.unity");
                    EditorSceneManager.OpenScene("Assets/Scenes/A_CarSettingUp.unity");   
                }
                if (GUILayout.Button("Splash", GUILayout.Width(120)))
                {
                    //string a = AssetDatabase.AssetPathToGUID("Assets/Scenes/Splash.unity");
                    //string assetPath = AssetDatabase.GetAssetPath(a); // 根据GUID获取资源路径
                    EditorSceneManager.OpenScene("Assets/Scenes/Splash.unity");
                }
                if (GUILayout.Button("Test", GUILayout.Width(120)))
                {

                    string t = AssetDatabase.AssetPathToGUID("Assets/Scenes/A_CarSettingUp.unity");
                    UnityEngine.Debug.Log(t);

                    //string assetPath = AssetDatabase.GetAssetPath(guid); // 根据GUID获取资源路径
                    //Object mainAsset = AssetDatabase.LoadMainAssetAtPath(assetPath, typeof(T)); // T表示资源类型，比如Texture、ScriptableObject等
                }
            }
            Handles.EndGUI();
        };

    }
}