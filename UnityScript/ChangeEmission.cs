using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChangeEmission : EditorWindow
{
    [MenuItem("DreamerTools/Change Material Emission", false, 6)]
    static void ShowSearchMaterialsGUID()
    {
        EditorWindow.GetWindow<ChangeEmission>("Change Material Emission");
    }

    void OnGUI()
    {
        if (GUILayout.Button("Change Material Emission"))
        {
            string shaderPropertyName = "_Emission";
            Color emissionColor = new Color(0, 0, 0, 0);
            Material selectedMaterial = Selection.activeObject as Material;
            selectedMaterial.SetColor(shaderPropertyName, emissionColor);
        }
        if (GUILayout.Button("Change Material More Emission"))
        {
            string shaderPropertyName = "_Emission";
            Color emissionColor = new Color(0, 0, 0, 0);
            // Material selectedMaterial = Selection.activeObject as Material;
            // selectedMaterial.SetColor(shaderPropertyName, emissionColor);

            // 初始化一个空的Material数组  
            Material[] selectedMaterials = new Material[0]; 
            // 使用List更方便添加元素 
            List<Material> materialsList = new List<Material>();  

            foreach (var obj in Selection.objects)
            {
                // 尝试将对象转换为Material 
                Material material = obj as Material;  
                if (material != null)
                {
                    // 如果转换成功，添加到列表中  
                    materialsList.Add(material); 
                }
            }

            // 将List转换为数组
            selectedMaterials = materialsList.ToArray(); 

            foreach(var material in selectedMaterials)
            {
                material.SetColor(shaderPropertyName, emissionColor);
            }
        }
        if (GUILayout.Button(" Under Fold All File"))
        {
            //Resources.LoadAll
            // GameObject gameObject = selection.activeObject;


            string shaderPropertyName = "_Emission";
            Color emissionColor = new Color(0, 0, 0, 0);
            Material selectedMaterial = Selection.activeObject as Material;
            selectedMaterial.SetColor(shaderPropertyName, emissionColor);
        }
    }
}
