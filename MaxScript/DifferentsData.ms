--boxt1 = box()
--获得网格顶点数
GetNumVerts boxt1.mesh
--8
--获得某个通道的顶点数据数量，1通道代表UV通道，
--这里我能用1通道，是因为我已经展过UV了，如果没有展过UV，会报错
polyop.getNumMapVerts boxt1 1
--24
--获得实际的三角面数
GetNumFaces boxt1.mesh
12
--获得第一个顶点的坐标
getVert boxt1.mesh 1
--[-12.5,-12.5,0]
--获得第12个面使用了哪几个顶点，对应网格顶点数的索引
getface boxt1.mesh 12
--[3,1,5]
--获得第12个面的法线方向
GetFaceNormal boxt1.mesh 12
--[-1,0,0]
--获得第12个面引用的UV索引，对应UV坐标索引
GetTVFace boxt1.mesh 12
--[9,10,11]
--获得第9个UV索引点的UV坐标
getTVert boxt1.mesh 9
--[0.0005,0.0005,0]
