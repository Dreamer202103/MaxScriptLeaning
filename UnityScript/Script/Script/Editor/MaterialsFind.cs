using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class MaterialsFind : EditorWindow
{
    [MenuItem("Assets/MaterialsFind", false, 0)]
    static void Find()
    {
        EditorWindow.GetWindow<MaterialsFind>();
    }

    public void OnGUI()
    {
        if (GUILayout.Button("Matrials name"))
        {
            // // 遍历选中的GameObject及其所有子物体
            // Renderer[] r = Selection.activeGameObject.GetComponentsInChildren<Renderer>();
            // // 获取指定路径下的所有文件和子文件夹
            // string[] fileEntries = Directory.GetFiles("Assets/Materials");
            // string[] subdirectoryEntries = Directory.GetDirectories("Assets/Materials");
            Debug.Log("0213");
            

        }
    }
}
