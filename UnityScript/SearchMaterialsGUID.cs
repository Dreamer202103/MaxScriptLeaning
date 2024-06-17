using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class SearchMaterialsGUID : EditorWindow
{
    public HashSet<string> GUIDsName = new HashSet<string>();
    // 用于存储找到的材质球的列表  
    List<Material> materials = new List<Material>();

    [MenuItem("DreamerTools/Search Under Fold Files GUID", false, 5)]
    static void ShowSearchMaterialsGUID()
    {
        EditorWindow.GetWindow<SearchMaterialsGUID>("Search Under Fold Files GUID");
    }

    // private string Commopath = "Assets/Update/Common";
    private string Commopath1 = "Assets/Update/Common_1";
    private string Commopath3 = "Assets/Update/Common_3";
    private string Commopath4 = "Assets/Update/Common_4";
    private string Commopath5 = "Assets/Update/Common_5";
    private string Commopath6 = "Assets/Update/Common_6";
    private string Commopath7 = "Assets/Update/Common_7";
    private string Commopath8 = "Assets/Update/Common_8";
    private string Materialspath = "请熟路路径";
    void OnGUI()
    {
        GUILayout.Label("复制材质球的路径填在下面:");
        Materialspath = EditorGUILayout.TextField("材质球路径:", Materialspath);
        if (GUILayout.Button("Search Under Fold Files GUID"))
        {
            // 获取文件夹下所有资源的GUID列表  
            /*
            AssetDatabase.FindAssets 是Unity引擎中的一个API方法
            用于在Unity的Asset Database中搜索资产。
            这个方法的常规方式是这样的：string[] FindAssets(string searchFilter, string[] searchInFolders = null)
            searchFilter: 这是一个额字符串，用于定义搜索的过滤条件。例如：你可以搜索所有以"t:Texture"开头的资源来找到所有纹理。
            searchInFolders:这是一个可选的字符串数组，用于指定要在其中搜索的文件夹

            如果你只是想在 Commopath1 指定的文件夹中搜索特定类型的资产（例如纹理），你可能需要这样做：
            string Commopath1 = "Assets/SomeFolder"; // 假设这是你要搜索的文件夹路径  
            string searchFilter = "t:Texture"; // 只搜索纹理  
            string[] assets = AssetDatabase.FindAssets(searchFilter, new string[] { Commopath1 });
            这样，你就只会得到在 Commopath1 文件夹中的纹理资产的 GUID 数组。
            */
            string[] guids = AssetDatabase.FindAssets("", new string[] { Commopath1 });
            /*
            string[] guids = AssetDatabase.FindAssets("", new string[] { Commopath1 });
            1.第一个参数("")是一个空字符串，这意味着没有提供任何搜索过滤条件，因此它可能会返回项目中的所有资产。
            2.第二个参数(new string[] { Commopath1 })应该是要搜索的文件夹路径的数组。但是Commonpath1是一个字符串，它表示
            某个文件夹得路径
            */

            foreach (string guid in guids)
            {
                GUIDsName.Add(guid);
                // 获取资源的路径  
                //string path = AssetDatabase.GUIDToAssetPath(guid);

                // 打印资源路径和GUID  
                //Debug.Log($"Path: {path}, GUID: {guid}");

                // 如果你需要更进一步的操作，可以在这里进行  
                // ...  
            }
            string[] guids3 = AssetDatabase.FindAssets("", new string[] { Commopath3 });
            foreach (string guid in guids3)
            {
                GUIDsName.Add(guid);
            }
            string[] guids4 = AssetDatabase.FindAssets("", new string[] { Commopath4 });
            foreach (string guid in guids4)
            {
                GUIDsName.Add(guid);
            }
            string[] guids5 = AssetDatabase.FindAssets("", new string[] { Commopath5 });
            foreach (string guid in guids5)
            {
                GUIDsName.Add(guid);
            }
            string[] guids6 = AssetDatabase.FindAssets("", new string[] { Commopath6 });
            foreach (string guid in guids6)
            {
                GUIDsName.Add(guid);
            }
            string[] guids7 = AssetDatabase.FindAssets("", new string[] { Commopath7 });
            foreach (string guid in guids7)
            {
                GUIDsName.Add(guid);
            }
            string[] guids8 = AssetDatabase.FindAssets("", new string[] { Commopath8 });
            foreach (string guid in guids8)
            {
                GUIDsName.Add(guid);
            }
            Material selectedMaterial = Selection.activeObject as Material;
            // Material selectedMaterial = Selection.objects as Material;
            //Debug.Log("Found Material: " + material.name);
            FindTextureGUID(selectedMaterial, "_Cubemap");
            FindTextureGUID(selectedMaterial, "_Matcap");
            FindTextureGUID(selectedMaterial, "_occ");
            FindTextureGUID(selectedMaterial, "_NormalText");
            FindTextureGUID(selectedMaterial, "_Text");
            FindTextureGUID(selectedMaterial, "_Normal");
            FindTextureGUID(selectedMaterial, "_MainTex2");
            FindTextureGUID(selectedMaterial, "_MainTex");
            FindTextureGUID(selectedMaterial, "_ReflectionMap");
            FindTextureGUID(selectedMaterial, "_MatcapDiffuse");
            FindTextureGUID(selectedMaterial, "Texture2D_2C5B56F8");
            FindTextureGUID(selectedMaterial, "Texture2D_5C08590B");
            FindTextureGUID(selectedMaterial, "Texture2D_6CF65934");
            FindTextureGUID(selectedMaterial, "Texture2D_8298BEC6");






            // 获取文件夹下所有资源的GUID列表  
            string[] Materialsguids = AssetDatabase.FindAssets("", new string[] { Materialspath });

            foreach (string guid in Materialsguids)
            {
                // 获取资源的路径  
                string lpath = AssetDatabase.GUIDToAssetPath(guid);

                // 如果是材质球，则加载并添加到列表中  
                Material material = AssetDatabase.LoadAssetAtPath<Material>(lpath);
                if (material == null)
                {
                    Debug.LogError("不是材质球" + lpath);
                }
                else
                {
                    materials.Add(material);
                    // Material selectedMaterial = Selection.activeObject as Material;
                    // //Debug.Log("Found Material: " + material.name);
                    // FindTextureGUID(material, "_Cubemap");
                    // FindTextureGUID(material, "_Matcap");
                    // FindTextureGUID(material, "_occ");
                    // FindTextureGUID(material, "_NormalText");
                    // FindTextureGUID(material, "_Text");
                    // FindTextureGUID(material, "_Normal");
                    // FindTextureGUID(material, "_MainTex2");
                    // FindTextureGUID(material, "_MainTex");
                    // FindTextureGUID(material, "_ReflectionMap");

                }
                // Material selectedMaterial = Selection.activeObject as Material;
            }

            //Debug.Log("GUID:" + AssetDatabase.AssetPathToGUID(path));

            void FindTextureGUID(Material material, string shaderPropertyName)
            {
                /*
                    Material 类有一个 GetTexture 方法，它用于从材质（Material）中获取指定属性的纹理（Texture）。
                    这个方法通常用于访问材质中存储的贴图，比如漫反射贴图（_MainTex）、法线贴图（_BumpMap）、光泽度贴图（_GlossMap）等。
                */
                //调取材质球上引用贴图
                Texture texture = material.GetTexture(shaderPropertyName);
                if (texture != null)
                {
                    //通过名字获取文件路径
                    string assetPath = AssetDatabase.GetAssetPath(texture);
                    if (!string.IsNullOrEmpty(assetPath))
                    {
                        //通过路径获取GUID
                        string guid = AssetDatabase.AssetPathToGUID(assetPath);

                        bool containsMaterial1 = GUIDsName.Contains(guid);
                        // Debug.Log(containsMaterial1);
                        if (containsMaterial1)
                        {
                            //Debug.Log($"在公共材质库里 {shaderPropertyName}: {guid}");
                            Debug.Log($"在公共材质库里 {shaderPropertyName}: {guid}");
                        }
                        else
                        {
                            string NoPath = AssetDatabase.GUIDToAssetPath(guid);
                            //string.IsNullOrEmpty 是一个静态方法，它接受一个字符串参数，并返回一个布尔值，指示该字符串是否为null或空字符串（即长度为0）。
                            if (!string.IsNullOrEmpty(NoPath))
                            {
                                // 获取文件名（不包括路径）  
                                string fileName = Path.GetFileName(NoPath);
                                foreach (var i in GUIDsName)
                                {
                                    //是 C# 中的一个静态方法，它属于 System.IO.Path 类，该类提供了处理文件和目录路径信息的各种实用方法
                                    /*
                                        1.如果路径字符串为空或仅包含空格，GetFileName 和 GetFileNameWithoutExtension 都会返回空字符串。
                                        2.如果路径字符串不包含有效的文件名（例如，它只是一个目录路径），则 GetFileName 将返回空字符串。
                                        3.在处理文件路径时，建议使用 @ 符号来定义字符串字面量，这样可以避免对反斜杠 \ 进行转义。
                                          例如：string path = @"C:\folder\subfolder\myfile.txt";
                                    */
                                    string GUIDfilename = System.IO.Path.GetFileName(AssetDatabase.GUIDToAssetPath(i));

                                    //Debug.LogWarning("000000" + GUIDfilename);

                                    if (fileName == GUIDfilename)
                                    {
                                        //通过GUID获得路径
                                        string texturePath = AssetDatabase.GUIDToAssetPath(i);
                                        // 加载贴图资源  
                                        /*
                                            AssetDatabase.LoadAssetAtPath 只会加载资源到内存中，并不会将其添加到当前场景的 GameObject 上。
                                            如果你想要将资源（如预制体）实例化到场景中，你需要使用 PrefabUtility.InstantiatePrefab 或其他类似的方法。
                                        */
                                        Texture2D texture1 = AssetDatabase.LoadAssetAtPath<Texture2D>(texturePath);
                                        //通过脚本给材质球更换材质贴图
                                        material.SetTexture(shaderPropertyName, texture1);
                                    }
                                    else
                                    {
                                        Debug.LogError("" + GUIDfilename);
                                    }
                                }
                            }
                            // AssetDatabase.AssetPathToGUID(path)
                            // Debug.Log($"不在在公共材质库里 {shaderPropertyName}: {guid}");
                            Debug.LogWarning("" + NoPath);
                            Debug.Log($"不在在公共材质库里 {shaderPropertyName}.");
                        }
                        //Debug.Log($"Texture GUID for {shaderPropertyName}: {guid}");
                    }
                    else
                    {

                        // Debug.Log($"不在在公共材质库里 {shaderPropertyName}: {guid}");
                        Debug.Log($"不在在公共材质库里 {shaderPropertyName}.");
                    }
                }
                else
                {
                    //Debug.LogError($"No texture found for shader property {shaderPropertyName} in the material.");
                }
            }
        }
    }
}
