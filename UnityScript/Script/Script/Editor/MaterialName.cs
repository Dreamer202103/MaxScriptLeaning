using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class MaterialNames : EditorWindow
{
    [MenuItem("Tools/GameObjectMaterialNames", false, 0)]
    static void ShowMaterialNames()
    {
        EditorWindow.GetWindow<MaterialNames>();
    }

    
    public void OnGUI()
    {
        if (GUILayout.Button("GameObjectMaterialNames"))
        {
            //Selection.activeGameObject = null;
            // 获取游戏对象上的渲染器组件
            Renderer[] renderers = Selection.activeGameObject.GetComponentsInChildren<Renderer>();
            Debug.Log(renderers[0]);
            for (int i = 0; i < renderers.Length; i++)
            {
                string materialName = renderers[i].name + ".mat";
                // Debug.Log("材质球的名字是：" + materialName);
                // Debug.Log("材质球的名字类型是：" + renderers[i].name);
            }


            #region [遍历所有渲染器]
            // 遍历所有渲染器
            // foreach (Renderer renderer in renderers)
            // {
            //     遍历渲染器上的所有材质
            //     foreach (Material mat in renderer.material)
            //     {
            //         // 打印每个材质的名字
            //         Debug.Log("Material name: " + mat.name);
            //     }

            // }
            #endregion
        }
        if (GUILayout.Button("SelectGameObjectMaterial_02"))
        {
            GameObject selectObject = Selection.activeGameObject;
            ListAllMaterialNames(selectObject);

        }
        void ListAllMaterialNames(GameObject parent)
        {
            // 遍历父物体的所有子物体  
            foreach (Transform childTransform in parent.transform)
            {
                // 检查子物体是否有Renderer组件  
                Renderer renderer = childTransform.GetComponent<Renderer>();
                if (renderer != null)
                {
                    // 获取Renderer上的所有材质  
                    Material[] materials = renderer.sharedMaterials;
                    foreach (Material mat in materials)
                    {
                        // 检查材质是否为null（可能有些索引没有实际材质）  
                        if (mat != null)
                        {
                            // 打印材质名称  
                            Debug.Log("Material Name: " + mat.name);
                        }
                    }
                }

                // 如果子物体还有子物体，递归遍历  
                if (childTransform.childCount > 0)
                {
                    ListAllMaterialNames(childTransform.gameObject);
                }
            }
        }
        if (GUILayout.Button("Under Folder files Name"))
        {
            // 获取指定路径下的所有文件和子文件夹
            string[] files = Directory.GetFiles("Assets/Materials");
            for (int i = 0; i < files.Length; i++)
            {
                // 使用Path.GetExtension来获取文件的扩展名
                string extension = Path.GetExtension(files[i]);

                if (string.Equals(extension, ".mat"))
                {
                    //输出文件名(不包含路径)
                    string fileName = Path.GetFileName(files[i]);

                    Debug.Log("文件名字是：" + fileName);
                }

            }
        }
        if (GUILayout.Button("Find Unuse Materials"))
        {
            GameObject selectObject = Selection.activeGameObject;
            // 获取指定路径下的所有文件和子文件夹
            string[] files = Directory.GetFiles("Assets/Materials");
            // 遍历父物体的所有子物体  
            
           

        }

        

    }
}