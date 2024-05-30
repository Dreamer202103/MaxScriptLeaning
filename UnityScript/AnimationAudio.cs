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
        stateInfo = animator.GetCurrentAnimatorStateInfo(1);
        bool t4p1a = stateInfo.IsTag("LB_Open");
        bool t4p1b = stateInfo.IsTag("LB_Close");
        // Debug.Log("0：" + t4p1a);
        if (t4p1a)
        {
            audioSource.clip = openAudio;
            audioSource.Play();
        }
        else if (t4p1b)
        {
            audioSource.clip = closeAudio;
            audioSource.Play();
        }

    }
}
