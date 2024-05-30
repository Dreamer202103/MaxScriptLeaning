using UnityEngine;  
  
public class AnimationExample : MonoBehaviour  
{  
    private Animator animator;  
  
    void Start()  
    {  
        animator = GetComponent<Animator>();  
        AnimatorClipInfo[] clipInfos = animator.GetCurrentAnimatorClipInfo(0); // 获取基础层的动画剪辑信息  
  
        if (clipInfos.Length > 0)  
        {  
            AnimationClip currentClip = clipInfos[0].clip; // 假设只有一个动画剪辑正在播放  
            Debug.Log("当前播放的动画剪辑名称: " + currentClip.name);  
        }  
    }  
}