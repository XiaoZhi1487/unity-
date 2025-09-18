using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 合成棋子 : MonoBehaviour
{
    //固定3个合成栏列表
    public GameObject[] 合成栏 = new GameObject[3];
    public GameObject 合成后位置;
    public GameObject 合成后的物体;
    private GameObject itemObject1;
    private GameObject itemObject2;
    private GameObject itemObject3;
    public GameObject 胜利显示;

    public void OnMouseDown()
    {
        // 获取合成栏上的物体名称

        bool xifu1 = 合成栏[0].GetComponent<自动吸附>().xifu;
        bool xifu2 = 合成栏[1].GetComponent<自动吸附>().xifu;
        bool xifu3 = 合成栏[2].GetComponent<自动吸附>().xifu;
        itemObject1 = 合成栏[0].GetComponent<自动吸附>().itemObject;
        itemObject2 = 合成栏[1].GetComponent<自动吸附>().itemObject;
        itemObject3 = 合成栏[2].GetComponent<自动吸附>().itemObject;


        if (xifu1 && xifu2 && xifu3)
        {
            if (itemObject1.name ==itemObject2.name && itemObject1.name == itemObject3.name)
            {
                Destroy(itemObject1);
                Destroy(itemObject2);
                Destroy(itemObject3);

                Instantiate(合成后的物体, new Vector3(合成后位置.transform.position.x, 合成后位置.transform.position.y + 0.8f, 合成后位置.transform.position.z),Quaternion.identity);
                Debug.Log("合成成功 游戏胜利！！！");
                Debug.Log("合成成功");

                胜利显示.transform.position = new Vector3(2.04f, 8.21f, -8.52f);
            }
        }
        else
        {
            Debug.Log("棋子不同不能合成");
        }
    }

}
