using UnityEngine;  
  
public class TriggerDetector : MonoBehaviour  
{  
    private void OnTriggerEnter(Collider other)  
    {  
        float distance = Vector3.Distance(transform.position, other.transform.position);  
        Debug.Log("Object entered trigger at distance: " + distance);  
    }  
}