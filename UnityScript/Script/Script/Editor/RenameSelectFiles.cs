using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
// using System;

public class RenameSelectFiles : EditorWindow
{
    [MenuItem("DreamerTools/RenameSelectionFiles", false, 3)]
    static void RenameSelectionFiles()
    {
        var window = GetWindow<RenameSelectFiles>();
        window.Show();

    }


    private string filesNewName = "请输文本...";
    void OnGUI()
    {
        
        GUILayout.Label("要重名文件的名字填在下面:");
        filesNewName = EditorGUILayout.TextField("重命名文件的名字是:", filesNewName);
        if (GUILayout.Button("Custom Files Name"))
        {
            Object[] selecteAssets = Selection.objects;
            foreach (UnityEngine.Object asset in selecteAssets)
            {
                string assetPath = AssetDatabase.GetAssetPath(asset);

                string FilesPath = Path.GetDirectoryName(assetPath);
 
                string assetName = Path.GetFileNameWithoutExtension(assetPath);
                string extension = Path.GetExtension(assetPath); 
                int index = System.Array.IndexOf(selecteAssets, asset);
                string filesPath1 = FilesPath + "/" + asset.name + extension;
                AssetDatabase.RenameAsset(filesPath1, filesNewName + index);
            }
            
        }
    }

}
