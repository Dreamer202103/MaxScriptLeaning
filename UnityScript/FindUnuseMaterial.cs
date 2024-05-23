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
    public HashSet<string> MateiralsName = new HashSet<string>();

    [MenuItem("DreamerTools/MaterialsTool", false, 3)]
    public static void ShowUnuseMaterial()
    {
        EditorWindow.GetWindow<FindUnuseMaterial>();
    }

    private GameObject model;
    private string path = "请输入文本..."; 
    public void OnGUI()
    {
        GUILayout.Label("请将CarShow预制体拖入下方：");
        model = EditorGUILayout.ObjectField(model, typeof(GameObject), true) as GameObject;
        GUILayout.Label("复制材质球的路径填在下面:");
        path =EditorGUILayout.TextField("材质球路径:", path);
        if (GUILayout.Button("FindUnuseMaterial"))
        {
            // 获取指定路径下的所有文件和子文件夹
            string[] files = Directory.GetFiles(path);
            for (int i = 0; i < files.Length; i++)
            {
                // 使用Path.GetExtension来获取文件的扩展名
                string extension = Path.GetExtension(files[i]);
                // 获取文件名（不包括扩展名）
                CollectObjectMaterialsName(model);

                if (string.Equals(extension, ".mat"))
                {
                    //输出文件名(不包含路径)
                    string fileName = Path.GetFileName(files[i]);
                    //string fileNameWithoutExtension = Path.GetFileNameWithoutExtension("Assets/ArtWorks/Materials/Cars/volvo/em90"); 
                    // 去掉扩展名
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                    bool lastName1 = fileNameWithoutExtension.EndsWith("_Glass_white", System.StringComparison.OrdinalIgnoreCase);
                    bool lastName2 = fileNameWithoutExtension.EndsWith("_Glass_black", System.StringComparison.OrdinalIgnoreCase);
                    bool lastName3 = fileNameWithoutExtension.EndsWith("_Glass_perspective", System.StringComparison.OrdinalIgnoreCase);
                    bool lastName4 = fileNameWithoutExtension.EndsWith("_LightGlass", System.StringComparison.OrdinalIgnoreCase);
                    if (lastName1)
                    {
                        MateiralsName.Add(fileNameWithoutExtension);
                    }
                    if (lastName2)
                    {
                        MateiralsName.Add(fileNameWithoutExtension);
                    }
                    if (lastName3)
                    {
                        MateiralsName.Add(fileNameWithoutExtension);
                    }
                    if (lastName4)
                    {
                        MateiralsName.Add(fileNameWithoutExtension);
                    }

                    bool containsBanana = MateiralsName.Contains(fileNameWithoutExtension);
                    
                    if (!containsBanana)
                    {
                        
                        // File.Delete(path +"/" + fileNameWithoutExtension + ".mat");
                        Debug.Log("删除材质球的名字是：" + fileNameWithoutExtension);

                    }



                }

            }

            //CollectObjectMaterialsName(model);
        }
    }
    public void CollectObjectMaterialsName(GameObject gameObject)
    {
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        // MateiralsName = null;
        foreach (Renderer renderer in renderers)
        {
            // 遍历Renderer的materials数组  
            Material[] materials = renderer.sharedMaterials; // 或者使用renderer.materials来获取实例化的材质  
            

            foreach (Material material in materials)
            {
                //Debug.Log("" + material.name);
                MateiralsName.Add(material.name);
                //Debug.Log(MateiralsName.Count + "" + material.name);

            }

        }
    }
}
