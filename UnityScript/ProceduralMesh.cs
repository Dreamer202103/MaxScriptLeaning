using ProceduralMeshes;
using ProceduralMeshes.Generators;
using ProceduralMeshes.Streams;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralMesh : MonoBehaviour 
{
    /*
        这段代码定义了一个名为 jobs 的数组，它包含了一系列 MeshJobScheduleDelegate 类型的委托（或类似函数的引用）。
        这些委托很可能是指向特定网格生成或处理任务的调度方法的引用，这些任务被设计为并行执行以提高效率。
        每个委托都与不同类型的网格和流（或处理模式）相关联，
        这些网格和流可能是用于图形渲染、游戏开发、科学计算或其他需要高效网格处理的应用中的。

        具体来说，这段代码中的每个元素都是通过 MeshJob<TGrid, TStream>.ScheduleParallel 静态方法获取的，
        其中 TGrid 代表网格的类型，TStream 代表网格数据处理的流或模式。这里涉及的网格类型包括：
            SquareGrid：方形网格
            SharedSquareGrid：共享方形网格（可能意味着网格数据在多个实例间共享）
            SharedTriangleGrid：共享三角形网格
            FlatHexagonGrid：平面六边形网格
            PointyHexagonGrid：尖顶六边形网格
            CubeSphere：立方体球体网格（一种将球体近似为多个立方体的网格）
            SharedCubeSphere：共享立方体球体网格
            Icosphere：二十面体球体网格（基于二十面体分割的球体网格）
            GeoIcosphere：可能是地理坐标下的二十面体球体网格
            Octasphere：八面体球体网格（基于八面体分割的球体网格）
            GeoOctasphere：可能是地理坐标下的八面体球体网格
            UVSphere：UV球体网格（可能是指基于UV映射的球体网格）
        而 SingleStream 和 PositionStream 很可能代表处理网格数据时使用的不同数据流或模式。
        SingleStream 可能意味着使用单一的、统一的数据流来处理网格，
        而 PositionStream 可能专门用于处理与位置相关的数据。

        ScheduleParallel 方法名暗示了这些任务被设计为并行执行，这意味着在多核处理器上，
        可以同时处理多个网格的生成或处理任务，从而显著提高整体性能。

        总的来说，这段代码的目的是为了定义一系列可以并行执行的网格处理任务，以便在需要时调度它们。
        这种设计在处理大量复杂网格或需要快速生成网格的场景中非常有用。
    */
	static MeshJobScheduleDelegate[] jobs = 
    {
		MeshJob<SquareGrid, SingleStream>.ScheduleParallel,
		MeshJob<SharedSquareGrid, SingleStream>.ScheduleParallel,
		MeshJob<SharedTriangleGrid, SingleStream>.ScheduleParallel,
		MeshJob<FlatHexagonGrid, SingleStream>.ScheduleParallel,
		MeshJob<PointyHexagonGrid, SingleStream>.ScheduleParallel,
		MeshJob<CubeSphere, SingleStream>.ScheduleParallel,
		MeshJob<SharedCubeSphere, PositionStream>.ScheduleParallel,
		MeshJob<Icosphere, PositionStream>.ScheduleParallel,
		MeshJob<GeoIcosphere, PositionStream>.ScheduleParallel,
		MeshJob<Octasphere, SingleStream>.ScheduleParallel,
		MeshJob<GeoOctasphere, SingleStream>.ScheduleParallel,
		MeshJob<UVSphere, SingleStream>.ScheduleParallel
	};

	public enum MeshType 
    {
		SquareGrid, 
        SharedSquareGrid, 
        SharedTriangleGrid,
		FlatHexagonGrid, 
        PointyHexagonGrid, 
        CubeSphere, 
        SharedCubeSphere,
		Icosphere, 
        GeoIcosphere, 
        Octasphere, 
        GeoOctasphere, 
        UVSphere
	};

	[SerializeField]
	MeshType meshType;

	[System.Flags]
	public enum MeshOptimizationMode 
    {
		Nothing = 0, 
        ReorderIndices = 1, 
        ReorderVertices = 0b10
	}

	[SerializeField]
	MeshOptimizationMode meshOptimization;

	[SerializeField, Range(1, 50)]
	int resolution = 1;

	[System.Flags]
	public enum GizmoMode 
    {
		Nothing = 0, 
        Vertices = 1, 
        Normals = 0b10, 
        Tangents = 0b100, 
        Triangles = 0b1000
	}

	[SerializeField]
	GizmoMode gizmos;

	public enum MaterialMode 
    { 
        Flat, 
        Ripple, 
        LatLonMap, 
        CubeMap 
    }

    // 使用[SerializeField]后，这个私有字段在Inspector中可见
	[SerializeField]
	MaterialMode material;

	[SerializeField]
	Material[] materials;

	Mesh mesh;

    //使用 [NonSerialized] 特性来防止字段被序列化
	[System.NonSerialized]
	Vector3[] vertices, normals;

	[System.NonSerialized]
	Vector4[] tangents;

	[System.NonSerialized]
	int[] triangles;

	void Awake () 
    {
		mesh = new Mesh 
        {
			name = "Procedural Mesh"
		};
		GetComponent<MeshFilter>().mesh = mesh;
	}

	void OnDrawGizmos () 
    {
		if (gizmos == GizmoMode.Nothing || mesh == null) 
        {
			return;
		}

		bool drawVertices = (gizmos & GizmoMode.Vertices) != 0;
		bool drawNormals = (gizmos & GizmoMode.Normals) != 0;
		bool drawTangents = (gizmos & GizmoMode.Tangents) != 0;
		bool drawTriangles = (gizmos & GizmoMode.Triangles) != 0;

		if (vertices == null)
        {
			vertices = mesh.vertices;
		}
		if (drawNormals && normals == null) 
        {
			drawNormals = mesh.HasVertexAttribute(VertexAttribute.Normal);
			if (drawNormals) 
            {
				normals = mesh.normals;
			}
		}
		if (drawTangents && tangents == null) 
        {
			drawTangents = mesh.HasVertexAttribute(VertexAttribute.Tangent);
			if (drawTangents) 
            {
				tangents = mesh.tangents;
			}
		}
		if (drawTriangles && triangles == null) 
        {
			triangles = mesh.triangles;
		}

		Transform t = transform;
		for (int i = 0; i < vertices.Length; i++) 
        {
			Vector3 position = t.TransformPoint(vertices[i]);
			if (drawVertices) 
            {
				Gizmos.color = Color.cyan;
				Gizmos.DrawSphere(position, 0.02f);
			}
			if (drawNormals) 
            {
				Gizmos.color = Color.green;
				Gizmos.DrawRay(position, t.TransformDirection(normals[i]) * 0.2f);
			}
			if (drawTangents) 
            {
				Gizmos.color = Color.red;
				Gizmos.DrawRay(position, t.TransformDirection(tangents[i]) * 0.2f);
			}
		}

		if (drawTriangles) 
        {
			float colorStep = 1f / (triangles.Length - 3);
			for (int i = 0; i < triangles.Length; i += 3) 
            {
				float c = i * colorStep;
				Gizmos.color = new Color(c, 0f, c);
				Gizmos.DrawSphere(
					t.TransformPoint((
						vertices[triangles[i]] +
						vertices[triangles[i + 1]] +
						vertices[triangles[i + 2]]
					) * (1f / 3f)),
					0.02f
				);
			}
		}
	}

	void OnValidate () => enabled = true;

	void Update () 
    {
		GenerateMesh();
		enabled = false;

		vertices = null;
		normals = null;
		tangents = null;
		triangles = null;
+
		GetComponent<MeshRenderer>().material = materials[(int)material];
	}

	void GenerateMesh () 
    {
		Mesh.MeshDataArray meshDataArray = Mesh.AllocateWritableMeshData(1);
		Mesh.MeshData meshData = meshDataArray[0];

		jobs[(int)meshType](mesh, meshData, resolution, default).Complete();

		Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, mesh);

		if (meshOptimization == MeshOptimizationMode.ReorderIndices) 
        {
			mesh.OptimizeIndexBuffers();
		}
		else if (meshOptimization == MeshOptimizationMode.ReorderVertices) 
        {
			mesh.OptimizeReorderVertexBuffer();
		}
		else if (meshOptimization != MeshOptimizationMode.Nothing) 
        {
			mesh.Optimize();
		}
	}
}