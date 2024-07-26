using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Test : EditorWindow
{
    [MenuItem("DreamerTools/Test", false, 6)]
    static void ShowTest()
    {
        EditorWindow.GetWindow<Test>("Search Under Fold Files GUID");
    }

    void OnGUI()
    {
        if (GUILayout.Button("Test"))
        {
            Material selectedMaterial = Selection.activeObject as Material;
            Texture texture = selectedMaterial.GetTexture("_MainTex");
            Debug.Log("贴图的名字：" + texture);
            Color color = selectedMaterial.GetColor("_Color");

            Debug.Log(color.a + "," + color.r + "," + color.g + "," + color.b);
            // color = selectedMaterial.SetColor("", color);
            //通过名字获取文件路径
            string assetPath = AssetDatabase.GetAssetPath(texture);
            Debug.Log("贴图的路径：" + assetPath);
            //通过路径获取GUID
            string guid = AssetDatabase.AssetPathToGUID(assetPath);
            Debug.Log("贴图的GUID：" + guid);
            // Texture2D texture1 = AssetDatabase.LoadAssetAtPath<Texture2D>(texturePath);
            //通过脚本给材质球更换材质贴图
            //material.SetTexture(shaderPropertyName, texture1);
        }
    }
}
