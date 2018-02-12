using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroDisk : MonoBehaviour
{
    private movePlayer mp;
    private bool rtm;
    private float tmr;

    public GameObject PlayerGameObject;
    public Color ActiveColor;
    public Color InActiveColor;
    public Color FlashColor;
    public float FlashTime = 0.5f;

    void Start()
    {
        mp = PlayerGameObject.GetComponent<movePlayer>();
        tmr = FlashTime * 1.1f;
    }

    void FixedUpdate()
    {
        rtm = mp.readyToMove;
        tmr += Time.deltaTime;

        if (rtm && tmr > FlashTime)
            GetComponent<Image>().color = ActiveColor;
        else if (!rtm && tmr > FlashTime)
            GetComponent<Image>().color = InActiveColor;
    }

    public void Flash()
    {
        if(tmr > FlashTime)
            tmr = 0;

        GetComponent<Image>().color = FlashColor;
    }
}
