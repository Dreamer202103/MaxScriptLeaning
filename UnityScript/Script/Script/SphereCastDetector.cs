using UnityEngine;  
  
public class SphereCastDetector : MonoBehaviour  
{  
    void Update()  
    {  
        Vector3 direction = transform.forward; // 投射方向  
        float radius = 1f; // 球体半径  
        float maxDistance = 10f; // 最大投射距离  
  
        if (Physics.SphereCast(transform.position, radius, direction, out RaycastHit hit, maxDistance))  
        {  
            Debug.Log("Hit something at distance: " + hit.distance);  
        }  
    }  
}