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

    // private string filesPath = "请输路径...";
    private string filesNewName = "请输文本...";
    void OnGUI()
    {
        // GUILayout.Label("要重名文件路径填在下面:");
        // filesPath = EditorGUILayout.TextField("重命名文件路径:", filesPath);
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
                        // string assetPath = AssetDatabase.GetAssetPath(asset);
                        
                        // Object asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);
                        string FilesPath = Path.GetDirectoryName(assetPath);
                        string extension = Path.GetExtension(assetPath);
                        // Debug.Log("文件的扩展名是：" + extension);
                        string filesPath1 = FilesPath + "/" + selecteAssets[i].name + extension;
                        AssetDatabase.RenameAsset(filesPath1, filesNewName + i);
                    }
                }
                else
                {
                    Debug.Log("选择错误，物体名字：" + obj.name);
                }
            }
        }

        if (GUILayout.Button("Custom Files Name"))
        {
            Object[] selecteAssets = Selection.objects;
            foreach (UnityEngine.Object asset in selecteAssets)
            {
                string assetPath = AssetDatabase.GetAssetPath(asset);
                //获取文件路径(不包含文件名)
                string FilesPath = Path.GetDirectoryName(assetPath);
                // 获取资源的名称（不包含扩展名）和扩展名  
                string assetName = Path.GetFileNameWithoutExtension(assetPath);
                string extension = Path.GetExtension(assetPath);
                //获取他在列表中的索引
                // int index = selecteAssets.IndexOf(asset); 
                // 使用Array.IndexOf方法查找元素在数组中的索引  
                int index = System.Array.IndexOf(selecteAssets, asset);
                string filesPath1 = FilesPath + "/" + asset.name + extension;
                AssetDatabase.RenameAsset(filesPath1, filesNewName + assetName);
                // Debug.Log("文件的扩展名是：" + selecteAssets.Length);
                // if(assetName.EndsWith("_Leather1", System.StringComparison.OrdinalIgnoreCase))
                // {
                //     AssetDatabase.RenameAsset(filesPath1, filesNewName + "_Leather_" + index);
                // }
                // else if(assetName.EndsWith("_int1",System.StringComparison.OrdinalIgnoreCase))
                // {
                //     AssetDatabase.RenameAsset(filesPath1, filesNewName + "_int_" + index);
                // }
                // else
                // {
                //     AssetDatabase.RenameAsset(filesPath1, filesNewName + index);
                // }
                


            }
            // foreach (var obj in selecteAssets)
            // {

            //     if (obj is UnityEngine.Object unityObject)
            //     {
            //         string assetPath = AssetDatabase.GetAssetPath(unityObject);

            //         // for (int i = 0; i < selecteAssets.Length; i++)
            //         // {
            //         //     //获得选中物体的名字
            //         //     Object asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);
            //         //     string extension = Path.GetExtension(assetPath);
            //         //     Debug.Log("文件的扩展名是：" + selecteAssets.Length);
            //         //     string filesPath1 = filesPath + "/" + selecteAssets[i].name + extension;
            //         //     // AssetDatabase.RenameAsset(filesPath1, filesNewName + asset.name);
            //         // }
            //     }
            //     else
            //     {
            //         Debug.Log("选择错误，物体名字：" + obj.name);
            //     }
            // }
        }

        if (GUILayout.Button("Custom Files Name Pro"))
        {
            Object[] selecteAssets = Selection.objects;
            foreach (UnityEngine.Object asset in selecteAssets)
            {
                string assetPath = AssetDatabase.GetAssetPath(asset);
                //获取文件路径(不包含文件名)
                string FilesPath = Path.GetDirectoryName(assetPath);
                // 获取资源的名称（不包含扩展名）和扩展名  
                string assetName = Path.GetFileNameWithoutExtension(assetPath);
                string extension = Path.GetExtension(assetPath);
                int lastIndex = assetName.LastIndexOf('_');
                if(lastIndex != -1 && lastIndex < assetName.Length -1)
                {
                    string newName = assetName.Substring(lastIndex);
                    string filesPath1 = FilesPath + "/" + asset.name + extension;
                    // string assetPath01 = AssetDatabase.GetAssetPath(filesNewName + newName + extension);
                    string filesPath2 = FilesPath + "/" + (filesNewName + newName) + extension;
                    // Debug.Log(File.Exists(filesPath2));
                    int counter = 1;
                    string tempName = newName;
                    while(File.Exists(filesPath2))
                    {
                        tempName = newName + counter;
                        filesPath2 = FilesPath + "/" + (filesNewName + tempName) + extension;
                        counter++;
                        // Debug.Log(newName);
                    }
                    AssetDatabase.RenameAsset(filesPath1, filesNewName + tempName);
                    
                    
                    // Debug.Log(File.Exists(filesNewName + newName + extension));
                }
                // Debug.Log(lastIndex);
                // string extension = Path.GetExtension(assetPath);
                //获取他在列表中的索引
                // int index = selecteAssets.IndexOf(asset); 
                // 使用Array.IndexOf方法查找元素在数组中的索引  
                // int index = System.Array.IndexOf(selecteAssets, asset);
                // string filesPath1 = FilesPath + "/" + asset.name + extension;
                // AssetDatabase.RenameAsset(filesPath1, filesNewName + assetName);
                // Debug.Log("文件的扩展名是：" + selecteAssets.Length);
                // if(assetName.EndsWith("_Leather1", System.StringComparison.OrdinalIgnoreCase))
                // {
                //     AssetDatabase.RenameAsset(filesPath1, filesNewName + "_Leather_" + index);
                // }
                // else if(assetName.EndsWith("_int1",System.StringComparison.OrdinalIgnoreCase))
                // {
                //     AssetDatabase.RenameAsset(filesPath1, filesNewName + "_int_" + index);
                // }
                // else
                // {
                //     AssetDatabase.RenameAsset(filesPath1, filesNewName + index);
                // }
                


            }
            // foreach (var obj in selecteAssets)
            // {

            //     if (obj is UnityEngine.Object unityObject)
            //     {
            //         string assetPath = AssetDatabase.GetAssetPath(unityObject);

            //         // for (int i = 0; i < selecteAssets.Length; i++)
            //         // {
            //         //     //获得选中物体的名字
            //         //     Object asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);
            //         //     string extension = Path.GetExtension(assetPath);
            //         //     Debug.Log("文件的扩展名是：" + selecteAssets.Length);
            //         //     string filesPath1 = filesPath + "/" + selecteAssets[i].name + extension;
            //         //     // AssetDatabase.RenameAsset(filesPath1, filesNewName + asset.name);
            //         // }
            //     }
            //     else
            //     {
            //         Debug.Log("选择错误，物体名字：" + obj.name);
            //     }
            // }
        }
    }

}
