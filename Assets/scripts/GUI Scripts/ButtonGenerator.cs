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
    [SerializeField]
    DebugVariables debugVariables = new DebugVariables();

    private void Start()
    {
        index = SceneManager.sceneCountInBuildSettings - 2;

        for (int i = dontGenerateAt; i < index; i++)
        {
            Generate();
        }
    }

    private void Update()
    {
        while (genExtra != 0)
        {
            Generate();
            genExtra--;
        }
    }

    private void Generate()
    {
        GameObject g = Instantiate(ButtonGameObject);
        g.GetComponent<LevelAccess>().levelTarget = nextLevel;
        nextLevel++;
        //g.transform.parent = gameObject.transform;
        g.transform.SetParent(gameObject.transform);
        if(debugVariables.PrintGenerate)
            Debug.Log("Object " + g.name + " generated");
    }
}
