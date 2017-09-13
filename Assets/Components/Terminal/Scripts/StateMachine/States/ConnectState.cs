﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class ConnectState : ITerminalState {
	SilkNode curNode;
	SilkNode savedNode;
    Terminal terminal;

    public ConnectState() {
        if (terminal == null) {
            terminal = GameObject.FindObjectOfType<Terminal>();
        }
    }

	public void TerminalEnterState(){
        terminal.buddyList.SetActive(false);
        terminal.idleText.SetActive(false);

        terminal.mainText.SetActive(true);
        foreach (SilkTagBase tag in DialogueManager.instance.CurNode.connectQueue){
            if (tag.TagName == "wait") {
                TextPrinter.onPrintComplete += tag.TagExecute;
            }
            else {
                tag.TagExecute();
            }
		}
        Debug.Log("ENTERED CONNECTED STATE");
    }

	public void TerminalExecuteState(){
        //Graph search?
        //Make the UI the way that it needs to be
        Debug.Log("CONNECTED STATE");
	}

	public void TerminalExitState(){
        Debug.Log("EXITED CONNECTED STATE");
        terminal.buddyList.SetActive(true);
        terminal.mainText.SetActive(false);
        //Save current node
        //exit state
    }

}
