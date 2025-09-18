using UnityEngine;

using UnityEditor;

public class ResetPivotTool : ScriptableObject

{

    [MenuItem("Tools/ResetPivot")]

    static void ResetPivot()

    {

        GameObject target = Selection.activeGameObject;

        string dialogTitle = "Tools/MyTool/ResetPivot";

        if (target == null)

        { EditorUtility.DisplayDialog(dialogTitle, "Please select an object first\n����ѡ��һ������", "OK"); return; }

        MeshRenderer[] meshRenderers = target.GetComponentsInChildren<MeshRenderer>(true);

        if (meshRenderers.Length == 0)

        { EditorUtility.DisplayDialog(dialogTitle, "The selected object is not a model\n��ѡ���岻��һ��ģ��", "OK"); return; }

        Bounds centerBounds = meshRenderers[0].bounds;

        for (int i = 1; i < meshRenderers.Length; i++) centerBounds.Encapsulate(meshRenderers[i].bounds);

        Transform targetParent = new GameObject(target.name + "-PivotReset").transform;

        Transform originalParent = target.transform.parent;

        if (originalParent != null) targetParent.SetParent(originalParent);

        targetParent.position = centerBounds.center;

        target.transform.parent = targetParent;

        Selection.activeGameObject = targetParent.gameObject;

        EditorUtility.DisplayDialog(dialogTitle, "The axis has been reset\n����������", "OK");

    }

}