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
            string[] guids = AssetDatabase.FindAssets("", new string[] { Commopath1 });
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
                //调取材质球上引用贴图
                Texture texture = material.GetTexture(shaderPropertyName);
                if (texture != null)
                {
                    //通过名字获取文件路径
                    string assetPath = AssetDatabase.GetAssetPath(texture);
                    if (!string.IsNullOrEmpty(assetPath))
                    {
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
                            if (!string.IsNullOrEmpty(NoPath))
                            {
                                // 获取文件名（不包括路径）  
                                string fileName = Path.GetFileName(NoPath);
                                foreach (var i in GUIDsName)
                                {
                                    string GUIDfilename = System.IO.Path.GetFileName(AssetDatabase.GUIDToAssetPath(i));
                                    //Debug.LogWarning("000000" + GUIDfilename);
                                    
                                    if (fileName == GUIDfilename)
                                    {
                                        string texturePath = AssetDatabase.GUIDToAssetPath(i);
                                        
                                        // 加载贴图资源  
                                        Texture2D texture1 = AssetDatabase.LoadAssetAtPath<Texture2D>(texturePath);
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
