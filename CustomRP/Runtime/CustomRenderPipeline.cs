using UnityEngine;
using UnityEngine.Rendering;

public class CustomRenderPipeline : RenderPipeline
{
    //创建一个CameraRender的实例，在进行渲染时遍历所有相机进行单独渲染。
    //这种设计可以让每个相机使用不同的渲染方式绘制画面
    CameraRender renderer = new CameraRender();
    //实现抽象方法Render
    //Unity每一帧都会调用CustomRenderPipeline实例的Render()方法进行画面渲染，该方法是SRP的入口，
    //进行渲染时底层接口会调用它并传递两个参数
    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        //在进行渲染时遍历所有相机进行单独渲染。
        foreach (Camera camera in cameras)
        {
            renderer.Render(context, camera);
        }
    }

}