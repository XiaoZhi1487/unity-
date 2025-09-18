using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 自动吸附 : MonoBehaviour
{
    public GameObject itemObject { get; private set; } //储存吸附的物体 并且能让其他脚本访问
    public bool xifu { get; private set; } // 是否吸附中 并且能让其他脚本访问
    private void OnTriggerEnter(Collider other) // 当有物体进入触发器时调用
    {
        //Debug.Log("触发开始");
    }
    private void OnTriggerExit(Collider other) // 当有物体离开触发器时调用
    {
        Debug.Log("解除吸附");
        xifu = false; // 标注为解除吸附
        itemObject = null; // 物体离开触发器时 清空存储的物体
    }
    private void OnTriggerStay(Collider other) // 当有物体停留在触发器内时调用
    {
        if (xifu == false)
        {
            //判断 射线定位drag 移动的物体被松开时吸附物体的父级(因为使用父级作为子级的轴心点)
            if (other.GetComponent<射线定位drag>().Dragup == false) // 如果物体被松开并在触发器内则吸附该物体
            {
                Debug.Log("吸附物体");
                //对齐吸附物 y轴不变 【另一个碰撞器的轴心      吸附的x轴             另一个触发器的y轴                  吸附的z轴】
                other.transform.parent.position = new Vector3(transform.position.x, other.transform.parent.position.y, transform.position.z);
                itemObject = other.gameObject; // 存储吸附的物体 用于合成时删除
                xifu = true; // 标记为吸附中
            }
        }
    }
    private void Update()
    {
        //如果物体突然被删除，xifu改为false
        if (itemObject == null)
        {
            xifu = false; // 标注为解除吸附
        }
    }
}
