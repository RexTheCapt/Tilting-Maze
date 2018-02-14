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

    private void Start()
    {
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
    }
}
