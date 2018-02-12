using Assets.scripts.VS_Scripts;
using UnityEngine;

public class SpeedMeter : MonoBehaviour
{
    private GuiTools gt = new GuiTools();
    private Vector3 lastPosition = Vector3.zero;

    public float playerSpeed = 0f;

    void FixedUpdate()
    {
        playerSpeed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, gt.intPercent(h, 5), 0, 0);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = gt.intPercent(h, 5);
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        string text = string.Format("{0}",(playerSpeed * 100).ToString("0.0"));
        GUI.Label(rect, text, style);
    }
}