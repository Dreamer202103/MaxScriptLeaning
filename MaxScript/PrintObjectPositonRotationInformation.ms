-- 定义一个函数来输出物体的位置和旋转  
fn printObjectInfo obj =  
(  
    -- 获取物体的世界位置和旋转  
    pos = $.position.world  
    rot = $.rotation.eulerAngles  
  
    -- 输出物体名称、位置和旋转  
    format "Object: %\n" obj.name  
    format "Position: (%.2f, %.2f, %.2f)\n" pos.x pos.y pos.z  
    format "Rotation: (%.2f, %.2f, %.2f)\n" rot.x rot.y rot.z  
    format "\n"  
)  
  
-- 遍历场景中的所有对象  
fn traverseObjects obj =  
(  
    -- 如果是几何体或可渲染对象，则输出信息  
    if classof obj == GeometryClass or classof obj == ShapeClass then  
    (  
        printObjectInfo obj  
    )  
    -- 如果对象有子对象，则递归遍历子对象  
    for i = 1 to obj.numChildren do  
    (  
        traverseObjects obj.getChild i  
    )  
)  
  
-- 从根对象开始遍历  
traverseObjects $  
  
-- 如果你只想输出当前选择集中的对象，可以这样做：  
-- for obj in selection do printObjectInfo obj