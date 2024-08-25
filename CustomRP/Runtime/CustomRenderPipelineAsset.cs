using UnityEngine;
using UnityEngine.Rendering;

//改标签会让你在Project下右键->Create菜单中添加一个新的子菜单
[CreateAssetMenu(menuName = "Rendering/CreateCustomRenderPipeline")]
public class CustomRenderPipelineAsset : RenderPipelineAsset
{
  //重写一个抽象方法，需要返回一个RenderPipeline实例对象
  protected override RenderPipeline CreatePipeline()
  {
    // return null;
    return new CustomRenderPipeline();
  }

}
