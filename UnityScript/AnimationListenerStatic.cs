using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AnimationListenerStatic : EditorWindow
{
    [MenuItem("DreamerTolls/Animation Listener", false, 0)]
    static void ShowAnimationListener()
    {
        var window = GetWindow<AnimationListenerStatic>();
        window.Show();
    }

    private GameObject model;
    private Animator animator;
    private string currentAnimationName;
    void OnGUI()
    {
        GUILayout.Label("请将CarShow预制体拖入下方:");
        model = EditorGUILayout.ObjectField(model, typeof(GameObject), true) as GameObject;
        if (GUILayout.Button("Animation Listener"))
        {
            
            animator = model.GetComponent<Animator>();
            AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
            string currentAnimation = currentState.fullPathHash.ToString();
            Debug.Log("Now playing: " + animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
            Debug.Log(currentAnimation);
            // 检查动画是否播放完毕  
            if (currentState.normalizedTime >= 1.0f)
            {
                Debug.Log("Animation finished: " + animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
                // 动画播放完毕时的逻辑  
            }
        }
    }
}
