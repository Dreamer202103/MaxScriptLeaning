using System.Collections.Generic;  
using UnityEngine;  
  
public class MaterialCollector : MonoBehaviour  
{  
    private List<Material> uniqueMaterials = new List<Material>();  
  
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
                    // 如果不在列表中，则添加  
                    uniqueMaterials.Add(material);
                    Debug.Log(material.name); 
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
  
    // 在某个事件（如Start或某个按钮点击）中调用CollectUniqueMaterials方法  
    private void Start()  
    {  
        // 假设你要收集当前GameObject及其子物体的材质  
        CollectUniqueMaterials(gameObject);  
    }  
}