using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 拖拽棋子 : MonoBehaviour
{
    private Transform tp;
    private float tp_y;
    private Plane dragPlane;
    private Vector3 hiPoint;

    void Start()
    {
        tp = transform.parent;
        tp_y = tp.position.y;
        dragPlane = new Plane(Vector3.up, new Vector3(0, tp_y, 0));
    }
    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (dragPlane.Raycast(ray,out float distance))
        {
            hiPoint = ray.GetPoint(distance);
            tp.position = new Vector3(hiPoint.x,hiPoint.y+0.5f,hiPoint.z);
        }
    }
    private void OnMouseUp() => tp.position = hiPoint;
}
