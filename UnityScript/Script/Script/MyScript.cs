using UnityEngine;
using System.Collections;
using UnityEditor.Rendering;

namespace MaterialSet
{
    public class MyScript : MonoBehaviour
    {
        public MaterialState MaterialState;
        // 这个方法将在按钮被点击时调用  
        public void OnButtonClick()
        {
            MaterialManager a = new MaterialManager();
            a.SetOnLeft();
            
            
            Debug.Log("按钮被点击了！");
            // 在这里添加你想要的任何逻辑  
        }
    }
}