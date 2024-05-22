	group "替换"
	(
		pickbutton pbSource "Source" pos:[10,120,0] width:110
		on pbSource picked obj do 
		(	
			rootObj=Common.GetRootNode obj
			centerpivot rootObj --有时候需要
			source_obj = rootObj --存取 Utility 局部变量 
			pbSource.text = rootObj.name --存取 Utility 控件 
			-- select rootObj --场景大的情况下会小卡
		)--事件处理程序结束
 
		checkbutton pbTarget "Target" pos:[120,120,0] width:110 --checkbutton结合pickObject()实现多选功能
		on pbTarget changed state do
		(
			if state do
			(
				pbTarget.enabled = off
				target_obj = #()
				while isvalidnode (obj = pickObject()) do (
 
					rootObj=Common.GetRootNode obj
					appendifunique target_obj rootObj
					if target_obj.count == 1 then 
					(
						pbTarget.text = rootObj.name
					)
					else
					(
						pbTarget.text = (target_obj.count as string) 
					)
				)
				print ("select:"+(target_obj.count as string))
 
				pbTarget.enabled = on
				pbTarget.checked = off
			)
		)
 
		button btnClearSelection "Clear" pos:[230,120,0] width:40
		on btnClearSelection pressed do 
		(
			clearSelection()
			source_obj=undefined
			target_obj=#()
			pbTarget.text="Target"
			pbSource.text="Source"
		)
 
		checkbox cbIsClone "Clone" pos:[270,125,0] width:50 checked:true
		checkbox cbIsX "X" pos:[315,125,0] width:20 checked:true
		checkbox cbIsY "Y" pos:[340,125,0] width:20 checked:true
		checkbox cbIsZ "Z" pos:[365,125,0] width:20 checked:false
		button btnReplace "Replace" pos:[390,120,0] width:60
		on btnReplace pressed do 
		(
			-- targets=$ as Array --有delete时需要转换成Array
			if target_obj ==undefined or target_obj.count == 0 do return undefined
			targets=target_obj
			
			print ("replace1:"+(source_obj as string)+"->"+(targets as string ))
			newObj=undefined
			for target in targets do
			(
				if target == source_obj do continue
				print ("replace2:"+(source_obj as string)+"->"+(target as string ))
				-- replaceInstances  
				-- format "%,%" source_obj t
				newObj=source_obj
				if cbIsClone.checked do (newObj=copy source_obj)
				if cbIsX.checked do (newObj.pos.x=target.pos.x)
				if cbIsY.checked do (newObj.pos.y=target.pos.y)
				if cbIsZ.checked do (newObj.pos.z=target.pos.z)
				-- newObj.pos=t.pos
				-- newObj.name=t.name
				newObj.parent=target.parent
				delete target
			)
		)
	)