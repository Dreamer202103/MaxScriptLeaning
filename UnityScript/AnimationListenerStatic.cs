using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AnimationListenerStatic : EditorWindow
{
    [MenuItem("DreamerTools/Animation Listener", false, 6)]
    static void ShowAnimationListener()
    {
        var window = GetWindow<AnimationListenerStatic>();
        window.Show();
    }

    private GameObject model;
    private Animator animator;
    private string currentAnimationName;
    AnimatorClipInfo[] m_CurrentClipInfo;
    void OnGUI()
    {
        GUILayout.Label("请将CarShow预制体拖入下方:");
        model = EditorGUILayout.ObjectField(model, typeof(GameObject), true) as GameObject;
        if (GUILayout.Button("Animation Listener"))
        {
            
            animator = model.GetComponent<Animator>();
            AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
            string currentAnimation = currentState.fullPathHash.ToString();
            //GetCurrentAnimatorClipInfo返回值是一个 AnimatorClipInfo[] 类型的数组，这个数组包含了当前状态中所有 AnimatorClipInfo 的信息
            // m_CurrentClipInfo = animator.GetCurrentAnimatorClipInfo(1);
            // string m_ClipName = m_CurrentClipInfo[1].clip.name;
            // Debug.Log("Now playing: " + animator.GetCurrentAnimatorClipInfo(0)[1].clip.name);
            // Debug.Log("动画的名字是：" + m_ClipName);
            // Debug.Log(currentAnimation);
            // 检查动画是否播放完毕  
            // if (currentState.normalizedTime >= 1.0f)
            // {
            //     Debug.Log("Animation finished: " + animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
            //     // 动画播放完毕时的逻辑  
            // }
        }
    }
}
