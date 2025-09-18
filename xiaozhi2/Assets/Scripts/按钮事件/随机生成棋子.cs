using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 随机生成棋子 : MonoBehaviour
{
    //点击事件
    public GameObject
        qizi1,
        qizi2,
        qizi3,
        qizi4,
        qizi5;
    public GameObject 生成位置;
    private Vector3 生成点;

    private void Start()
    {
        生成点 = new Vector3(生成位置.transform.position.x, 生成位置.transform.position.y+0.65f, 生成位置.transform.position.z);
    }

    public void OnMouseDown()
    {
        int suiji = Random.Range(1, 6);
        if (suiji == 1)
        {
            Instantiate(qizi1, 生成点, Quaternion.identity);
        }
        if (suiji == 2)
        {
            Instantiate(qizi2, 生成点, Quaternion.identity);
        }
        if (suiji == 3)
        {
            Instantiate(qizi3, 生成点, Quaternion.identity);
        }
        if (suiji == 4)
        {
            Instantiate(qizi4, 生成点, Quaternion.identity);
        }
        if (suiji == 5)
        {
            Instantiate(qizi5, 生成点, Quaternion.identity);
        }
    }
}
