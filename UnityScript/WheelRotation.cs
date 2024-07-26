using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    // 车轮旋转速度
    public float rotationSpeed = 100f;
    //车轮的半径
    public float wheelRadius = 17;
    private Rigidbody rb;

    private float keyPressStartTime = -1f; // 按键开始按下的时间  
    private float keyPressDuration = 0f; // 按键被按下的时长  
    void Start()
    {
        // 获取车辆主体的Rigidbody组件
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 获取前进和转弯的输入  
        float forwardInput = Input.GetAxis("Vertical"); // 通常是W和S键  
        float turnInput = Input.GetAxis("Horizontal"); // 通常是A和D键  

        // 应用前进力  
        Vector3 forwardForce = transform.forward * forwardInput * rotationSpeed;
        rb.AddForce(forwardForce, ForceMode.VelocityChange);

        // 应用转弯扭矩（围绕汽车的局部Y轴）  
        float turnTorque = turnInput * 100f;
        rb.AddTorque(Vector3.up * turnTorque);
        // if (Input.GetKeyDown(KeyCode.W)) // 检测到空格键被按下  
        // {
        //     keyPressStartTime = Time.time; // 记录按键开始按下的时间  
        // }
        // if (Input.GetKeyDown(KeyCode.S)) // 检测到空格键被按下  
        // {
        //     keyPressStartTime = Time.time; // 记录按键开始按下的时间  
        // }

        // if (Input.GetKey(KeyCode.W))
        // {
        //     // 计算按键被按下的时长  
        //     keyPressDuration = Time.time - keyPressStartTime;
        //     // 计算车轮在Update期间应该转过的角度（这里使用DeltaTime来处理帧率差异）  
        //     float rotationDelta = rotationSpeed * Time.deltaTime * keyPressDuration;
        //     // 计算车轮在Update期间应该移动的距离（周长的一部分）  
        //     // 将角度转换为弧度并计算距离
        //     float distanceMoved = wheelRadius * Mathf.Deg2Rad * rotationDelta;
        //     // 由于我们通常有两个车轮（一个在前，一个在后），这里假设它们都以相同的速度旋转  
        //     // 因此，我们将距离加倍以模拟两个车轮的效果  
        //     distanceMoved *= 2f;
        //     // 更新车辆主体的位置  
        //     // 注意：这里我们假设车辆沿Z轴前进  
        //     Vector3 movement = new Vector3(0, 0, distanceMoved);
        //     // 使用MovePosition来平滑移动，避免速度叠加 
        //     rb.MovePosition(rb.position + movement);
        //     foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        //     {
        //         if (child.name == "Wheel_LB" || child.name == "Wheel_LF" || child.name == "Wheel_RB" || child.name == "Wheel_RF")
        //         {
        //             child.transform.Rotate(rotationSpeed * Time.deltaTime * Time.time, 0, 0, Space.Self);
        //             //transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0, Space.Self);
        //         }
        //     }
        // }
        // if (Input.GetKey(KeyCode.S))
        // {
        //     // 计算按键被按下的时长  
        //     keyPressDuration = Time.time - keyPressStartTime;
        //     // 计算车轮在Update期间应该转过的角度（这里使用DeltaTime来处理帧率差异）  
        //     float rotationDelta = rotationSpeed * Time.deltaTime * keyPressDuration;
        //     // 计算车轮在Update期间应该移动的距离（周长的一部分）  
        //     // 将角度转换为弧度并计算距离
        //     float distanceMoved = wheelRadius * Mathf.Deg2Rad * rotationDelta;
        //     // 由于我们通常有两个车轮（一个在前，一个在后），这里假设它们都以相同的速度旋转  
        //     // 因此，我们将距离加倍以模拟两个车轮的效果  
        //     distanceMoved *= 2f;
        //     // 更新车辆主体的位置  
        //     // 注意：这里我们假设车辆沿Z轴前进  
        //     Vector3 movement = new Vector3(0, 0, -distanceMoved);
        //     // 使用MovePosition来平滑移动，避免速度叠加 
        //     rb.MovePosition(rb.position + movement);
        //     foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        //     {
        //         if (child.name == "Wheel_LB" || child.name == "Wheel_LF" || child.name == "Wheel_RB" || child.name == "Wheel_RF")
        //         {
        //             child.transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0, Space.Self);
        //             //transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0, Space.Self);
        //         }
        //     }
        // }
    }
}