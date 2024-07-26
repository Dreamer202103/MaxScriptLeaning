using UnityEngine;
 
public class MeshCombine : MonoBehaviour
{
    private void Start()
    {
        CombineMeshs();
    }
    void CombineMeshs()
    {
         MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combines = new CombineInstance[meshFilters.Length];
        for (int i = 0; i < meshFilters.Length; i++)
        {
            combines[i].mesh = meshFilters[i].sharedMesh;
            combines[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);//关闭原始对象
        }
        MeshFilter parentFilter = gameObject.AddComponent<MeshFilter>();
        parentFilter.mesh = new Mesh();
        parentFilter.mesh.CombineMeshes(combines);
 
        MeshRenderer parentRender = gameObject.AddComponent<MeshRenderer>();
        parentRender.material = meshFilters[0].GetComponent<MeshRenderer>().sharedMaterial;
        gameObject.SetActive(true);
    }
}