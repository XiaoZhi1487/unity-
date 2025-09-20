using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 合成大棋子 : MonoBehaviour
{
    public List<GameObject> 合成栏 = new List<GameObject>(3);
    public Transform 生成位置;
    //判断胜利
    private int bigObjectCount;
    public Transform 游戏胜利提示;

    private void OnMouseDown()
    {
        GameObject 棋子1 = 合成栏[0].GetComponent<吸附棋子>().ItemObject;
        GameObject 棋子2 = 合成栏[1].GetComponent<吸附棋子>().ItemObject;
        GameObject 棋子3 = 合成栏[2].GetComponent<吸附棋子>().ItemObject;
        if (棋子1 == null || 棋子2 == null || 棋子3 == null) { Debug.Log("合成栏不能为空"); return; }
        if (棋子1.name == 棋子2.name && 棋子2.name == 棋子3.name)
        {
            Destroy(棋子1);
            Destroy(棋子2);
            Destroy(棋子3);
            GameObject bigObject = Instantiate(棋子1, 生成位置.position + new Vector3(0, 0.6f, 0), Quaternion.identity);
            bigObject.name = "big-" + 棋子1.name.Replace("-PivotReset", "").Replace("(Clone)", "");
            bigObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            //初始化拖拽脚本
            bigObject.GetComponentInChildren<拖拽棋子>().enabled = true;
            bigObjectCount++;
        }else{Debug.Log("合成的棋子必须相同");}
        if (bigObjectCount >= 2)
        {
            游戏胜利提示.position = new Vector3(2,8.2f,-8.5f);
        }
    }
}
