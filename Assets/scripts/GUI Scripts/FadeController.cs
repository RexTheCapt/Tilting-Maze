using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Texture2D BlackFadeTexture2D;
    public Texture2D RedFadeTexture2D;
    public float fadeSpeed = 0.8f;
    public bool inFade = false;
    public bool death = false;
    public float alpha = 1.0f;

    private int drawDepth = -1000;
    private int fadeDir = -1;

    void Start()
    {
        BeginFade(-1);
    }

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        //alpha = Mathf.Clamp01(alpha);

        if(!death)
            GUI.color = new Color(0f, 0f, 0f, alpha);
        else if (death)
        {
            GUI.color = new Color((1f - alpha) + 0.2f, 0f, 0f, alpha);
        }
        GUI.depth = drawDepth;

        if (!death)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), BlackFadeTexture2D);
        else if (death)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), RedFadeTexture2D);
        }

        if (fadeDir > 0 && alpha >= 1f)
            inFade = false;
        else if (fadeDir < 0 && alpha <= 0f)
            inFade = false;
    }

    public float BeginFade(int direction, bool death = false)
    {
        fadeDir = direction;
        inFade = true;

        this.death = death;

        if (direction > 0)
            alpha = 0f;
        else if (direction < 0)
            alpha = 1f;

        log("Fade started, Direction: " + direction + ", death: " + death);

        return (fadeSpeed);
    }

    void log(string text)
    {
        Debug.Log("[FadeController] \"" + gameObject.name + "\": " + text);
    }
}
