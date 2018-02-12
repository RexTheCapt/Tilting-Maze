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

    public GameObject ControllerGameObject;
    public int levelTarget = 0;

    private void OnEnable()
    {
        GetComponent<Button>().interactable = false;
    }

    private void Update()
    {
        LAC = ControllerGameObject.GetComponent<LevelAccessController>();

        colorBlock.normalColor = LAC.ActiveColor;
        colorBlock.disabledColor = LAC.InActiveColor;
        colorBlock.highlightedColor = LAC.HighLightColor;
        colorBlock.pressedColor = LAC.PressedColor;
        colorBlock.colorMultiplier = LAC.colorMultiplier;
        colorBlock.fadeDuration = LAC.fadeDuration;

        GetComponent<Button>().colors = colorBlock;

        if (prefs.level >= levelTarget)
            GetComponent<Button>().interactable = true;
        else
            GetComponent<Button>().interactable = false;
    }

    public void StartLevel()
    {
        if (prefs.level >= levelTarget)
        {
            string s = "Level " + (levelTarget + 1);
            SceneManager.LoadScene(s);
        }
    }
}
