
rollout mytools "批量导入"
(	
  button bt1 "批量导入" width:90 height:30 offset:[0,5] 
  on bt1 pressed do 
	(
		Fn getnames Title FilterName =
         (
             dialog = DotNetObject "System.Windows.Forms.OpenFileDialog"
             dialog.title = Title
             dialog.filter = FilterName
			 dialog.Multiselect = true
             OpenFileResult = dialog.ShowDialog()
             if OpenFileResult.Equals OpenFileResult.OK then
				 (
                 dialog.FileNames
                 )
             else Undefined
 	     )
	file_names = getnames "选择导入文件"  ""
	if file_names != undefined do
		(
			for DTL in file_names do
               (
			if ( doesfileexist DTL ) do
			importFile DTL #noPrompt using:Wavefront_Object 
			for geo in geometry
			where (matchPattern geo.name pattern:"3D_Object*") do
			(
			  path11 = filterString (d as string) "//"
			  geo.name = path11[path11.count]
			)
	            )
			actionMan.executeAction 0 "310"
	    )
	)
 )
createdialog mytools width:150 height:100

