using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 射线定位drag : MonoBehaviour
{
    private float fixedY;         // 固定的Y轴位置
    private Transform targetTransform; // 要移动的目标对象
    private Plane dragPlane;      // 用于射线检测的平面

    public bool Dragup { get; private set; }

    private void Start()
    {
        // 获取要移动的目标对象（父对象）
        targetTransform = transform.parent;
        fixedY = targetTransform.position.y;

        // 创建与Y轴平行的拖拽平面
        dragPlane = new Plane(Vector3.up, new Vector3(0, fixedY, 0));
    }
    //鼠标按下时拖动物体
    private void OnMouseDrag()
    {
        // 从摄像机发射射线到鼠标位置
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // 检测射线与拖拽平面的交点
        if (dragPlane.Raycast(ray, out float distance))
        {
            // 获取交点位置并更新目标对象位置
            Vector3 hitPoint = ray.GetPoint(distance);
            targetTransform.position = hitPoint;
        }

        Dragup = true;
    }
    private void OnMouseUp()
    {
        Dragup = false;
    }
}
