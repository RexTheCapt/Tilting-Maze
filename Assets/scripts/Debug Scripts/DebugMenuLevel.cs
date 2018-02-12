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
    }

    public void MainMenuSetLevel(GameObject TextInputDebugGameObject)
    {
        string s = TextInputDebugGameObject.GetComponent<InputField>().text;

        try
        {
            int n = Convert.ToInt32(s);
            Level = n;
            p.level = n;
            ReloadLevel = true;
        }
        catch
        {
            TextInputDebugGameObject.GetComponent<InputField>().text = "Invalid Only number";
        }
    }
}
