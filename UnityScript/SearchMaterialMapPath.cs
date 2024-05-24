using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class SearchMaterialMapPath : EditorWindow
{
    // public Haset<string> guidNmae = new Haset<string>();
    

    [MenuItem("DreamerTools/SearchMaterialMappath", false, 1)]
    static public void ShowSearchMaterialMapPath()
    {
        EditorWindow.GetWindow<SearchMaterialMapPath>("Search Material Map Path");
    }

    //private GameObject model;
    private string path = "请输入文本...";
    void OnGUI()
    {
        GUILayout.Label("复制材质球的路径填在下面:");
        path = EditorGUILayout.TextField("材质球路径:", path);
        if (GUILayout.Button("Search Map Path"))
        {

            string folderPath = path;
            string[] filePaths = Directory.GetFiles(folderPath, "*.mat");
            foreach (string filePath in filePaths)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                Debug.Log("Found .mat file: " + filePath);
                // Debug.Log("Found .mat file: " + fileInfo.Name);
                // 这里你可以根据需要处理文件，但请注意Unity可能无法直接处理.mat文件  
            }
        }
        //GUILayout.Label("请将carShow预制体拖入到下方(可选，为空查询全部):");
        ///model = EditorGUILayout.ObjectField(model, typeof(GameObject), true) as GameObject;
        if (GUILayout.Button("Find GUID of Selected Material's Textures"))
        {


            Material selectedMaterial = Selection.activeObject as Material;
            if (selectedMaterial != null)
            {
                // 查找主要贴图的GUID  
                FindTextureGUID(selectedMaterial, "_Cubemap");
                FindTextureGUID(selectedMaterial, "_Matcap");
                FindTextureGUID(selectedMaterial, "_occ");

                // 你可以根据需要添加查找其他贴图类型的代码，比如法线贴图、高光贴图等  
                // FindTextureGUID(selectedMaterial, "_BumpMap");  
                // FindTextureGUID(selectedMaterial, "_SpecGlossMap");  
            }
            else
            {
                Debug.Log("No Material selected in the Project Browser or Hierarchy.");
            }

            static void FindTextureGUID(Material material, string shaderPropertyName)
            {
                Texture texture = material.GetTexture(shaderPropertyName);
                if (texture != null)
                {
                    string assetPath = AssetDatabase.GetAssetPath(texture);
                    if (!string.IsNullOrEmpty(assetPath))
                    {
                        string guid = AssetDatabase.AssetPathToGUID(assetPath);
                        Debug.Log($"Texture GUID for {shaderPropertyName}: {guid}");
                    }
                    else
                    {
                        Debug.Log($"Cannot find asset path for texture {shaderPropertyName}.");
                    }
                }
                else
                {
                    Debug.Log($"No texture found for shader property {shaderPropertyName} in the material.");
                }
            }
        }


        GUILayout.Label("复制材质球的路径填在下面:");
        path = EditorGUILayout.TextField("材质球路径:", path);
        if (GUILayout.Button("Search Under Fold Files GUID"))
        {
            // 获取指定路径下的所有文件和子文件夹
            string[] files = Directory.GetFiles(path);
            for (int i = 0; i < files.Length; i++)
            {
                //输出文件名(不包含路径)
                string fileName = Path.GetFileName(files[i]);
                Debug.Log("" + fileName);
            }
            // Debug.Log("GUID:" + AssetDatabase.AssetPathToGUID(path));
        }
        // GUILayout.Label(":");
        // model = EditorGUILayout.ObjectField(model, typeof(GameObject), true) as GameObject;
        // GUILayout.Label("材质球的路径:");
        // path = EditorGUILayout.TextField("材质球路径:", path);
        // if (GUILayout.Button("Search All Files GUID"))
        // {
        //     Debug.Log("GUID:" + AssetPathToGUID(path));
        // }
    }
}
