using UnityEngine;
using UnityEditor;
using System.Text;

public class CopyTransformInfo : EditorWindow
{
    [MenuItem("DreamerTools/Copy Transform Info to Clipboard")]
    private static void ShowWindow()
    {
        GetWindow(typeof(CopyTransformInfo));
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Copy Selected Object's PositionX Transform Info"))
        {
            GameObject selectedObject = Selection.activeGameObject;
            if (selectedObject != null)
            {
                Transform transform = selectedObject.transform;
                StringBuilder sb = new StringBuilder();

                // Transform transformX = transform.position.x;
                // 格式化为字符串  
                // sb.AppendLine(transformX.ToString("F3")); 
                // sb.Replace(transform.position.x.ToString());
                //得到一个数据后面有回车键的字符串
                // sb.AppendLine(transform.position.x.ToString());
                sb.Append(transform.position.x.ToString());
                // sb.AppendLine("Position: " + transform.position.ToString("F3"));  
                // sb.AppendLine("Rotation: " + transform.rotation.eulerAngles.ToString("F3"));  

                // 复制到剪切板  
                GUIUtility.systemCopyBuffer = sb.ToString();
                Debug.Log("Transform info copied to clipboard.");
            }
            else
            {
                Debug.Log("No object selected.");
            }
        }
        if (GUILayout.Button("Copy Selected Object's PositionY Transform Info"))
        {
            GameObject selectedObject = Selection.activeGameObject;
            if (selectedObject != null)
            {
                Transform transform = selectedObject.transform;
                StringBuilder sb = new StringBuilder();

                // Transform transformX = transform.position.x;
                // 格式化为字符串  
                // sb.AppendLine(transformX.ToString("F3")); 
                sb.Append(transform.position.y.ToString());
                // sb.AppendLine("Position: " + transform.position.ToString("F3"));  
                // sb.AppendLine("Rotation: " + transform.rotation.eulerAngles.ToString("F3"));  

                // 复制到剪切板  
                GUIUtility.systemCopyBuffer = sb.ToString();
                Debug.Log("Transform info copied to clipboard.");
            }
            else
            {
                Debug.Log("No object selected.");
            }
        }
        if (GUILayout.Button("Copy Selected Object's PositionZ Transform Info"))
        {
            GameObject selectedObject = Selection.activeGameObject;
            if (selectedObject != null)
            {
                Transform transform = selectedObject.transform;
                StringBuilder sb = new StringBuilder();

                // Transform transformX = transform.position.x;
                // 格式化为字符串  
                // sb.AppendLine(transformX.ToString("F3")); 
                sb.Append(transform.position.z.ToString());
                // sb.AppendLine("Position: " + transform.position.ToString("F3"));  
                // sb.AppendLine("Rotation: " + transform.rotation.eulerAngles.ToString("F3"));  

                // 复制到剪切板  
                GUIUtility.systemCopyBuffer = sb.ToString();
                Debug.Log("Transform info copied to clipboard.");
            }
            else
            {
                Debug.Log("No object selected.");
            }
        }
        if (GUILayout.Button("Copy Selected Object's Rotation Transform Info"))
        {
            GameObject selectedObject = Selection.activeGameObject;
            if (selectedObject != null)
            {
                Transform transform = selectedObject.transform;
                StringBuilder sb = new StringBuilder();

                // 格式化为字符串  
                // sb.AppendLine("Position: " + transform.position.ToString("F3"));  
                sb.Append("Rotation: " + transform.rotation.eulerAngles.ToString("F3"));

                // 复制到剪切板  
                GUIUtility.systemCopyBuffer = sb.ToString();
                Debug.Log("Transform info copied to clipboard.");
            }
            else
            {
                Debug.Log("No object selected.");
            }
        }
    }
}