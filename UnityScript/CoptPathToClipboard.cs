using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
// using System.Windows.Forms; // 注意：这仅适用于Windows平台 

public class CoptPathToClipboard : EditorWindow
{
    [MenuItem("DreamerTools/Copy Path Info to Clipboard &c",false,20)]
    private static void ShowWindow()
    {
        GetWindow(typeof(CoptPathToClipboard));
    }


    private void OnGUI()
    {
        if (GUILayout.Button("Copy Selected Object's Path Info"))
        {
            // 获取当前选中的文件或文件夹的GUID  
            string[] guids = Selection.assetGUIDs;

            if (guids.Length > 0)
            {
                string firstSelectedGuid = guids[0];
                // 使用AssetDatabase获取文件或文件夹的路径  
                string path = AssetDatabase.GUIDToAssetPath(firstSelectedGuid);

                // 转换为绝对路径  
                string absolutePath = Path.GetFullPath(path);

                // 复制到剪切板  
                // Clipboard.SetText(absolutePath);
                EditorGUIUtility.systemCopyBuffer = absolutePath; 

                // 显示消息  
                Debug.Log("Copied path to clipboard: " + absolutePath);
            }
            else
            {
                Debug.Log("No file or folder selected.");
            }
        }

    }
}

