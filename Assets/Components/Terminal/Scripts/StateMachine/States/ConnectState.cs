using System.Collections;
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
		foreach(SilkTagBase tag in DialogueManager.instance.CurNode.connectQueue){
            if (tag.TagName == "wait") {
                TextPrinter.onPrintComplete += tag.TagExecute;
            }
            else {
                tag.TagExecute();
            }
		}
        //terminal.canRunCommands = false;
        //GameObject.FindObjectOfType<Transfer.Input.MainInputController>().CanRecordInput = false;
        //DialogueManager.instance.
        //Find Correct Tree
        //find correct node
        //run current node on dialogue manager
        Debug.Log("ENTERED CONNECTED STATE");
    }

	public void TerminalExecuteState(){
        //Graph search?
        //Make the UI the way that it needs to be
        Debug.Log("CONNECTED STATE");
	}

	public void TerminalExitState(){
        Debug.Log("EXITED CONNECTED STATE");
        //Save current node
        //exit state
    }

}
