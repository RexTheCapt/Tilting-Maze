using Assets.scripts.VS_Scripts;
using UnityEngine;
using UnityEngine.UI;

public class GUIResizeText : MonoBehaviour
{
    private GuiTools gt = new GuiTools();

    public GameObject ParentGameObject;
    public int percent = 20;

    void Start()
    {
        GetComponent<Text>().fontSize = gt.screenHeight(percent);
    }
}
