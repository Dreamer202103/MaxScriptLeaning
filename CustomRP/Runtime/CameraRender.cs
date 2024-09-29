using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

/*
    虽然我们可以在CustomRenderPipeline中渲染所有的相机，但是由于每个相机的渲染都是独立的，不如创建一个相机管理类去进行每个相机单独的渲染
    而且后续功能越来越多，这样做能够让代码更具有可读性且易管理。
*/
public class CameraRender
{
    //对传递来的渲染接口ScriptRenderContext和当前相机Camera的对象进行存储追踪。
    /*
    定义：
        ScripttableRenderContext:是Unity引擎中用于定义渲染管线(Scripttable Render Pipeline,SRP)
        的一个重要类。它充当了C# SRP代码和Unity低级图形代码之间的接口，允许开发者通过C#脚本组织和控
        制渲染命令的执行。
    功能：
        1.组织和执行渲染命令：ScripttableRenderContext负责接收一系列图形命令，这些命令不会立即执行。
          而是等待开发者可以通过这个类GPU调度和提交状态更新及绘制命令。
        2.渲染管理：通过ScripttableRenderContext,开发者可以管理渲染状态，如全局着色器属性，渲染目标等。
    */
    ScriptableRenderContext context;
    Camera camera;
    /*
        CommandBuffer实例来获得缓冲区，我们只需要一个缓冲区即可。
        实例化时定义一个bufferName给缓冲区起个名字，用于在Frame Debuger中识别它。
    */
    const string bufferName = "Render Camera";
    CommandBuffer buffer = new CommandBuffer
    {
        name = bufferName
    };

    //存储剔除后的结果数据
    CullingResults cullingResults;
    static ShaderTagId unlitShaderTagId = new ShaderTagId("SRPDefaultUnlit");


    /// <summary>
    /// 定义一个相机的Render方法，用来绘制在相机视野内的所有物体。
    /// </summary>
    /// <param name="context"></param>
    /// <param name="camera"></param>
    public void Render(ScriptableRenderContext context, Camera camera)
    {
        this.context = context;
        this.camera = camera;
        if (!Cull())
        {
            return;
        }
        //在渲染前调用SetUp()方法
        Setup();
        DrawVisibleGeometry();
        //绘制SRP不支持的内置shader类型
        // DrawUnsupportedShaders();
        //绘制Gizmos
        // DrawGizmos();
        Submit();
    }

    /// <summary>
    /// 设置相机的属性矩阵
    /// </summary>
    void Setup()
    {
        /*
            设置相机属性和矩阵
            还需要设置视图-投影变换矩阵，此转换矩阵结合了摄像机的位置和方向(视图矩阵)与摄像机的透视或正交投影(投影矩阵)。
            Shader中这个属性叫unity_MatrixVP。是绘制几何图形时所用的Shader属性之一。
        */
        context.SetupCameraProperties(camera);
        /*
           前两个参数用来设置是否需要清除深度数据和颜色数据，
           第三个参数设置清除颜色数据的颜色。
       */
        buffer.ClearRenderTarget(true, true, Color.clear);
        /*
            我们可以通过命令缓冲区的BeginSample和EndSample方法进行开启采样过程，这样在Profiler和Frame Debugger中就能进行显示，
            通常放在这个渲染过程的开始和结束，传参就用命令缓冲区的名字。
            执行缓冲区命令是通过contex。ExecuteCommandBuffer(buffer)来执行，这个操作会从缓冲区复制命令，但不会清楚缓冲区，
            我们如果要重复用buffer，一般会在执行完该命令后调用Clear()清除。
            通过执行命令和清除缓冲区是一起执行的，我们封装成一个ExecuteBuffer方法用来更方便地调用。
        */
        buffer.BeginSample(bufferName);
        ExecuteBuffer();

    }

