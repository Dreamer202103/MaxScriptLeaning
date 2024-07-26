using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUInstancing : MonoBehaviour
{
    [Header("生成對象")]
    public GameObject Prefab;
    [Header("生成對象的數量")]
    public int Count;
    [Header("生成對象的範圍")]
    public float Range;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0;i < Count;i++)
        {
            Vector2 pos = Random.insideUnitCircle * Range;
            Instantiate(Prefab, new Vector3(pos.x,0,pos.y), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
