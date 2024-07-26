using System.Collections.Generic;
using UnityEngine;
using CombineMeshes;
public class UsingMergeMesh : MonoBehaviour
{
    [Header("示例1：AllMergeMesh")]
    public GameObject MergeMeshGameObject;
    [Header("示例2：PartMergeMesh请给父节点放入4个模型（若没有4个游戏对象，程序会报错）")]
    public GameObject MergeMeshGameObject2;//
 
    void Update()
    {
        //按下Enter键才会执行
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AllMergeMesh(MergeMeshGameObject);
        }
        //按下A键才会执行
        if (Input.GetKeyDown(KeyCode.A))
        {
            PartMergeMesh(MergeMeshGameObject2);
        }
    }
 
    /// <summary>
    /// 模型的整体合并网格
    /// </summary>
    /// <param name="source_Obj">父节点</param>
    /// <returns></returns>
    GameObject AllMergeMesh(GameObject source_Obj)
    {
        Vector3 initialPos = source_Obj.transform.position;
        Quaternion initialRot = source_Obj.transform.rotation;
 
        GameObject clone_Obj = Instantiate(source_Obj);
        GameObject cloneParents = new GameObject();
        cloneParents.transform.position = initialPos;
        cloneParents.transform.rotation = initialRot;
 
        clone_Obj.transform.parent = cloneParents.transform;
        #region<根据实际要求自行更改>
        ///<summary>
        ///自动分总点数超过65535点的模型，超过65535的点会有子集关系，且相同材质会合并
        ///</summary>
        GameObject tar_Obj = Combinemeshes.MergeMesh1(cloneParents, true);//父节点有mesh
        //tar_Obj = Combinemeshes.MergeMesh1(clone_F,false);//父节点无mesh
 
 
        ///<summary>
        ///模型总点数不能超过65535，且相同材质会合并，超过会报错：合并游戏对象的总点数超过65535
        ///</summary>
        //tar_Obj = Combinemeshes.MergeMesh2(clone_F);
 
 
        ///<summary>
        ///模型总点数不能超过65535，材质相同也不会合并（一般不调用，MergeMesh2函数更好）
        ///</summary>
        //tar_Obj = Combinemeshes.MergeMesh3(clone_F);
        #endregion
 
        tar_Obj.name = "AllMergeMesh";
        return tar_Obj;
    }
 
    /// <summary>
    /// 模型的子集关系合并（这里做个示例，请给父节点放入4个模型）
    /// </summary>
    /// <param name="source_Obj">父节点</param>
    /// <returns></returns>
    GameObject PartMergeMesh(GameObject source_Obj)
    {
        //获取父节点中的子物体
        List<GameObject> source_ObjChild = new List<GameObject>();
        for (int i = 0; i < source_Obj.transform.childCount; i++)
        {
            source_ObjChild.Add(source_Obj.transform.GetChild(i).gameObject);
        }
        GameObject tar_Obj = new GameObject(source_Obj.name);
 
        GameObject gameObjects;//将gameObj实例化的对象，放入gameObjects子集中
        List<GameObject> gameObj = new List<GameObject>();//实例化对象
 
        //合并一
        gameObjects = new GameObject(source_Obj.name);
        gameObjects.transform.position = source_ObjChild[0].transform.localPosition;
        gameObj.Add(Instantiate(source_ObjChild[0]));
        gameObj.Add(Instantiate(source_ObjChild[1]));
        for (int i = 0; i < gameObj.Count; i++)
        {
            gameObj[i].transform.parent = gameObjects.transform;
        }
        //这里我用的是MergeMesh1，可自行根据实际更改MergeMesh2、MergeMesh3
        gameObjects = Combinemeshes.MergeMesh1(gameObjects);
        gameObj.Clear();
        gameObjects.transform.parent = tar_Obj.transform;
 
        //合并二
        gameObjects = new GameObject("joint");
        gameObjects.transform.position = source_ObjChild[2].transform.localPosition;
        gameObj.Add(Instantiate(source_ObjChild[2]));
        gameObj.Add(Instantiate(source_ObjChild[3]));
        for (int i = 0; i < gameObj.Count; i++)
        {
            gameObj[i].transform.parent = gameObjects.transform;
        }
        //这里我用的是MergeMesh1，可自行根据实际更改MergeMesh2、MergeMesh3
        gameObjects = Combinemeshes.MergeMesh1(gameObjects);
        gameObj.Clear();
        gameObjects.transform.parent = tar_Obj.transform;
 
 
        Vector3 initialPos = source_Obj.transform.position;
        Quaternion initialRot = source_Obj.transform.rotation;
 
        tar_Obj.transform.position = initialPos;
        tar_Obj.transform.rotation = initialRot;
 
        //设置父子关系
        for (int i = 0; i < tar_Obj.transform.childCount; i++)
        {
            gameObj.Add(tar_Obj.transform.GetChild(i).gameObject);
        }
        for (int i = 1; i < gameObj.Count; i++)
        {
            gameObj[i].transform.parent = gameObj[i - 1].transform;
        }
 
        #region<根据需要请自行更改>
        ///<summary>
        ///父节点有mesh
        /// </summary>
        gameObj[0].transform.parent = tar_Obj.transform.parent;
        gameObj[0].name = "PartMergeMesh";
        Destroy(tar_Obj);
        return gameObj[0];
 
        ///<summary>
        ///父节点无mesh
        /// </summary>
        //return tar_Obj;
        #endregion
    }
 
}