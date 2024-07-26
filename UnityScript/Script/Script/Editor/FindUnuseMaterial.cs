using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class FindUnuseMaterial : EditorWindow
{
    private List<Material> uniqueMaterials = new List<Material>();
    [MenuItem("Tools/FindUnuseMaterial", false, 0)]
    static void ShowMaterialNames()
    {
        EditorWindow.GetWindow<FindUnuseMaterial>();
    }

    public void OnGUI()
    {
        if (GUILayout.Button("FindUnuseMaterial"))
        {
            GameObject targetObject = Selection.activeGameObject;
            CollectUniqueMaterials(targetObject);
            // 获取指定路径下的所有文件和子文件夹
            string[] files = Directory.GetFiles("Assets/Materials");
            // 使用StringBuilder来高效地构建字符串  
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < uniqueMaterials.Count; j++)
            {
                sb.Append(uniqueMaterials[j].name);
            }
            // sb.Tools = sb.ToString();
            StringBuilder sb01 = new StringBuilder();
            for (int i = 0; i < files.Length; i++)
            {
                // 使用Path.GetExtension来获取文件的扩展名
                string extension = Path.GetExtension(files[i]);

                if (string.Equals(extension, ".mat"))
                {
                    //输出文件名(不包含路径)
                    string fileName = Path.GetFileName(files[i]);
                    fileName += ".mat";
                    sb01.Append(fileName);
                }

            }

            for (int i = 0; i < sb01.Length; i++)
            {



                for (int j = 0; j < sb.Length; j++)
                {
                    if(sb01[i] != sb[j])
                    {
                        Debug.Log(sb.Length);
                    }
                }

                //Debug.Log("文件名字是：" + fileName);


            }
        }
    }



    public void CollectUniqueMaterials(GameObject targetObject)
    {
        // 清除之前的材质列表（如果需要的话）  
        uniqueMaterials.Clear();

        // 获取GameObject上的所有Renderer组件  
        Renderer[] renderers = targetObject.GetComponentsInChildren<Renderer>(true);

        foreach (Renderer renderer in renderers)
        {
            // 遍历Renderer的materials数组  
            Material[] materials = renderer.sharedMaterials; // 或者使用renderer.materials来获取实例化的材质  

            foreach (Material material in materials)
            {
                // 检查材质是否已经在列表中  
                if (!ContainsMaterial(material))
                {
                    // material.name += ".mat";
                    // 如果不在列表中，则添加  
                    uniqueMaterials.Add(material);

                }
            }
        }

        // 打印收集到的材质数量（可选）  
        Debug.Log("Collected unique materials count: " + uniqueMaterials.Count);
    }

    // 辅助方法，用于检查材质是否已经在列表中  
    private bool ContainsMaterial(Material material)
    {
        foreach (Material mat in uniqueMaterials)
        {
            if (mat.name == material.name) // 检查材质名称是否相同  
            {
                return true; // 如果找到相同的材质名称，则返回true  
            }
        }
        return false; // 如果没有找到，则返回false  
    }
}