using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LeaningT : EditorWindow
{
    // public HashSet<string> MateiralsName1 = new HashSet<string>();
    // private GameObject model;
    // model = EditorGUILayout.ObjectField(model, typeof(GameObject), true) as GameObject;

    [MenuItem("DreamerTools/Test", false, 0)]
    static public void ShowTest()
    {
        // EditorWindow.GetWindow<TestL>();
        //把窗口大小写一个固定的值
        // var window = GetWindowWithRect<TestL>(new Rect(0,0,165,100));
        //把窗口大小没有固定值
        var window = GetWindow<LeaningT>();
        window.Show();
    }

    private string GUidPath;
    void OnGUI()
    {
        GUidPath = EditorGUILayout.TextField("重命名文件路径:", GUidPath);
        if (GUILayout.Button("test"))
        {
            //Debug.Log("GUID:" + AssetDatabase.AssetPathToGUID(GUidPath));
            // Object[] selecteAssets = Selection.objects;
            // Debug.Log("" + selecteAssets.Name);
            // foreach(var selecte in selecteAssets)
            // {
            //     Debug.Log("" + selecte.name);
            // }
            //typeof就是一个运算符
            // Debug.Log(typeof(float));
            foreach (var obj in Selection.objects)
            {
                /*
                 * if (obj is UnityEngine.Object unityObject)
                 * 这条语句是C# 7.0及更高版本中引入的模式匹配（Pattern Matching）功能的一个示例，特别是is表达式的一个增强版本
                 * is UnityEngine.Object：这是一个传统的is关键字用法，用于检查obj是否是UnityEngine.Object或其派生类的实例。
                 * 但是，与传统的is关键字用法不同，这里我们不仅仅是要检查类型，还要进行类型转换。
                 * unityObject：这是一个新的变量（或称为“输出变量”），
                 * 它将在if语句的条件为true时被赋予obj的值（但此时的obj已经被视为UnityEngine.Object或其派生类的实例）。
                 * 这样的好处是，你不需要先使用is检查类型，然后再进行显式的类型转换。你可以一次性完成这两个操作，并使代码更加简洁和易读。
                 * if (obj is UnityEngine.Object)  
                 * {  
                 *       UnityEngine.Object unityObject = (UnityEngine.Object)obj;  
                 *     // 使用unityObject...  
                 * }
                 */
                // 首先检查它是否是一个 UnityEngine.Object  
                if (obj is UnityEngine.Object unityObject)
                {
                    // 然后检查它是否是一个特定的类型  
                    if (unityObject is GameObject gameObject)
                    {
                        Debug.Log("Selected GameObject: " + gameObject.name);
                    }
                    else if (unityObject is Material material)
                    {
                        Debug.Log("Selected Material: " + material.name);
                    }
                    else if (unityObject is Texture2D texture)
                    {
                        // 尝试获取资源的路径（对于场景中的GameObject，这将返回空字符串）  
                        string assetPath = AssetDatabase.GetAssetPath(unityObject);
                        if (!string.IsNullOrEmpty(assetPath))
                        {
                            // 获取文件名和扩展名  
                            string fileNameWithExtension = Path.GetFileName(assetPath);
                            // 获取文件的扩展名  
                            string extension = Path.GetExtension(assetPath);

                            // 输出信息  
                            Debug.Log($"Selected Resource: {fileNameWithExtension}");
                            Debug.Log($"Selected Resource: {extension}");
                        }
                        Debug.Log("Selected Texture2D: " + texture.name);
                    }
                    // 可以添加更多其他类型的检查   

                    // 如果不是以上类型，但仍然是 UnityEngine.Object，可以打印它的类型  
                    else
                    {
                        Debug.Log("Selected Object of type: " + unityObject.GetType().Name);
                    }
                }
                else
                {
                    // 如果不是 UnityEngine.Object，则可能是 null 或者其他类型的对象  
                    Debug.LogWarning("Selected object is not a UnityEngine.Object: " + obj.GetType().Name);
                }
            }

        }
    }
}
