use vulkano::device::QueueFlags;
use vulkano::device::{Device, DeviceCreateInfo, QueueCreateInfo};
/*
下面的代码时使用Rust编程语言结合Vulkano库创建Vulkan实例的示例。Vulkan是一个跨平台的图形和计算API，由Khronos Group开发，旨在提供高性能的3D图形渲染
Vulkano时Vulkan的一个Rust封装库，它提供了更加安全和易于使用的API来访问Vulkan的功能，
 */
//下面两行代码导入了Vulkano库中需要用到的几个类型和结构题。
//Instance是Vulkan实例的Rust表示，Vulkan实例是Vulkan应用程序与Vulkan驱动程序之间的接口
//InstanceCreateInfo是一个结构体，用于配置Vulkan实例的创建信息，在这个实例中，我门使用了它的默认配置。
use vulkano::instance::{Instance, InstanceCreateInfo}; //导入相关模块
//VulkanLibraary是Vulkano中用于加载本地Vulkan动态库(DLL或.so文件)的类型。
use vulkano::VulkanLibrary;

// 主函数入口
fn main() {
    //初始化
    // VulkanLibrary::new()返回一个VulkanLibrary实例，如果本地没有 Vulkan库/DLL，则返回None
    //expect表示当程序运行到这里时，如果发生错误则会停止运行，并输出括号内的错误信息
    /*
    加载Vulkan库：
    这行代码尝试加载本地安装的Vulkan库。VulkanLibrary::new() 尝试找到并加载Vulkan的动态链接库。如果找不到Vulkan库，
    这行代码将触发expect方法中的错误消息"no local Vulkan library/DLL"，导致程序崩溃。
     */
    let library = VulkanLibrary::new().expect("no local Vulkan library/DLL");
    /*
    这行代码使用之前加载的Vulkan库和默认的实例创建信息来创建一个Vulkan实例。Instance::new() 函数接受两个参数：
    一个VulkanLibrary实例和一个InstanceCreateInfo实例。在这个例子中，我们传递了之前加载的VulkanLibrary实例和InstanceCreateInfo的默认实例。
    如果实例创建失败（比如因为不支持的Vulkan版本或硬件不支持），expect方法将触发，并显示错误消息"failed to create instance"，导致程序崩溃。
     */
    let instance =
        Instance::new(library, InstanceCreateInfo::default()).expect("failed to create instance");

    //枚举物理设备
    //enumerate_physical_devices()返回一个迭代器，可以用来枚举物理设备
    //next()返回迭代器中下一个元素，expect()返回迭代器中的元素，或在遇到错误时停止运行并输出错误信息
    //unwrap()返回迭代器中的元素，如果迭代器为空，则 panic!()
    //expect("没有设备可用")表示当没有物理设备时，会停止运行并输出 "没有设备可用" 信息
    let physical_device = instance
        .enumerate_physical_devices()
        .expect("无法枚举设备")
        .next()
        .expect("没有设备可用");

    println!("{:?}", physical_device);
    //列出物理设备支持的队列family
    for family in physical_device.queue_family_properties() {
        println!("Found a queue family with {:?} queues", family.queue_count);
    }

    //创建逻辑设备
    //physical_device.queue_family_properties()返回一个迭代器，可以用来枚举物理设备的队列family
    //enumerate()返回一个迭代器，可以用来枚举物理设备的队列family
    //next()返回迭代器中下一个元素，unwrap()返回迭代器中的元素
    //unwrap()返回迭代器中的元素，如果迭代器为空，则 panic!()
    //expect("没有可用队列family")表示当没有可用队列family时，会停止运行并输出 "没有可用队列family" 信息
    // let queue_family = physical_device
    //     .queue_family_properties()
    //     .iter()
    //     .enumerate()
    //     .next()
    //     .unwrap()
    //     .expect("没有可用队列family");

    //创建逻辑设备
    //physical_device.create_device()返回一个 Result<Device, Error>，如果创建成功，返回 Device 实例，如果创建失败，返回 Error 实例
    let queue_family_index = physical_device
        .queue_family_properties()
        .iter()
        .enumerate()
        .position(|(_queue_family_index, queue_family_properties)| {
            queue_family_properties
                .queue_flags
                .contains(QueueFlags::GRAPHICS)
        })
        .expect("couldn't find a graphical queue family") as u32;
    let (device, mut queues) = Device::new(
        physical_device,
        DeviceCreateInfo {
            // 这里我们将希望使用的队列家族的索引传递给设备
            queue_create_infos: vec![QueueCreateInfo {
                queue_family_index,
                ..Default::default()
            }],
            ..Default::default()
        },
    )
    .expect("failed to create device");
    let queue = queues.next().unwrap();
}

fn create_vulkan()
{
    //初始化
    // VulkanLibrary::new()返回一个VulkanLibrary实例，如果本地没有 Vulkan库/DLL，则返回None
    //expect表示当程序运行到这里时，如果发生错误则会停止运行，并输出括号内的错误信息
    /*
    加载Vulkan库：
    这行代码尝试加载本地安装的Vulkan库。VulkanLibrary::new() 尝试找到并加载Vulkan的动态链接库。如果找不到Vulkan库，
    这行代码将触发expect方法中的错误消息"no local Vulkan library/DLL"，导致程序崩溃。
     */
    let library = VulkanLibrary::new().expect("no local Vulkan library/DLL");
    /*
    这行代码使用之前加载的Vulkan库和默认的实例创建信息来创建一个Vulkan实例。Instance::new() 函数接受两个参数：
    一个VulkanLibrary实例和一个InstanceCreateInfo实例。在这个例子中，我们传递了之前加载的VulkanLibrary实例和InstanceCreateInfo的默认实例。
    如果实例创建失败（比如因为不支持的Vulkan版本或硬件不支持），expect方法将触发，并显示错误消息"failed to create instance"，导致程序崩溃。
     */
    let instance =
        Instance::new(library, InstanceCreateInfo::default()).expect("failed to create instance");
}
