using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class RenameSelectFiles : EditorWindow
{
    [MenuItem("DreamerTools/RenameSelectionFiles", false, 0)]
    static void RenameSelectionFiles()
    {
        var window = GetWindow<RenameSelectFiles>();
        window.Show();

    }

    private string filesPath = "请输路径...";
    private string filesNewName = "请输文本...";
    void OnGUI()
    {
        GUILayout.Label("要重名文件路径填在下面:");
        filesPath = EditorGUILayout.TextField("重命名文件路径:", filesPath);
        GUILayout.Label("要重名文件的名字填在下面:");
        filesNewName = EditorGUILayout.TextField("重命名文件的名字是:", filesNewName);

        if (GUILayout.Button("Rename Selection Files"))
        {
            Object[] selecteAssets = Selection.objects;
            foreach (var obj in selecteAssets)
            {
    
                if (obj is UnityEngine.Object unityObject)
                {
                    string assetPath = AssetDatabase.GetAssetPath(unityObject);
                    for (int i = 0; i < selecteAssets.Length; i++)
                    {  
                        string extension = Path.GetExtension(assetPath);
                        Debug.Log("文件的扩展名是：" + extension);
                        string filesPath1 = filesPath + "/" + selecteAssets[i].name + extension;
                        AssetDatabase.RenameAsset(filesPath1, filesNewName + i);
                    }
                }
                else
                {
                    Debug.Log("选择错误，物体名字：" + obj.name);
                }
            }




        }
    }

}
