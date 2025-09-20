using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 删除棋子 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) => Destroy(other.gameObject);
}
