using UnityEngine;
using System.Collections;
using Assets.scripts.VS_Scripts;

public class GuiTimer : MonoBehaviour
{
    private GuiTools gt = new GuiTools();
    private float record;

    public float deltaTime = 0.0f;
    public bool run = false;
    public GameObject DataHoldGameObject;

    void Update()
    {
        record = DataHoldGameObject.GetComponent<DataHold>().record;

        if(run)
            deltaTime += Time.deltaTime;
    }

    void OnGUI()
    {
        int h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, gt.intPercent(h, 10), 0, 0);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = gt.intPercent(h, 5);
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        string text = string.Format("Time L{4}: {0:00}:{1:00.00} ({2:00}:{3:00.00})",
            Mathf.Floor(deltaTime / 60), deltaTime % 60, Mathf.Floor(record / 60), record % 60, DataHoldGameObject.GetComponent<DataHold>().Level + 1);
        GUI.Label(rect, text, style);
    }
}