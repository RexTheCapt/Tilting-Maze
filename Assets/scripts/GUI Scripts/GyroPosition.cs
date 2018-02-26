using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroPosition : MonoBehaviour
{
    private movePlayer mp;
    private Vector2 v;
    [Serializable]
    class DebugVariables {
        public bool PrintLocalPosition = false;
    }

    public GameObject PlayerGameObject;
    public float positionModifier = 0f;
    public Color ActivePosition;
    public Color InActivePosition;
    [SerializeField]
    DebugVariables debugVariables = new DebugVariables();

    void Start()
    {
        mp = PlayerGameObject.GetComponent<movePlayer>();
        v = transform.localPosition;
    }

    void FixedUpdate()
    {
        transform.localPosition = new Vector3(mp.acc.x * positionModifier, mp.acc.y * positionModifier);

        if(transform.localPosition.x == v.x && transform.localPosition.y == v.y)
            gameObject.GetComponent<Image>().color = InActivePosition;
        else
            gameObject.GetComponent<Image>().color = ActivePosition;

        if(debugVariables.PrintLocalPosition)
            Debug.Log(transform.localPosition);
    }
}
