using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeColor : MonoBehaviour
{
    public Material ActiveMaterial;
    public Material InActiveMaterial;
    public GameObject PlayerGameObject;
    public bool status = new bool();

    private movePlayer movePlayer;

    void Start()
    {
        movePlayer = PlayerGameObject.GetComponent<movePlayer>();
        GetComponent<Renderer>().material = InActiveMaterial;
    }

    void Update()
    {
        if (movePlayer.readyToMove && !status)
        {
            status = true;
            GetComponent<Renderer>().material = ActiveMaterial;
            log("Set to active");
        }
        else if (!movePlayer.readyToMove && status)
        {
            status = false;
            GetComponent<Renderer>().material = InActiveMaterial;
            log("Set to inactive");
        }
    }

    private void log(string text)
    {
        Debug.Log("[RangeColor] \"" + gameObject.name + "\": " + text);
    }
}
