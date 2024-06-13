using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CombineMesh : MonoBehaviour
{
    public int lightmapIndex = -1;

    private void Awake()
    {
        //初始化设置烘焙贴图的index
        if (lightmapIndex >= 0)
        {
            /*
                TryGetComponent<T>(out T component) 是一个 Component 类上的方法，
                用于尝试获取当前GameObject上附加的某个特定类型的组件（Component）
                而不引发异常。如果GameObject上存在该类型的组件，那么该方法会返回true并将组件引用赋值给out参数；
                如果不存在，那么该方法会返回false，并且out参数将不会被赋值
            */
            if (TryGetComponent<MeshRenderer>(out var m))
            {
                m.lightmapIndex = lightmapIndex;
            }
        }
    }
#if UNITY_EDITOR
    [MenuItem("Tools/BombineMesh")]
    static void StartCombineMesh()
    {
        if(Selection.activeTransform)
        {
            MeshFilter[] meshFilters = Selection.activeTransform.GetComponentsInChildren<MeshFilter>();
            //计算父节点的中心
            Vector3 centerPos = GetCenter(meshFilters);
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];
            Material material = null;
            int i = 0;
            while(i<meshFilters.Length)
            {
                var meshRender = meshFilters[i].GetComponent<MeshRenderer>();
                if(material == null)
                {
                    material = meshRender.sharedMaterial;
                }
                if(material != meshRender.sharedMaterial)
                {
                    Debug.LogError("存在不同材质不予合并!!!");
                    return;
                }
                if(lightmap == -1)
                {
                    lightmap = meshRender.lightmapIndex;
                }
                if(lightmap!= meshRender.lightmapIndex)
                {
                    Debug.LogError("存在不同烘焙贴图不予合并！！！");
                    return;
                }

                combine[i] = meshFilters[i].sharedMesh;
                //记录参与合批的lightmapOffset
                combine[i].lightmapScaleOffset = meshRender.lightmapScaleOffset;
                //每个参与合批mesh的矩阵与中心点进行偏移计算
                Matrix4x4 matrix4x4 = meshFilters[i].transform.localToWorldMatrix;
                matrix4x4.m03 -= centerPos.x;
                matrix4x4.m13 -= centerPos.y;
                matrix4x4.m23 -= centerPos.z;
                combine[i].transform = matrix4x4;
                i++;
            }
        }

        var go = new GameObject("combine",typeof(MeshFilter),typeof(MeshRenderer));
        go.transform.position = centerPos;
        go.AddComponent<CombineMesh>().lightmapIndex = lightmap;

        var mesh = new Mesh();
        mesh.CombineMeshes(combine,true,true,true);
        //合并会自动生成UV3，但是我们并不需要，可以这样删除
        mesh.uv3 = null;
        AssetDatabase.CreateAsset(mesh, "Assets/combine.asset");
        go.GetComponent<MeshFilter>().sharedMesh = mesh;
        go.GetComponent<MeshRenderer>().sharedMaterial = material;
        if (go)
        {
            /*
            PrefabUtility.SaveAsPrefabAssetAndConnect 是Unity的一个方法，它用于将一个游戏对象（GameObject）
            保存为预制件（Prefab）资产，并同时将该游戏对象与其保存的预制件实例进行连接。
            这个方法的主要用途是在创建或修改预制件时，确保场景中的实例与资产库中的预制件保持同步
            instanceRoot：要保存为预制件并进入预制件实例的游戏对象。这个对象必须是一个普通的游戏对象或预制件实例的最外层根。它不能是预制件实例内部的子对象。
            assetPath：要在其中保存预制件的路径。这个路径应该指向Unity项目中的Assets文件夹下的某个位置。
            action：用于此操作的交互模式。它可以是 InteractionMode.AutomatedAction 或 InteractionMode.UserAction。这个参数决定了在保存预制件时Unity的行为。
            success（可选参数）：一个输出参数，用于指示保存操作是否成功。如果提供了这个参数，那么它将被设置为 true（如果保存成功）或 false（如果保存失败）。
            */
            PrefabUtility.SaveAsPrefabAssetAndConnect(go, Application.dataPath + "/combine.prefab", InteractionMode.AutomatedAction);
        }
    }

    Vector3 GetCenter(Component[] components)
    {
        if(components !=null && components.Length>0)
        {
            Vector3 min = components[0].transform.position;
            Vector3 max = min;
            foreach(var comp in components)
            {
                min = Vector3.Min(min,comp.transform.position);
                max = Vector3.Max(max,comp.transform.position);
            }
            return min + ((max - min)/2);
        }
        return Vector3.zero;
    }

#endif
}