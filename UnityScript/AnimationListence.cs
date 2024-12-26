using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;


public class AnimationListence : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip openAudio;
    public AudioClip closeAudio;
    private int layerIndex;
    private Animator animator;
    AnimatorClipInfo[] m_AnimatorClipInfo;
    AnimatorControllerPlayable animatorControllerPlayable;
    AnimatorStateInfo stateInfo;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 获取动画层的数量 
        // int numLayers = animator.layerCount;
        // Debug.Log("动画长度是：" + numLayers);

        for (int layerIndex0 = 0; layerIndex0 < animator.layerCount; layerIndex0++)
        {
            stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex0);

            // 检查该层上是否有动画正在播放  
            if (stateInfo.length > 0f && stateInfo.normalizedTime < 1f)
            {
                layerIndex = layerIndex0;
                Debug.Log("Layer " + layerIndex + " 上有动画正在播放");
                //返回当前状态中 AnimatorClipInfo 的数量。
                // int monentLayer = animatorControllerPlayable.GetCurrentAnimatorClipInfoCount(layerIndex);
                // 获取当前动画状态的信息  
                // stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
                float animationLength = (float)stateInfo.length;
                Debug.Log("动画长度是：" + animationLength);

                //Get the animator clip information from the Animator Controller
                //从这个动画控制器中获取动画剪辑信息
                m_AnimatorClipInfo = animator.GetCurrentAnimatorClipInfo(layerIndex);
                bool l = animator.GetBool("LB_Open");

                Debug.Log("5" + l);
                // if (animator.GetBool("weipai_gaoshan_2024_140km_LB_Open"))
                // {
                //     audioSource.clip = openAudio;
                //     audioSource.Play();
                // }

                if (m_AnimatorClipInfo[0].clip.name == "zeekr_mix_2024_LB_Open")
                {

                    // animator.SetTrigger("LB_Open");

                    audioSource.clip = openAudio;
                    audioSource.Play();
                    Debug.Log("播放开门声音");
                }
                else if (m_AnimatorClipInfo[0].clip.name == "weipai_gaoshan_2024_140km_LB_Close")
                {
                    audioSource.clip = closeAudio;
                    audioSource.Play();
                    Debug.Log("播放关门声音");
                }
                //Output the name of the starting clip
                //輸出的名名字是正在播放的動畫
                Debug.Log("动画剪辑信息是：" + m_AnimatorClipInfo[0].clip.name);
                // 如果需要的话，这里可以获取更多关于当前动画状态的信息  
                // 例如，打印出当前动画状态的名字  
                // Debug.Log("当前动画状态名: " + stateInfo.fullNameHash);
                // 退出循环，因为我们已经找到了一个正在播放的动画  
                // break;
            }
        }


    }

    private void OnMouseDown()
    {
        audioSource.clip = openAudio;
        audioSource.Play();
    }
}
