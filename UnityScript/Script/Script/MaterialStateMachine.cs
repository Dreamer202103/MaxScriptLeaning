using UnityEngine;  
  
public class MaterialStateMachine : MonoBehaviour  
{  
    public enum MaterialState  
    {  
        Default,  
        Material1,  
        Material2  
    }  
  
    private MaterialState currentState;  
    public Material defaultMaterial;  
    public Material material1;  
    public Material material2;  
  
    private Renderer renderer;  
  
    void Start()  
    {  
        renderer = GetComponent<Renderer>();  
        currentState = MaterialState.Default;  
        UpdateMaterial();  
    }  
  
    void UpdateMaterial()  
    {  
        switch (currentState)  
        {  
            case MaterialState.Default:  
                renderer.material = defaultMaterial;  
                break;  
            case MaterialState.Material1:  
                renderer.material = material1;  
                break;  
            case MaterialState.Material2:  
                renderer.material = material2;  
                break;  
        }  
    }  
  
    public void ChangeToMaterial1()  
    {  
        currentState = MaterialState.Material1;  
        UpdateMaterial();  
    }  
  
    public void ChangeToMaterial2()  
    {  
        currentState = MaterialState.Material2;  
        UpdateMaterial();  
    }  
  
    public void ResetToDefault()  
    {  
        currentState = MaterialState.Default;  
        UpdateMaterial();  
    }  
}