using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class GatherMaterials : MonoBehaviour
{
    // 用来存储所有材质的列表  
    private List<Material> materials = new List<Material>();

    // 假设这个函数在某个事件触发时被调用，比如点击一个按钮  
    public void GatherMaterialsFromChildren()
    {
        // 清除之前的材质列表（如果需要）  
        materials.Clear();

        // 获取当前物体（脚本附加的物体）的子物体  
        Transform[] childTransforms = GetComponentsInChildren<Transform>(true);

        // 遍历所有子物体（包括自身）  
        foreach (Transform childTransform in childTransforms)
        {
            // 尝试获取Renderer组件  
            Renderer renderer = childTransform.GetComponent<Renderer>();
            if (renderer != null)
            {
                // 获取Renderer上的所有材质（可能是一个数组）  
                Material[] rendererMaterials = renderer.sharedMaterials;

                // 将这些材质添加到列表中  
                materials.AddRange(rendererMaterials);
            }
        }

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

                // Debug.Log("文件名字是：" + fileName);
                // 在这里，materials列表现在包含了所有子物体的材质  
                // 你可以根据需要处理这个列表，比如打印到控制台或进行其他操作  
                foreach (Material mat in materials)
                {
                    string materialName = mat.name + ".mat";

                    if(fileName != materialName)
                    {
                        Debug.Log("没有引用的材质球的名字为：" + fileName);
                    }
                }
                
            }

        }


    }
}