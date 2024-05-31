using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudio : MonoBehaviour
{
    
    public AudioSource audioSource;
    public AudioClip openAudio;
    public AudioClip closeAudio;
    private Animator animator;

    AnimatorStateInfo stateInfo;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int layerIndex0 = 0; layerIndex0 < animator.layerCount; layerIndex0++)
        {
            
            // 检查该层上是否有动画正在播放  
            if (stateInfo.length > 0f && stateInfo.normalizedTime < 1f)
            {

                // bool t4p1a = stateInfo.IsTag("LB_Open");
                // bool t4p1b = stateInfo.IsTag("LB_Close");
                // Debug.Log("0：" + t4p1a);

            }
        }
        stateInfo = animator.GetCurrentAnimatorStateInfo(1);

        
        // if (stateInfo.IsTag("LB_Open") == false)
        // {
        //     audioSource.clip = openAudio;
        //     audioSource.Play();
        // }
        if (stateInfo.IsTag("LB_Close") == false)
        {
            audioSource.clip = closeAudio;
            audioSource.Play();
        }
        // else
        // {

        //     Debug.Log("动画还没有运行哦。");
        // }

    }
}
