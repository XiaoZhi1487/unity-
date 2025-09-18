using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragxz : MonoBehaviour
{
    private Vector3 xyz;
    private float FixedY;
    private Transform TransformPartent;

    private void Start()
    {
        TransformPartent = transform.parent;
        FixedY = TransformPartent.position.y;

    }

    private void OnMouseDown()
    {
        xyz = Camera.main.WorldToScreenPoint(transform.parent.transform.position);
    }
    private void OnMouseDrag()
    {

        Vector3 mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y,xyz.z);

        Vector3 WorldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        TransformPartent.position = new Vector3(WorldPoint.x, FixedY, WorldPoint.z);
    }
}
