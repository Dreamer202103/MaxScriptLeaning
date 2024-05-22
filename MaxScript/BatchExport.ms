rollout batchExport "模型批量导入/导出"     
	(  
		fn init=
		(
		)
		fn replaceSub str1 str2 str3=(
			while ((i=findstring str1 str2) != undefined) do
			(
				str1 = replace str1 i str2.count str3
			)
			return str1
		)
			label lb0"" height:10 align:#center	
		button bt3 "批量导入" width:90 height:25 offset:[0,5] 
	 on bt3 pressed do 
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
                 for d in file_names do
            (
				 if ( doesfileexist d ) do
                 importFile d #noPrompt using:Wavefront_Object 
				 for geo in geometry
                 where (matchPattern geo.name pattern:"3D_Object*") do
            (
                 pathaa = filterString (d as string) "//"
                 geo.name = pathaa[pathaa.count]
		    )
	        )
			actionMan.executeAction 0 "310"
	    )
 )
		label lb1"" height:10 align:#center	
		button button_export "批量导出"width:90 height:25 align:#center
		edittext edittext_exportFolderPath "导出目录" fieldWidth:140 height:20 labelOnTop:true readOnly:false align:#left
 -----------------------------------------------按钮回调
		on batchExport open do
		(
			init()
		)
		on button_export pressed do
		(
				Sel = Selection as array
			
				for i=1 to Sel.count do(
					select Sel[i];
					objName=Sel[i].name;
					Sel[i].name = replaceSub objName "*" "_";--如果物体名字包含*则替换成_
			)
	for i=1 to Sel.count do(
	select Sel[i];
	objName=Sel[i].name;
	exportPath = edittext_exportFolderPath.text + "/" + (i as String) + "_" + objName;
					exportPath = trimleft exportPath;
					exportPath = trimRight exportPath;
					print exportPath;
					exportfile exportPath  #noPrompt selectedOnly:true using:OBJEXP  --using后边可以修改，目前是导出obj格式，如果到导出fbx即为FBXEXP
				)
				select Sel;
		)
		label lb2"" height:5 align:#center	
	)
		createdialog  batchExport
	    batchExport.height=180
        batchExport.width=170