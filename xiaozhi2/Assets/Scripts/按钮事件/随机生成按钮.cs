using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 随机生成按钮 : MonoBehaviour
{
    //自定义物品列表
    public List<GameObject> 物品列表;
    public Transform 生成点;

    private void OnMouseDown()
    {
        int i = Random.Range(0, 物品列表.Count);
        GameObject newObject = Instantiate(
            物品列表[i], 
            new Vector3(生成点.position.x, 生成点.position.y+0.55f, 生成点.position.z), Quaternion.identity
            );
    }
}
