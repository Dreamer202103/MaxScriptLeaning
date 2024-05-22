-- 递归函数，遍历给定对象的所有子对象  
fn traverseChildren obj =  
(  
    -- 遍历当前对象的所有子对象  
    for child in obj.children do  
    (  
		
        -- 打印子对象的名称（或进行其他操作）  
        print (child.name)  
          
        -- 如果子对象还有子对象，则递归调用traverseChildren函数  
        if child.children.count > 0 then  
        (  
            traverseChildren child  
        )  
    )  
)  
  
-- 选择一个父级对象（这里假设你已经手动选择了一个对象）  
-- 或者你可以通过名称或其他方式获取一个对象  
selectedParent = selection[1] -- 假设已选择一个对象  
  
-- 调用函数来遍历父级对象下的所有子对象  
traverseChildren selectedParent