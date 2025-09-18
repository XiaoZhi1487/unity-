using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 删除棋子 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //删除碰撞到的物体
        Destroy(other.gameObject);

        Debug.LogError("你删除了一个物体");

    }
}
