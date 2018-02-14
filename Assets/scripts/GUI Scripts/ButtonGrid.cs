using System;
using System.Collections.Generic;
using System.Linq;
using Assets.scripts.VS_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonGrid : MonoBehaviour
{
    private GuiTools gt = new GuiTools(); // Make it a little easier to work with my GUI elements
    [HideInInspector]
    public List<GameObject> ButtonList = new List<GameObject>(); // A list of all buttons on the menu
    [Serializable]
    private class gridPosition
    {
        public int x = -1;
        public int y = -1;
    }
    [Serializable]
    private class DebugVariables
    {
        [Header("Controller")]
        public bool PrintNameChange = false;
        public bool PrintNames = false;
        [Header("Button")]
        public bool PrintRegister = false;
    }

    public bool isController = false; // Used to identify as the controller to place the buttons
    [Header("The controller object")] public GameObject Controller; // The the controller object to control the buttons
    [SerializeField] private gridPosition grid = new gridPosition();
    [SerializeField] DebugVariables debugVariables = new DebugVariables();
    public bool SetPlacement = false;
    public bool controllerReplaceAll = false;

    private void Start()
    {
        // If this object is not the controller and register delay is the same or
        // lower than deltaTime then register with the controller
        if (!isController)
        {
            // register this object with the controller so the controller can move this object
            /* Return codes:
             * 0: Registration failed. Something has happened that made the script make an error.
             * 1: Registration was a success and got added to the controller's gameobject list.
             * 2: Registration failed but object was already in the list so dont need to do anything.
             */
            switch (Controller.GetComponent<ButtonGrid>().Register(gameObject))
            {
                case 0:
                    if(debugVariables.PrintRegister)
                        Debug.Log("Registration to controller failed");
                    break;
                case 1:
                    if(debugVariables.PrintRegister)
                        Debug.Log("Registration to controller success");
                    break;
                case 2:
                    break;
            }
        }
    }

    private void Update()
    {
        if (isController)
        {
            // The grid coordinates
            int x = 0, y = 0;

            // Sort list
            List<GameObject> lg = ButtonList.OrderBy(go => go.GetComponent<LevelAccess>().levelTarget).ToList();
            ButtonList = lg;

            // Go thru all the objects in the list
            foreach (GameObject g in ButtonList)
            {
                if (g.name != "Level " + (g.GetComponent<LevelAccess>().levelTarget + 1))
                {
                    g.name = "Level " + (g.GetComponent<LevelAccess>().levelTarget + 1);
                    g.GetComponentInChildren<Text>().text = "Level " + (g.GetComponent<LevelAccess>().levelTarget + 1);
                    if(debugVariables.PrintNames && debugVariables.PrintNameChange)
                        Debug.Log("Name set to " + g.name);
                    else if (debugVariables.PrintNameChange)
                        Debug.Log("Name changed");
                }

                g.GetComponent<ButtonGrid>().grid.x = x;
                g.GetComponent<ButtonGrid>().grid.y = y;
                g.GetComponent<ButtonGrid>().SetPlacement = true;

                x++;

                if (x == 5)
                {
                    x = 0;
                    y++;
                }
            }
        }
        else if (SetPlacement)
        {
            Vector2 pos = new Vector2();
            pos.x = ((grid.x * gt.screenWidth(20)) - gt.screenWidth(50));
            pos.y = 0 - (grid.y * gt.screenHeight(20));
            transform.localPosition = pos;

            SetPlacement = false;
        }

        if (controllerReplaceAll)
        {
            foreach (GameObject g in ButtonList)
            {
                g.GetComponent<ButtonGrid>().SetPlacement = true;
                controllerReplaceAll = false;
            }
        }
    }

    public int Register(GameObject gameObject)
    {
        // Check if object already exists
        if (ButtonList.Contains(gameObject))
            return 2;

        try
        {
            // Add object to list
            ButtonList.Add(gameObject);

            // If successful then return 1
            if (ButtonList.Contains(gameObject))
            {
                return 1;
            }
        }
        catch
        {
            return 0;
        }

        // If failed return 0
        return 0;
    }
}