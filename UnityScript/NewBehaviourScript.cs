using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NewBehaviourScript : EditorWindow
{
    [MenuItem("DreamerTools/NewBehaviourScript", false, 99)]
    static public void ShowNewBehaviourScript()
    {
        EditorWindow.GetWindow(typeof(NewBehaviourScript));
    }

    public void OnGUI()
    {
        if (GUILayout.Button("MaterialFind"))
        {
            Renderer[] render = Selection.activeGameObject.GetComponentsInChildren<Renderer>();
            for(int i = 0; i < render.Length;i++)
            {
                Renderer r = render[i];
                if(r.name != "Wheel_LF_Caliper")
                {
                    Debug.Log(r.name);
                }
            }
        }

    }
}
