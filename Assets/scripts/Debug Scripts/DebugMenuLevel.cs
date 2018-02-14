using System;
using System.Collections;
using System.Collections.Generic;
using Assets.scripts.VS_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebugMenuLevel : MonoBehaviour
{
    private Prefs p = new Prefs();

    [Header("Set ints")]
    public int Level;
    [Space(10)]
    [Header("Set and reloads")]
    public bool SetValues = false;
    public bool ReloadLevel = false;
    public bool SetAndReload = false;
    [Serializable]
    class DeleteAllPlayerPrefs
    {
        public bool Confirm0 = false;
        public bool Confirm1 = false;
        public bool Confirm2 = false;
        public bool Confirm3 = false;
    }
    [SerializeField]
    DeleteAllPlayerPrefs DAP = new DeleteAllPlayerPrefs();

    private void Start()
    {
        Level = p.level;
    }

    private void Update()
    {
        if (SetAndReload)
        {
            SetValues = true;
            ReloadLevel = true;
        }

        if (SetValues)
        {
            p.level = Level;
            SetValues = false;
        }

        if (ReloadLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            ReloadLevel = false;
        }

        if (DAP.Confirm0 || DAP.Confirm1 || DAP.Confirm2 || DAP.Confirm3)
        {
            Debug.Log("Playerprefs is in danger!");
            if (DAP.Confirm0 && DAP.Confirm1 && DAP.Confirm2 && DAP.Confirm3)
            {
                PlayerPrefs.DeleteAll();
                DAP.Confirm0 = false;DAP.Confirm1 = false;
                DAP.Confirm2 = false;DAP.Confirm3 = false;
                Debug.Log("Playerprefs deleted");
            }
        }
    }

    public void MainMenuSetLevel(GameObject TextInputDebugGameObject)
    {
        string s = TextInputDebugGameObject.GetComponent<InputField>().text;

        try
        {
            int n = Convert.ToInt32(s);
            Level = n;
            p.level = n;
        }
        catch
        {
            TextInputDebugGameObject.GetComponent<InputField>().text = "Invalid Only number";
        }
    }
}
