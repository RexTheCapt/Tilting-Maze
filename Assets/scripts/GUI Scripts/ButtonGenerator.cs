using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonGenerator : MonoBehaviour
{
    public GameObject ButtonGameObject;
    private int index;
    [Serializable]
    class DebugVariables
    {
        public bool PrintGenerate = false;
    }

    public int dontGenerateAt = 2;
    public int nextLevel = 1;
    public int genExtra = 0;
    public bool DebugButton = false;
    [SerializeField]
    DebugVariables debugVariables = new DebugVariables();

    private void Start()
    {
        index = SceneManager.sceneCountInBuildSettings - 3;

        for (int i = dontGenerateAt; i < index; i++)
        {
            Generate();
        }

        if(DebugButton)
            Generate(true);
    }

    private void Update()
    {
        while (genExtra != 0)
        {
            Generate();
            genExtra--;
        }
    }

    private void Generate(bool deb = false)
    {
        GameObject g = Instantiate(ButtonGameObject);
        if (!deb)
        {
            g.GetComponent<LevelAccess>().levelTarget = nextLevel;
            nextLevel++;
        }
        else
        {
            g.GetComponent<LevelAccess>().levelTarget = -1;
            g.name = "Debug Button";
        }
        g.transform.SetParent(gameObject.transform);
        if(debugVariables.PrintGenerate)
            Debug.Log("Object " + g.name + " generated");
    }
}
