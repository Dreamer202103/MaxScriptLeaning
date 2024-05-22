function TestFun num =
(
	local len = 200
	local centerObj = sphere()
	for i in 1 to num do
	(
		local boxObj = box()
		local angle = 360/num*(i-1)
		boxObj.rotation = eulerangles 0 0 (angle*-1)
		local tx = len * (cos angle)
		local ty = len * (sin angle)
		boxObj.pos = [tx,ty,0]
	)
)

rollout azhaoTestWin "测试窗口" width:287 height:126
(
	label 'l' "请输入需要生成的数量" pos:[12,18] width:126 height:21 align:#left
	editText 'inputTxt' "" pos:[137,15] width:106 height:24 align:#left
	button 'createBtn' "生成" pos:[51,60] width:102 height:40 align:#left
	on createBtn pressed do
	(
		TestFun (inputTxt.text as number)
	)
)

createDialog azhaoTestWin
