using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class ConnectState : ITerminalState {
	SilkNode curNode;
	SilkNode savedNode;
    Terminal terminal;
    public ConnectState() {
        terminal = GameObject.FindObjectOfType<Terminal>();
    }

	public void TerminalEnterState(){
        terminal.canRunCommands = false;
		//DialogueManager.instance.
		//Find Correct Tree
		//find correct node
		//run current node on dialogue manager
	}

	public void TerminalExecuteState(){
		//Graph search?
		//Make the UI the way that it needs to be
	}

	public void TerminalExitState(){
		//Save current node
		//exit state
	}

}
