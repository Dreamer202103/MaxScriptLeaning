using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace CombineMeshes
{
    ///<summary>
    ///注意：MergeMesh2、3只能针对于mesh上只有一个材质
    /// </summary>
    public static class Combinemeshes
    {
        /// <summary>
        /// （效率低，适应性高）模型点超过65535自动分模型，一个mesh上有多个材质会分出来成为子集部分，父节点要有mesh则 fatherMesh = true;
        /// </summary>
        public static GameObject MergeMesh1(GameObject parent, bool fatherMesh = true)
        {
            //获取原始坐标
            Vector3 initialPos = parent.transform.position;
            Quaternion initialRot = parent.transform.rotation;
            //将模型坐标归零
            parent.transform.position = Vector3.zero;
            parent.transform.rotation = Quaternion.Euler(Vector3.zero);
 
            List<GameObject> list = new List<GameObject>();
            int verts = 0;
            //存放要合并的父物体  
            Dictionary<int, GameObject> NewParent = new Dictionary<int, GameObject>();
            //获取所有网格过滤器
            MeshFilter[] meshFilters = parent.GetComponentsInChildren<MeshFilter>();
 
            //通过游戏对象的总点数/65536，进行分组
            for (int i = 0; i < meshFilters.Length; i++)
            {
                verts += meshFilters[i].mesh.vertexCount;
            }
            for (int i = 1; i <= (verts / 65536) + 1; i++)
            {
                GameObject wx = new GameObject("child" + i);
                wx.transform.parent = parent.transform;
                NewParent.Add(i, wx);
            }
            verts = 0;
            int key = 1;
            //给超过65535点的游戏对象进行分组
            for (int i = 0; i < meshFilters.Length; i++)
            {
                verts += meshFilters[i].mesh.vertexCount;
                if (verts >= 65535)
                {
                    key++;
                    verts = 0;
                    verts += meshFilters[i].mesh.vertexCount;
                }
                //key= (verts / 65536) + 1;
                if (NewParent.ContainsKey(key))
                {
                    meshFilters[i].transform.parent = NewParent[key].transform;
                }
                //else
                //    Debug.Log("错误");
            }
            //处理多材质（一个mesh上有多个材质）
            if (meshFilters[0].GetComponent<MeshRenderer>().sharedMaterials.Length > 1)
            {
                list.Add(GameObject.Instantiate(meshFilters[0].gameObject));
            }
            //
            foreach (var item in NewParent)
            {
                list.Add(MergeMesh3(item.Value, false));
            }
            //处理多材质
            for (int i = 1; i < meshFilters.Length; i++)
            {
                if (meshFilters[0].GetComponent<MeshRenderer>().sharedMaterials.Length > 1)
                {
                    for (int j = 0; j < list[0].transform.childCount; j++)
                    {
                        GameObject.Destroy(list[0].transform.GetChild(j).gameObject);
                    }
                    GameObject.Destroy(meshFilters[0].gameObject);
                }
                if (meshFilters[i].GetComponent<MeshRenderer>().sharedMaterials.Length > 1)
                {
                    list.Add(GameObject.Instantiate(meshFilters[i].gameObject));
                    GameObject.Destroy(meshFilters[i].gameObject);
                }
            }
            //
 
            GameObject tar_Obj = null;
            //是否父节点上有mesh
            if (!fatherMesh)
            {
                tar_Obj = new GameObject();
                tar_Obj.name = "clone_F";
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].gameObject.transform.parent = tar_Obj.transform;
                }
                //还原坐标
                tar_Obj.transform.position = initialPos;
                tar_Obj.transform.rotation = initialRot;
            }
            //父节点上无mesh
            else
            {
                for (int i = 1; i < list.Count; i++)
                {
                    list[i].gameObject.transform.parent = list[0].gameObject.transform;
                    list[i].gameObject.name = "child" + i;
                }
                //还原坐标
                list[0].gameObject.transform.position = initialPos;
                list[0].gameObject.transform.rotation = initialRot;
            }
 
            GameObject.Destroy(parent);
            return fatherMesh ? list[0] : tar_Obj;
        }
        /// <summary>
        ///（效率快、适用性低）模型点不能超过65535，且相同材质会合并
        /// </summary>
        public static GameObject MergeMesh2(GameObject parent, bool mergeAll = true)
        {
            //获取原始坐标
            Vector3 initialPos = parent.transform.position;
            Quaternion initialRot = parent.transform.rotation;
            //将坐标归零
            parent.transform.position = Vector3.zero;
            parent.transform.rotation = Quaternion.Euler(Vector3.zero);
            //获取所有网格过滤器
            MeshFilter[] meshFilters = parent.GetComponentsInChildren<MeshFilter>();
            //存放不同的材质球，相同的就存一个
            Dictionary<string, Material> materials = new Dictionary<string, Material>();
 
            //存放要合并的网格对象
            Dictionary<string, List<CombineInstance>> combines = new Dictionary<string, List<CombineInstance>>();
            for (int i = 0; i < meshFilters.Length; i++)
            {
                //构造一个网格合并结构体
                CombineInstance combine = new CombineInstance();
 
                //给结构体的mesh赋值
                combine.mesh = meshFilters[i].sharedMesh;
                combine.transform = meshFilters[i].transform.localToWorldMatrix;
 
                MeshRenderer renderer = meshFilters[i].GetComponent<MeshRenderer>();
                if (renderer == null)
                {
                    continue;
                }
                Material mat = renderer.sharedMaterial;
                //将相同材质记录一次，再将拥有相同材质的mesh放到Dictionary中
                if (!materials.ContainsKey(mat.name))
                {
                    materials.Add(mat.name, mat);
                }
                if (combines.ContainsKey(mat.name))
                {
                    combines[mat.name].Add(combine);
                }
                else
                {
                    List<CombineInstance> coms = new List<CombineInstance>();
                    coms.Add(combine);
                    combines[mat.name] = coms;
                }
            }
            GameObject combineObj = new GameObject(parent.name);
            foreach (KeyValuePair<string, Material> mater in materials)
            {
                GameObject obj = new GameObject(mater.Key);
                obj.transform.parent = combineObj.transform;
                MeshFilter combineMeshFilter = obj.AddComponent<MeshFilter>();
                combineMeshFilter.mesh = new Mesh();
 
                //将引用相同材质球的网格合并
                combineMeshFilter.sharedMesh.CombineMeshes(combines[mater.Key].ToArray(), true, true);
                //Debug.LogError("网格定点数" + combineMeshFilter.sharedMesh.vertices);
                MeshRenderer rend = obj.AddComponent<MeshRenderer>();
 
                //指定材质球
                rend.sharedMaterial = mater.Value;
 
                //需要设置请自行打开
                //rend.shadowCastingMode = ShadowCastingMode.Off;
                //rend.receiveShadows = true;
            }
 
            GameObject tar_Obj = null;
            if (mergeAll)
            {
                tar_Obj = MergeMesh3(combineObj);
            }
            //还原坐标
            tar_Obj.transform.position = initialPos;
            tar_Obj.transform.rotation = initialRot;
            GameObject.Destroy(parent);
            return tar_Obj;
        }
        /// <summary>
        /// 模型点不能超过65535，材质相同也不会合并(一般外部不常调用，MergeMesh1、2函数更好)
        /// </summary>
        public static GameObject MergeMesh3(GameObject parent, bool mergeSubMeshes = false)
        {
            MeshRenderer[] meshRenderers = parent.GetComponentsInChildren<MeshRenderer>();
            Material[] materials = new Material[meshRenderers.Length];
            for (int i = 0; i < meshRenderers.Length; i++)
            {
                materials[i] = meshRenderers[i].sharedMaterial;
            }
 
            MeshFilter[] meshFilters = parent.GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combineInstances = new CombineInstance[meshFilters.Length];
            for (int i = 0; i < meshFilters.Length; i++)
            {
                combineInstances[i].mesh = meshFilters[i].sharedMesh;
                combineInstances[i].transform = meshFilters[i].transform.localToWorldMatrix;
            }
            GameObject mesh_obj = new GameObject(parent.name);
 
            MeshFilter meshFilter = mesh_obj.AddComponent<MeshFilter>();
            meshFilter.mesh.CombineMeshes(combineInstances, mergeSubMeshes);
            MeshRenderer meshRenderer = mesh_obj.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterials = materials;
 
            GameObject.Destroy(parent);
            return mesh_obj;
        }
    }
}