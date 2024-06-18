using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPropertyBlockExample : MonoBehaviour
{
    // 你可以将此字段拖入Unity编辑器中，指定要修改的材质
    // public Material targetMaterial;
    // 你可以设置颜色叠加    
    public Color _MainColor;
    public Color _RimColor;
    [Range(0f, 10f)]
    public float _Rim;
    [Range(0f, 1f)]
    public float _TransPower;
    public Texture Texture2D_5C08590B;
    [Range(0f, 1f)]
    public float Vector1_6F2AC2ED;
    public Vector4 Vector4_1;
    public Texture Texture2D_2C5B56F8;
    [Range(0f, 360f)]
    public float _UVRotation;
    public Vector4 Vector4_71C4F27B;
    public Texture Texture2D_6CF65934;
    [Range(0f, 360f)]
    public float _NormalUVRotation;
    public float Vector1_CB4B1796;
    public Texture Texture2D_8298BEC6;
    public Vector4 Vector4_2;
    public float Vector1_98D6C520;
    public Color _AOColor;
    public Cubemap _ReflectionMap;
    [Range(0f, 10f)]
    public float _Reflection_Strenth;
    [Range(0f, 10f)]
    public float _clip = 4;
    public Color _Emission;
    [Range(0f, 100f)]
    public float _LightBreathSpeed;
    [Range(0f, 1f)]
    public float _AlphaPower;
    [Range(0f, 10f)]
    public float _LightPower;
    public float _IFusing_diffuseMask;
    public float _converse_whiteblack = 1;
    public float _Flip_ReflectionMap = 1;


    private MaterialPropertyBlock propertyBlock;

    void Start()
    {
        
    }
    void Update()
    {
        // 创建一个新的MaterialPropertyBlock  
        propertyBlock = new MaterialPropertyBlock();

        // 设置你想要修改的属性  
        // 假设材质中有一个名为"_Color"的Shader属性
        propertyBlock.SetColor("_MainColor", _MainColor);
        propertyBlock.SetColor("_RimColor", _RimColor);
        propertyBlock.SetFloat("_Rim", _Rim);
        propertyBlock.SetFloat("_TransPower", _TransPower);
        if(GetComponent<Renderer>().sharedMaterial != null && Texture2D_5C08590B != null)
        {
            propertyBlock.SetTexture("Texture2D_5C08590B", Texture2D_5C08590B);
        }
        
        propertyBlock.SetFloat("Vector1_6F2AC2ED", Vector1_6F2AC2ED);
        propertyBlock.SetVector("Vector4_1", Vector4_1);
        if(GetComponent<Renderer>().sharedMaterial != null && Texture2D_2C5B56F8 != null)
        {
            propertyBlock.SetTexture("Texture2D_2C5B56F8",Texture2D_2C5B56F8);
        }
        propertyBlock.SetFloat("_UVRotation", _UVRotation);
        propertyBlock.SetVector("Vector4_71C4F27B", Vector4_71C4F27B);
        if(GetComponent<Renderer>().sharedMaterial != null && Texture2D_6CF65934 != null)
        {
            propertyBlock.SetTexture("Texture2D_6CF65934", Texture2D_6CF65934);
        }
        

        propertyBlock.SetFloat("_NormalUVRotation", _NormalUVRotation);
        propertyBlock.SetFloat("Vector1_CB4B1796", Vector1_CB4B1796);
        if(GetComponent<Renderer>().sharedMaterial != null && Texture2D_8298BEC6 != null)
        {
            propertyBlock.SetTexture("Texture2D_8298BEC6", Texture2D_8298BEC6);
        }
        propertyBlock.SetVector("Vector4_2", Vector4_2);
        propertyBlock.SetFloat("Vector1_98D6C520", Vector1_98D6C520);
        propertyBlock.SetColor("_AOColor", _AOColor);
        if(GetComponent<Renderer>().sharedMaterial != null && _ReflectionMap != null)
        {
            propertyBlock.SetTexture("_ReflectionMap", _ReflectionMap);
        }
        
        propertyBlock.SetFloat("_Reflection_Strenth", _Reflection_Strenth);

        propertyBlock.SetFloat("_clip", _clip);
        propertyBlock.SetColor("_Emission", _Emission);
        propertyBlock.SetFloat("_LightBreathSpeed", _LightBreathSpeed);
        propertyBlock.SetFloat("_AlphaPower", _AlphaPower);
        propertyBlock.SetFloat("_LightPower", _LightPower);
        propertyBlock.SetFloat("_IFusing_diffuseMask", _IFusing_diffuseMask);
        propertyBlock.SetFloat("_converse_whiteblack", _converse_whiteblack);
        propertyBlock.SetFloat("_Flip_ReflectionMap", _Flip_ReflectionMap);

        // 你可以设置更多的属性，比如：  
        // propertyBlock.SetTexture("_MainTex", yourTexture);  
        // propertyBlock.SetFloat("_Offset", 0.5f);  

        // 应用MaterialPropertyBlock到渲染器  
        GetComponent<Renderer>().SetPropertyBlock(propertyBlock);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     // propertyBlock = new MaterialPropertyBlock();
    //     GetComponent<Renderer>().GetPropertyBlock(propertyBlock);
    //     propertyBlock.SetColor("_MainColor", _MainColor);
    //     propertyBlock.SetColor("_RimColor", _RimColor);
    //     propertyBlock.SetFloat("_Rim", _Rim);
    //     propertyBlock.SetFloat("_TransPower", _TransPower);
    //     propertyBlock.SetTexture("Texture2D_5C08590B", Texture2D_5C08590B);
    //     propertyBlock.SetFloat("Vector1_6F2AC2ED", Vector1_6F2AC2ED);
    //     propertyBlock.SetVector("Vector4_1", Vector4_1);
    //     // propertyBlock.SetTexture("Texture2D_2C5B56F8",Texture2D_2C5B56F8);
    //     propertyBlock.SetFloat("_UVRotation", _UVRotation);
    //     propertyBlock.SetVector("Vector4_71C4F27B", Vector4_71C4F27B);
    //     propertyBlock.SetTexture("Texture2D_6CF65934", Texture2D_6CF65934);

    //     propertyBlock.SetFloat("_NormalUVRotation", _NormalUVRotation);
    //     propertyBlock.SetFloat("Vector1_CB4B1796", Vector1_CB4B1796);
    //     // propertyBlock.SetTexture("Texture2D_8298BEC6", Texture2D_8298BEC6);
    //     propertyBlock.SetVector("Vector4_2", Vector4_2);
    //     propertyBlock.SetFloat("Vector1_98D6C520", Vector1_98D6C520);
    //     propertyBlock.SetColor("_AOColor", _AOColor);
    //     propertyBlock.SetTexture("_ReflectionMap", _ReflectionMap);
    //     propertyBlock.SetFloat("_Reflection_Strenth", _Reflection_Strenth);

    //     propertyBlock.SetFloat("_clip", _clip);
    //     propertyBlock.SetColor("_Emission", _Emission);
    //     propertyBlock.SetFloat("_LightBreathSpeed", _LightBreathSpeed);
    //     propertyBlock.SetFloat("_AlphaPower", _AlphaPower);
    //     propertyBlock.SetFloat("_LightPower", _LightPower);
    //     propertyBlock.SetFloat("_IFusing_diffuseMask", _IFusing_diffuseMask);
    //     propertyBlock.SetFloat("_converse_whiteblack", _converse_whiteblack);
    //     propertyBlock.SetFloat("_Flip_ReflectionMap", _Flip_ReflectionMap);

    //     transform.GetComponent<Renderer>().SetPropertyBlock(propertyBlock);
    // }

    // 如果你想要在游戏中动态改变这些属性，可以在Update或其他函数中调用以下函数  
    /*
    public void ChangeColor()
    {
        // _MainColor = newColor;
        propertyBlock.SetColor("_MainColor", _MainColor);
        propertyBlock.SetColor("_RimColor", _RimColor);
        propertyBlock.SetFloat("_Rim", _Rim);
        propertyBlock.SetFloat("_TransPower", _TransPower);
        propertyBlock.SetTexture("Texture2D_5C08590B", Texture2D_5C08590B);
        propertyBlock.SetFloat("Vector1_6F2AC2ED", Vector1_6F2AC2ED);
        propertyBlock.SetVector("Vector4_1", Vector4_1);
        propertyBlock.SetTexture("Texture2D_2C5B56F8",Texture2D_2C5B56F8);
        propertyBlock.SetFloat("_UVRotation", _UVRotation);
        propertyBlock.SetVector("Vector4_71C4F27B", Vector4_71C4F27B);
        propertyBlock.SetTexture("Texture2D_6CF65934", Texture2D_6CF65934);

        propertyBlock.SetFloat("_NormalUVRotation", _NormalUVRotation);
        propertyBlock.SetFloat("Vector1_CB4B1796", Vector1_CB4B1796);
        propertyBlock.SetTexture("Texture2D_8298BEC6", Texture2D_8298BEC6);
        propertyBlock.SetVector("Vector4_2", Vector4_2);
        propertyBlock.SetFloat("Vector1_98D6C520", Vector1_98D6C520);
        propertyBlock.SetColor("_AOColor", _AOColor);
        propertyBlock.SetTexture("_ReflectionMap", _ReflectionMap);
        propertyBlock.SetFloat("_Reflection_Strenth", _Reflection_Strenth);

        propertyBlock.SetFloat("_clip", _clip);
        propertyBlock.SetColor("_Emission", _Emission);
        propertyBlock.SetFloat("_LightBreathSpeed", _LightBreathSpeed);
        propertyBlock.SetFloat("_AlphaPower", _AlphaPower);
        propertyBlock.SetFloat("_LightPower", _LightPower);
        propertyBlock.SetFloat("_IFusing_diffuseMask", _IFusing_diffuseMask);
        propertyBlock.SetFloat("_converse_whiteblack", _converse_whiteblack);
        propertyBlock.SetFloat("_Flip_ReflectionMap", _Flip_ReflectionMap);

        GetComponent<Renderer>().SetPropertyBlock(propertyBlock);
    }
    */
}
