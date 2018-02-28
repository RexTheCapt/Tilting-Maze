using System;
using System.Collections;
using System.Collections.Generic;
using Assets.scripts.VS_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataHold : MonoBehaviour
{
    Prefs p = new Prefs();
    public int Level = 0;
    public float recordTime;
    public float record
    {
        get { return p.GetPlayerLevel(SceneManager.GetActiveScene().name); }
        set { p.SetPlayerLevel(SceneManager.GetActiveScene().name, value); }
    }
    public bool resetTime = false;
    [Space(10)]
    [Header("Change the record time")]
    public float recordTimeEdit;
    public bool recordTimeEditBool;
    public bool autoLevel = true;

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        string[] s = scene.name.Split(' ');

        if(autoLevel)
        {
            Level = Convert.ToInt32(s[1]) - 1;
        }

        if (Level == 0)
            throw new IndexOutOfRangeException();
    }

    private void Update()
    {
        recordTime = record;
        if (resetTime)
        {
            record = 0f;
            resetTime = false;
        }

        if(recordTimeEditBool)
        {
            record = recordTimeEdit;
            recordTimeEditBool = false;
        }
    }
}