    /*
        当剔除裁剪完毕，我们就知道需要渲染那些可见物体了。接下来就开始正式绘制，通过调用context.DrawRenderers方法来实现。
        它需要三个参数，除了上面的CullingResults，还需要一个DrawingSetting绘制设置和FileteringSettings，我们先用默认的设置，
        绘制物体的操作放在DrawVisibleGeometry()方法中的绘制天空盒之前完成。
    */
    /// <summary>
    /// 绘制几何体
    /// </summary>
    void DrawVisibleGeometry()
    {
        /*
            现在我们还是看不到有物体被绘制在屏幕上，因为我们还需要再DrawingSettings中设置是哪个Shader的哪个Pass进行渲染。
            在SRP中，旧的着色器大部分基本不能再使用，但没有光照的内置着色器Unlit被保留下来，
            我们需要获取Pass名字为SRPSefaultUnlit的着色器标识ID，在最外部定义好后作为参数传入DrawingSettings中。

            我们还需要传入第二个参数，类型是SortSeetings。创建对象的时候把相机作为参数出入进来。该排序设置的作用是确定相机的透明排序模式
            是否使用正交或基于距离的排序。如果单单这样设置，就会发现绘制的顺序没有规律的，我们通过设置排序的条件来让他有序地绘制物体。
            目前我们暂时使用不透明对象的典型排序模式SortingCriteria.CommonOpaque来设置。

            最后我们还需要设置FilteringSettings，用于过滤给定的一组可见对象以便渲染，我们使用RenderQueueRange.all来渲染所有渲染队列内的对象
        */
        //设置绘制顺序和指定渲染相机
        var sortingSettings = new SortingSettings(camera)
        {
            criteria = SortingCriteria.CommonOpaque
        };
        //设置渲染的shader pass和渲染排序
        var drawingSettings = new DrawingSettings(unlitShaderTagId, sortingSettings);
        ////只绘制RenderQueue为opaque不透明的物体
        var filteringSettings = new FilteringSettings(RenderQueueRange.opaque);
        //1.绘制不透明物体
        context.DrawRenderers(cullingResults, ref drawingSettings, ref filteringSettings);
        // var drawingSettings = new DrawingSettings();
        // var filteringSettings = new FilteringSettings();
        //图像绘制
        // context.DrawRenderers(cullingResults, ref drawingSettings, ref filteringSettings);

        /*
            通过调用ScriptableRenderContext渲染接口的DrawSkybox()来绘制一个天空盒子。
            但是到此还不行，因为通过context发送的渲染命令都是缓冲的，最后需要通过调用Submit()方法正式提交渲染命令。
            设置相机属性和矩阵
        */
        context.DrawSkybox(camera);

        sortingSettings.criteria = SortingCriteria.CommonTransparent;
        drawingSettings.sortingSettings = sortingSettings;
        //只绘制RenderQueue为transparent透明的物体
        filteringSettings.renderQueueRange = RenderQueueRange.transparent;
        //3.绘制透明物体
        context.DrawRenderers(cullingResults, ref drawingSettings, ref filteringSettings);
    }
    /// <summary>
    /// 提交缓冲区渲染命令
    /// </summary>
    void Submit()
    {
        buffer.EndSample(bufferName);
        ExecuteBuffer();
        //Submit()方法提交渲染命令
        context.Submit();
    }
    //我们封装成一个ExecuteBuffer方法用来更方便地调用
    void ExecuteBuffer()
    {
        context.ExecuteCommandBuffer(buffer);
        buffer.Clear();
    }

    /*
        我们只需要渲染在相机视野内的物体，视野外的物体需要剔除掉。
        这一步主要通过camera.TryGetCullingParameters方法得到需要进行剔除检查的所有物体，
        正式的剔除通过context.Cull()实现的，最后会返回一个CullingResults，里面存储了我们相机剔除后的所有
        视野内可见物体的数据信息。我们建议定义一个Cull来完成这个工作，然后在相机渲染Render()的最开始调用剔除操作。
    */
    /// <summary>
    /// 剔除
    /// </summary>
    /// <returns></returns>
    bool Cull()
    {
        ScriptableCullingParameters p;
        if (camera.TryGetCullingParameters(out p))
        {
            cullingResults = context.Cull(ref p);
            return true;
        }
        return false;
    }
}
