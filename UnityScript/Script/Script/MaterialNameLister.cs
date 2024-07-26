using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class MaterialNameLister : MonoBehaviour  
{  
    void Start()  
    {  
        // 假设当前GameObject是你想要检查的父物体  
        ListAllMaterialNames(this.gameObject);  
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
}