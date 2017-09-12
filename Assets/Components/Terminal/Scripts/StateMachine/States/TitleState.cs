using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleState : ITerminalState {
    Terminal terminal;
    MainInputHandler input;
    public TitleState() {
        terminal = GameObject.FindObjectOfType<Terminal>();
        input = GameObject.FindObjectOfType<MainInputHandler>();

    }
    public void TerminalEnterState() {
        terminal.buddyList.SetActive(false);
        terminal.videoPannel.SetActive(false);
        terminal.mainText.SetActive(true);
    }

    public void TerminalExecuteState() {
        //Debug.Log("hi??");
        //probably won't want to do parsing here as i already wrote that code

        Debug.Log(terminal.GetComponentInChildren<Transfer.Input.MainInputController>().ReturnText + "<<");
        if (terminal.GetComponentInChildren<Transfer.Input.MainInputController>().ReturnText.TrimEnd() != null) {
            if (terminal.GetComponentInChildren<Transfer.Input.MainInputController>().ReturnText.TrimEnd() == "START") {
                Debug.Log("yo?");
            }
        }
    }

    public void TerminalExitState() {
        
    }

    
}
