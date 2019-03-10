using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //allows access to the Unity UI

public class AdventureGame : MonoBehaviour
{
    //SerializeField - makes variable available in Inspector tab
    //Text is a UI keyword, needs UnityEngine.UI namespace
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    //variable for the current state
    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        //textComponent - part of Story Text in Inspector (w/T icon next to it), .text is the text field (editable text area)
        //calls GetStateStory() from State.cs
        textComponent.text = state.GetStateStory();
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        //because this returns an array of type State, VS knows var = State[]; var is a shortcut
        //can be used when a variable is declared and initialized
        var nextStates = state.GetNextStates();

        for (int index = 0; index < nextStates.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index) || Input.GetKeyDown(KeyCode.Keypad1 + index))
            {
                state = nextStates[index];
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //should quit, I hope...
            Application.Quit();
        }

        textComponent.text = state.GetStateStory();
    }
}
