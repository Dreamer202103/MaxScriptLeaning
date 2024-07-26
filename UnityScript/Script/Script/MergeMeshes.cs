using System.Collections.Generic;  
using UnityEngine;  
using UnityEditor;
  
public class MergeMeshes : MonoBehaviour  
{  
    // 合并后的Mesh  
    private Mesh combinedMesh;  
  
    // 合并Mesh的方法  
    public void MergeSelectedMeshes()  
    {  
        // 获取场景中所有包含Mesh Filter的GameObject  
        MeshFilter[] meshFilters = FindObjectsOfType<MeshFilter>();  
  
        // 假设我们只合并选中的GameObject  
        List<Mesh> selectedMeshes = new List<Mesh>();  
        foreach (MeshFilter mf in meshFilters)  
        {  
            if (mf.gameObject.activeInHierarchy && Selection.Contains(mf.gameObject))  
            {  
                selectedMeshes.Add(mf.sharedMesh);  
            }  
        }  
  
        // 如果没有选中的Mesh，则退出  
        if (selectedMeshes.Count == 0)  
        {  
            Debug.Log("No selected meshes to merge.");  
            return;  
        }  
  
        // 初始化合并Mesh的顶点、法线、UV等列表  
        List<Vector3> vertices = new List<Vector3>();  
        List<Vector2> uv = new List<Vector2>();  
        List<int>[] triangles = new List<int>[selectedMeshes.Count];  
  
        // 遍历每个选中的Mesh，并将它们的顶点、UV和三角形索引添加到列表中  
        for (int i = 0; i < selectedMeshes.Count; i++)  
        {  
            Mesh mesh = selectedMeshes[i];  
            vertices.AddRange(mesh.vertices);  
            uv.AddRange(mesh.uv); // 假设所有Mesh的UV都是相同的维度  
            triangles[i] = new List<int>();  
            for (int j = 0; j < mesh.triangles.Length; j += 3)  
            {  
                // 偏移三角形索引以匹配新的顶点列表  
                triangles[i].Add(vertices.Count - mesh.vertices.Length + mesh.triangles[j]);  
                triangles[i].Add(vertices.Count - mesh.vertices.Length + mesh.triangles[j + 1]);  
                triangles[i].Add(vertices.Count - mesh.vertices.Length + mesh.triangles[j + 2]);  
            }  
        }  
  
        // 合并三角形索引  
        List<int> combinedTriangles = new List<int>();  
        foreach (var triList in triangles)  
        {  
            combinedTriangles.AddRange(triList);  
        }  
  
        // 创建新的Mesh  
        combinedMesh = new Mesh();  
        combinedMesh.vertices = vertices.ToArray();  
        combinedMesh.uv = uv.ToArray();  
        combinedMesh.triangles = combinedTriangles.ToArray();  
        combinedMesh.RecalculateNormals(); // 重新计算法线  
  
        // 创建一个新的GameObject来显示合并后的Mesh  
        GameObject combinedObj = new GameObject("Combined Mesh");  
        MeshFilter combinedMeshFilter = combinedObj.AddComponent<MeshFilter>();  
        MeshRenderer combinedMeshRenderer = combinedObj.AddComponent<MeshRenderer>();  
        combinedMeshFilter.mesh = combinedMesh;  
    }  
  
    // 在Unity编辑器中调用此方法  
    [ContextMenu("Merge Selected Meshes")]  
    private void MergeMeshesMenuItem()  
    {  
        MergeSelectedMeshes();  
    }  
}