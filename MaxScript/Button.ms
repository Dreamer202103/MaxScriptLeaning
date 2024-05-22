rollout mytool "大头梨的卷展栏"
(
	edittext edt1 "旋转角度：" width: 150 Bold:  true 
	--创建名为“旋转角度”的可编辑文本框1，宽度150，字体加粗
	edittext edt2 "坐标：" width: 180  height:50 labelontop: true readonly: false
	--创建名为“坐标”的可编辑文本框2，宽度180，高度50，标题位于文本框上方，内容不可编辑。
    button bt1 "打印" width: 50 height: 25
	on bt1 pressed do
	(
		print edt1.text 
		messagebox "打印成功"
		)
		on bt1 rightclick do
	(
		print edt2.text
		messagebox "打印成功!"
		)	
)
Createdialog mytool 200 300

