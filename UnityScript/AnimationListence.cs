using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class AnimationListence : MonoBehaviour
{
    public int layerIndex = 0;
    private Animator animator;
    AnimatorClipInfo[] m_AnimatorClipInfo;
    AnimatorControllerPlayable animatorControllerPlayable;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 获取动画层的数量 
        int numLayers = animator.layerCount;
        Debug.Log("动画长度是：" + numLayers);
        for (int i = 0; i < numLayers; i++)
        {
            // Debug.Log(animator.layerIndex + "" + i);
        }

        //返回当前状态中 AnimatorClipInfo 的数量。
        // int monentLayer = animatorControllerPlayable.GetCurrentAnimatorClipInfoCount(layerIndex);
        // 获取当前动画状态的信息  
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
        float animationLength = (float)stateInfo.length;
        Debug.Log("动画长度是：" + animationLength);

        //Get the animator clip information from the Animator Controller
        //从这个动画控制器中获取动画剪辑信息
        m_AnimatorClipInfo = animator.GetCurrentAnimatorClipInfo(layerIndex);
        //Output the name of the starting clip
        //輸出的名名字是正在播放的動畫
        Debug.Log("动画剪辑信息是：" + m_AnimatorClipInfo[0].clip.name);
        // Debug.Log("但前动画层的AnimatorClipInfo数量：" + monentLayer);
        // if(m_AnimatorClipInfo[0].clip.name == "weipai_gaoshan_2024_140km_LF_Open")
        // {

        // }
        // }

    }

}
