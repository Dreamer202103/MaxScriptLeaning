using UnityEngine;  
using System.Collections;
  
public class AnimationListener : MonoBehaviour  
{  
    private Animator animator;  
  
    void Start()  
    {  
        // 获取Animator组件  
        animator = GetComponent<Animator>();  
  
        // 假设我们关心的是基础层（索引为0）  
        int layerIndex = 0;  
  
        // 你可以在这里设置一个定时器或者监听某个事件来定期调用打印函数  
        // 例如，在Update方法中  
        StartCoroutine(PrintCurrentAnimationName(layerIndex));  
    }  
  
    IEnumerator PrintCurrentAnimationName(int layerIndex)  
    {  
        while (true)  
        {  
            // 获取当前动画状态的信息  
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
            if(stateInfo.IsName("")); 
            // stateInfo.fullPathHash.ToString()

            // 打印动画状态的名字  
            // Debug.Log("当前播放的动画状态名字: " + Animator.StringToHash(stateInfo.name.ToString()));  
            // animator.GetCurrentAnimatorClipInfo(0)[1].clip.name
            // 或者，如果你想要直接打印出名字（注意这可能会因为名字冲突而不够准确）  
            // Debug.Log("当前播放的动画状态名字: " + stateInfo.name);  
  
            // 等待一段时间再次检查  
            yield return new WaitForSeconds(0.5f); // 每0.5秒打印一次  
        }  
    }  
}