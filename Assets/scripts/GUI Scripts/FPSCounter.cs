﻿using UnityEngine;
using System.Collections;
using Assets.scripts.VS_Scripts;

public class FPSCounter : MonoBehaviour
{
    float deltaTime = 0.0f;
    private GuiTools gt = new GuiTools();

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, gt.intPercent(h, 0), 0, 0);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = gt.intPercent(h, 5);
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}