using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace MaterialSet
{
    public enum MaterialState
    {
        Default,
        Runing
    }



    [System.Serializable]
    public class MeshMaterialPair
    {
        public GameObject gameObject;
        public Material Defaultaterial;
        public Material RuningMaterial;

    }

    public class MaterialManager : MonoBehaviour
    {
        private MaterialState MaterialState;

        [Header("双闪灯")]

        public List<MeshMaterialPair> gameObjectMaterialPairs = new List<MeshMaterialPair>();
        [Header("左")]

        public List<MeshMaterialPair> gameObjectMaterialPairs1 = new List<MeshMaterialPair>();
        [Header("右面")]

        public List<MeshMaterialPair> gameObjectMaterialPairs2 = new List<MeshMaterialPair>();
        [Header("日行")]

        public List<MeshMaterialPair> gameObjectMaterialPairs3 = new List<MeshMaterialPair>();

        void UpdateMaterial(List<MeshMaterialPair> values,MaterialState MaterialState)
        {
            switch (MaterialState)
            {
                case MaterialState.Default:
                    for (int i = 0; i < values.Count; i++)
                    {
                        values[i].gameObject.GetComponent<MeshRenderer>().sharedMaterial = values[i].Defaultaterial;

                    }
                    break;
                case MaterialState.Runing:
                    for (int i = 0; i < values.Count; i++)
                    {
                        values[i].gameObject.GetComponent<MeshRenderer>().sharedMaterial = values[i].RuningMaterial;

                    }
                    break;
            }
        }

        public void SetOnShuang()
        {
            UpdateMaterial(gameObjectMaterialPairs,MaterialState.Runing);
        }
        public void SetOfShuang()
        {
            UpdateMaterial(gameObjectMaterialPairs,MaterialState.Default);
        }
        public void SetOnLeft()
        {
            UpdateMaterial(gameObjectMaterialPairs1,MaterialState.Runing);
        }
        public void SetOfLeft()
        {
            UpdateMaterial(gameObjectMaterialPairs1,MaterialState.Default);
        }
        public void SetOnRight()
        {
            UpdateMaterial(gameObjectMaterialPairs2,MaterialState);
        }

        public void SetOnLight()
        {
            UpdateMaterial(gameObjectMaterialPairs3,MaterialState.Runing);
        }
        public void SetOfLight()
        {
            UpdateMaterial(gameObjectMaterialPairs3,MaterialState.Default);
        }

        public Button myButton; // 引用你的Button组件  
        public Button myButton1; 
        public Button myButton2;
        private bool buttonClicked = false; // 跟踪按钮是否被点击  

        void Start()
        {
            // 为按钮的onClick事件添加监听器  
            
        }

        // 按钮点击时调用的方法  
        public void OnButtonClick()
        {
            buttonClicked = true; // 设置标志为true，表示按钮已被点击  
                                  // 执行点击时的命令  
            SetOfShuang();
            Debug.Log("Button was clicked!");
            // 这里可以添加更多点击时的逻辑  

            // 假设你只想在第一次点击时执行某些操作，之后不再执行  
            // 那么你可以在这里取消监听，或者设置另一个标志来阻止重复执行  
        }

        // Update is called once per frame  
        public void Update()
        {
            if (myButton != null)
            {
                myButton.onClick.AddListener(SetOnShuang);
                myButton.onClick.RemoveListener(SetOfShuang);
            }
            if (myButton1 != null)
            {
                myButton1.onClick.AddListener(SetOnLeft);
                myButton.onClick.RemoveListener(SetOfLeft);
            }
            if(myButton2 != null)
            {
                myButton2.onClick.AddListener(SetOnLight);
                myButton2.onClick.RemoveListener(SetOfLight);
            }
            // 这里检查按钮是否“没被点击”，但请注意这不是直接监听“没被点击”事件  
            // 而是通过标志来间接实现  
            if (!buttonClicked)
            {
                SetOfShuang();
                // 执行没被点击时的命令  
                // 但请注意，由于Update在每帧都会调用，这可能会导致性能问题  
                // 或者不必要的重复执行。因此，你可能需要添加额外的逻辑来限制执行次数  
                Debug.Log("Button has not been clicked yet.");
                // 这里可以添加更多没被点击时的逻辑  
            }

            // 注意：在实际应用中，你可能不需要在Update中检查按钮的点击状态  
            // 除非你有特定的需求（如超时未点击执行某操作）  
        }


    }
}