using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SimpleProceduralMesh : MonoBehaviour 
{
	/*
		在Unity中，OnEnable是一个特殊的函数（或称为回调方法），它在MonoBehaviour组件的实例被激活时自动调用。Unity中的MonoBehaviour是大多数Unity脚本的基类，
		它提供了一系列用于游戏对象交互的内置函数和属性。
		当一个MonoBehaviour组件被添加到游戏对象上，或者当游戏对象被激活（例如，通过SetActive(true)方法）时，OnEnable函数会被自动调用。
		这个函数的主要用途是初始化那些只在组件启用时才需要的资源或状态，或者执行那些每次组件启用时都应该运行的代码。
		与Start函数不同，Start只在MonoBehaviour组件的第一次激活时调用一次（即游戏对象第一次被激活或MonoBehaviour组件第一次被添加到游戏对象上时），
		而OnEnable会在每次组件被激活时调用。这意味着，如果游戏对象被禁用然后再次启用，OnEnable会再次被调用，而Start则不会。
		此外，当游戏对象被销毁时，Unity会自动调用OnDisable函数（与OnEnable相对应），这可以用于清理资源或执行其他清理工作。
	*/
	void OnEnable () 
	{
		
		/*
			Unity中，这段代码创建了一个新的mesh对象，并给它设置了一个名字“Procedural Mesh”。
			Mesh是Unity中一个非常重要的类，用于表示三维空间中的几何形状，由顶点(Vertices)、三角形(Triangles)、法线(Normals)、UV坐标(UVs)等构成。
			它是渲染系统用来在屏幕上绘制三维物体的基础数据。
		*/
		// var 关键字：在C#中，var关键字用于隐式类型局部变量声明，编译器会根据右侧表达式的结果推断出变量的类型。
		// new Mesh{...}:这部分代码使用new关键字创建了一个Mesh类型的实例。Mesh类提供了多种方法和属性来定义和操作三维形状。

		var mesh = new Mesh
		{
			/*
				对象初始化器：{ name = "Procedural Mesh" }是一个对象初始化器的例子。它允许在创建对象时立即设置对象的属性。在这个例子中，
				它设置了Mesh对象的name属性为"Procedural Mesh"。
				虽然这个属性对于Mesh的渲染或物理行为没有直接影响，但它可以帮助开发者在Unity的Inspector面板中识别或区分不同的Mesh对象。
			*/
			name = "Procedural Mesh"
		};

		mesh.vertices = new Vector3[] 
		{
			Vector3.zero, Vector3.right, Vector3.up, new Vector3(1f, 1f)
		};

		mesh.normals = new Vector3[] 
		{
			Vector3.back, Vector3.back, Vector3.back, Vector3.back
		};

		mesh.tangents = new Vector4[] 
		{
			new Vector4(1f, 0f, 0f, -1f),
			new Vector4(1f, 0f, 0f, -1f),
			new Vector4(1f, 0f, 0f, -1f),
			new Vector4(1f, 0f, 0f, -1f)
		};

		mesh.uv = new Vector2[] 
		{
			Vector2.zero, Vector2.right, Vector2.up, Vector2.one
		};

		mesh.triangles = new int[] 
		{
			0, 2, 1, 1, 2, 3
		};

		GetComponent<MeshFilter>().mesh = mesh;
	}
}