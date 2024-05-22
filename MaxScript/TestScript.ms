rollout testScript "测试窗口" width:162 height:300
(
	button 'testButton' "测试按钮" pos:[46,56] width:71 height:31 toolTip:"这是一个测试按钮" align:#left
	button 'testPrint' "输出字符串" pos:[26,96] width:98 height:29 align:#left
	button 'testVariable' "变量" pos:[38,140] width:92 height:39 align:#left
	button 'printMeshName' "输出名字" pos:[49,191] width:74 height:36 align:#left
	
	
	on testButton pressed do
		TestFun()
	on testPrint pressed do
		printFont()
	on printMeshName pressed do
		-- 选择一个父级对象（这里假设你已经手动选择了一个对象）  
		-- 或者你可以通过名称或其他方式获取一个对象  
		--selectedParent = selection[1] -- 假设已选择一个对象
		traverseChildren()
)
createDialog testScript

fn TestFun =
(
	textBox = box()
)

fn printFont =
(
	print ("Love" +" " + "Max")
)

fn TestVariable = 
(
	
)

-- 递归函数，遍历给定对象的所有子对象  
fn traverseChildren =  
(  
	selectedParent = selection[1] 
    -- 遍历当前对象的所有子对象  
    for child in selectedParent do  
    (  
		
        -- 打印子对象的名称（或进行其他操作）  
        print (child.name)  
          
        -- 如果子对象还有子对象，则递归调用traverseChildren函数  
        if child.children.count > 0 then  
        (  
            for child in child.children do  
			(
				print (child.name)
			)
     
        )  
    )  
)  