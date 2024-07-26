using System;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class HashSetStruct : MonoBehaviour  
{  
    private HashSet<string> uniqueStrings = new HashSet<string>();  
  
    void Start()  
    {  
        // 添加元素到 HashSet  
        uniqueStrings.Add("Apple");  
        uniqueStrings.Add("Banana");  
        uniqueStrings.Add("Apple"); // 不会被添加，因为 "Apple" 已经存在  
  
        // 遍历 HashSet  
        foreach (var item in uniqueStrings)  
        {  
            Debug.Log(item);  
        }  
  
        // 检查元素是否存在  
        bool containsBanana = uniqueStrings.Contains("Banana");  
        Debug.Log("Contains Banana: " + containsBanana);  
  
        // 移除元素  
        uniqueStrings.Remove("Banana");  
    }  
}