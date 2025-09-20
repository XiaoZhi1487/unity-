using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 吸附棋子 : MonoBehaviour
{
    public GameObject ItemObject { get; private set; }

    private void OnTriggerStay(Collider other)
    {
        if (ItemObject == null)
        {
            other.transform.parent.position = transform.position + new Vector3(0, 0.6f, 0);
            ItemObject = other.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ItemObject = null;
    }
}
