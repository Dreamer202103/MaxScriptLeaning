-- 重置选定对象的变换，但保留位置和旋转  
fn resetTransformKeepingPositionAndRotation selectedObjects =  
(  
    foreach obj in selectedObjects do  
    (  
        -- 保存原始的位置和旋转  
        pos = $.position  
        rot = $.rotation  
          
        -- 重置对象的所有变换（位置、旋转和缩放）  
        resetTransform obj  
          
        -- 应用原始的位置和旋转  
        position obj pos  
        rotate obj rot  
    )  
)  
  
-- 获取当前选择的对象  
selectedObjects = selection as array  
  
-- 调用函数来重置选定对象的变换  
resetTransformKeepingPositionAndRotation selectedObjects  
  
-- 通知用户操作已完成  
print "选定对象的变换已重置，但保留了位置和旋转."