using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleState : ITerminalState {
    Terminal terminal;
    MainInputHandler input;
	bool openingStarted = false;
    public TitleState() {
        terminal = GameObject.FindObjectOfType<Terminal>();
        input = GameObject.FindObjectOfType<MainInputHandler>();

    }
    public void TerminalEnterState() {
        terminal.buddyList.SetActive(false);
        terminal.videoPannel.SetActive(false);
        terminal.mainText.SetActive(true);
        terminal.idleText.SetActive(false);
    }

    public void TerminalExecuteState() {

		if (terminal != null) {
            if (terminal.GetComponentInChildren<Transfer.Input.MainInputController>().ReturnText.TrimEnd() == "START") {
				if (openingStarted == false) {
					InvokeOpening ();
				}
            }
        }
    }

    public void TerminalExitState() {
        
    }

	void InvokeOpening(){
		OpeningManager.instance.TriggerOpening (DialogueManager.instance.CurStory.StoryName);
		openingStarted = true;
	}

    
}
