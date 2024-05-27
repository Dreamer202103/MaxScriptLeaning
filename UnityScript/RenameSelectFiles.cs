using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RenameSelectFiles : EditorWindow
{
    [MenuItem("DreamerTools/RenameSelectionFiles", false, 0)]
    static void RenameSelectionFiles()
    {
        // var window = GetWindow<RenameSelectFiles>();
        // window.Show();
        EditorWindow.GetWindow<RenameSelectFiles>();
    }

    private string filesPath = "请输路径...";
    private string filesNewName = "请输文本...";
    void OnGUI()
    {
        GUILayout.Label("要重名文件路径填在下面:");
        filesPath = EditorGUILayout.TextField("重命名文件路径:", filesPath);
        GUILayout.Label("要重名文件的名字填在下面:");
        filesNewName = EditorGUILayout.TextField("重命名文件的名字是:", filesNewName);
        // GUILayout.Label("要重名文件的路径填在下面：");
        

        if (GUILayout.Button("Rename Selection Files"))
        {

            Object[] selecteAssets = Selection.objects;

            for (int i = 0; i < selecteAssets.Length; i++)
            {
               
                string filesPath1 = filesPath + "/" + selecteAssets[i].name + ".mat";
                AssetDatabase.RenameAsset(filesPath1, filesNewName + i);
            }
        }
    }

}
