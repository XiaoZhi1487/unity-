using UnityEngine;

public class SimpleCameraSwitcher : MonoBehaviour
{
    public Camera[] cameras; // 按顺序存放4个摄像机（比如 Camera0, Camera1, Camera2, Camera3）
    private int currentCameraIndex = 0;
    private int switchCount = 0;
    private const int MaxSwitches = 4; // 总共切换4次

    void Start()
    {
        // 初始化：只启用第一个摄像机，禁用其他摄像机
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = (i == 0);
        }

        // 开始每隔2秒切换一次
        InvokeRepeating("SwitchCamera", 1f, 1f);
    }

    void SwitchCamera()
    {
        // 禁用当前摄像机
        cameras[currentCameraIndex].enabled = false;

        // 切换到下一个摄像机（循环）
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
        cameras[currentCameraIndex].enabled = true;

        // 增加切换计数
        switchCount++;

        // 如果切换了4次，停止切换
        if (switchCount >= MaxSwitches-1)
        {
            CancelInvoke("SwitchCamera"); // 停止调用
            Debug.Log("已完成4次摄像机切换！");
        }
    }
}