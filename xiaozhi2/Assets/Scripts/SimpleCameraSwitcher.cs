using UnityEngine;

public class SimpleCameraSwitcher : MonoBehaviour
{
    public Camera[] cameras; // ��˳����4������������� Camera0, Camera1, Camera2, Camera3��
    private int currentCameraIndex = 0;
    private int switchCount = 0;
    private const int MaxSwitches = 4; // �ܹ��л�4��

    void Start()
    {
        // ��ʼ����ֻ���õ�һ����������������������
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = (i == 0);
        }

        // ��ʼÿ��2���л�һ��
        InvokeRepeating("SwitchCamera", 1f, 1f);
    }

    void SwitchCamera()
    {
        // ���õ�ǰ�����
        cameras[currentCameraIndex].enabled = false;

        // �л�����һ���������ѭ����
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
        cameras[currentCameraIndex].enabled = true;

        // �����л�����
        switchCount++;

        // ����л���4�Σ�ֹͣ�л�
        if (switchCount >= MaxSwitches-1)
        {
            CancelInvoke("SwitchCamera"); // ֹͣ����
            Debug.Log("�����4��������л���");
        }
    }
}