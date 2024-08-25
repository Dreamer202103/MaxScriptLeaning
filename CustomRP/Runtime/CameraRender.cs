using UnityEngine;
using UnityEngine.Rendering;

public class CameraRender
{
    ScriptableRenderContext context;
    Camera camera;
    //CommandBuffer实例来获得缓冲区，我们只需要一个缓冲区即可。
    //实例化时定义一个bufferName给缓冲区起个名字，用于在Frame Debuger中识别它。
    const string bufferName = "Render Camewra";
    CommandBuffer buffer = new CommandBuffer
    {
        name = bufferName
    };
    public void Render(ScriptableRenderContext context, Camera camera)
    {
        this.context = context;
        this.camera = camera;
        Setup();
        DrawVisibleGeometry();
        Submit();
    }
    /// <summary>
    /// 设置相机的属性矩阵
    /// </summary>
    void Setup()
    {
        //我们可以通过命令缓冲区的BeginSample和EndSample方法进行开启采样过程，这样在Profiler和Frame Debugger中就能进行显示，
        //通常放在这个渲染过程的开始和结束，传参就用命令缓冲区的名字。
        //执行缓冲区命令是通过contex。ExecuteCommandBuffer(buffer)来执行，这个操作会从缓冲区复制命令，但不会清楚缓冲区，
        //我们如果要重复用buffer，一般会在执行完该命令后调用Clear()清除。
        //通过执行命令和清除缓冲区是一起执行的，我们封装成一个ExecuteBuffer方法用来更方便地调用。
        buffer.BeginSample(bufferName);
        ExecuteBuffer();
        context.SetupCameraProperties(camera);
    }

    /// <summary>
    /// 绘制可见物
    /// </summary>
    void DrawVisibleGeometry()
    {
        //设置相机属性和矩阵
        context.DrawSkybox(camera);
    }
    /// <summary>
    /// 提交缓冲区渲染命令
    /// </summary>
    void Submit()
    {
        buffer.EndSample(bufferName);
        ExecuteBuffer();
        context.Submit();
    }
    //我们封装成一个ExecuteBuffer方法用来更方便地调用
    void ExecuteBuffer()
    {
        context.ExecuteCommandBuffer(buffer);
        buffer.Clear();
    }
}
