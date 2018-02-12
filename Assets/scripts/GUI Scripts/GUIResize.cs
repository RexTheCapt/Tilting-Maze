using Assets.scripts.VS_Scripts;
using UnityEngine;

public class GUIResize : MonoBehaviour
{
    private GuiTools gt = new GuiTools();
    private int mx, my;

    public bool active = false;
    public bool activeOnce = false;
    public Vector2 size = new Vector2(20, 20);
    public Vector2 modifier = new Vector2(100, 100);

    void Start()
    {
        setSize();
    }

    void FixedUpdate()
    {
        if (active || activeOnce)
        {
            setSize();
        }
    }

    private void setSize()
    {
        mx = (int)modifier.x;
        my = (int)modifier.y;
        GetComponent<RectTransform>().sizeDelta = new Vector2(gt.intPercent(Screen.width, (int)size.x, mx), gt.intPercent(Screen.height, (int)size.y, my));
    }
}
