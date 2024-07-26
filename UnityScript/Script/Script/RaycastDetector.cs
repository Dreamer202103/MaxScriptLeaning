using UnityEngine;  
  
public class RaycastDetector : MonoBehaviour  
{  
    void Update()  
    {  
        Ray ray = new Ray(transform.position, transform.forward); // 从当前位置向前发射射线  
        RaycastHit hit;  
  
        if (Physics.Raycast(ray, out hit, 100f)) // 检测前方100单位的距离内是否有碰撞  
        {  
            Debug.Log("Hit something at distance: " + hit.distance);  
        }  
    }  
}