using UnityEngine;
using UnityEngine.Rendering;

public class CameraRender
{
    ScriptableRenderContext context;
    Camera camera;
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
        context.SetupCameraProperties(camera);
    }

    /// <summary>
    /// 绘制可见物
    /// </summary>
    void DrawVisibleGeometry()
    {
        context.DrawSkybox(camera);
    }
    /// <summary>
    /// 提交缓冲区渲染命令
    /// </summary>
    void Submit()
    {
        context.Submit();
    }
}
