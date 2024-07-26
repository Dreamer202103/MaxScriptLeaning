using UnityEngine;  
  
public class OverlapSphereDetector : MonoBehaviour  
{  
    void Update()  
    {  
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f); // 检测以当前位置为中心，半径为5的球体范围内的Collider  
  
        foreach (Collider collider in colliders)  
        {  
            float distance = Vector3.Distance(transform.position, collider.transform.position);  
            Debug.Log("Overlapping object at distance: " + distance);  
        }  
    }  
}
