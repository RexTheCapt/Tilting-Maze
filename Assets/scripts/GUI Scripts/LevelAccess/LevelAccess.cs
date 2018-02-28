using Assets.scripts.VS_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelAccess : MonoBehaviour
{
    private Prefs prefs = new Prefs();
    [SerializeField]
    private ColorBlock colorBlock;
    private LevelAccessController LAC;
    private float tmr;

    public GameObject ControllerGameObject;
    public int levelTarget = 0;

    private void OnEnable()
    {
        GetComponent<Button>().interactable = false;
    }

    private void Update()
    {
        if (prefs.level >= levelTarget)
        {
            LAC = ControllerGameObject.GetComponent<LevelAccessController>();

            colorBlock.normalColor = LAC.ActiveColor;
            colorBlock.disabledColor = LAC.InActiveColor;
            colorBlock.highlightedColor = LAC.HighLightColor;
            colorBlock.pressedColor = LAC.PressedColor;
            colorBlock.colorMultiplier = LAC.colorMultiplier;
            colorBlock.fadeDuration = LAC.fadeDuration;

            GetComponent<Button>().colors = colorBlock;

            GetComponent<Button>().interactable = prefs.level >= levelTarget;
        }
    }

    public void StartLevel()
    {
        if(levelTarget == -1)
            SceneManager.LoadScene("DebugScene");
        else if (prefs.level >= levelTarget)
        {
            string s = "Level " + (levelTarget + 1);
            SceneManager.LoadScene(s);
        }
    }
}
