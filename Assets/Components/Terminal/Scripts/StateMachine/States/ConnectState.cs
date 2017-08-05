using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class ConnectState : ITerminalState {
	SilkNode curNode;
	SilkNode savedNode;

	public ConnectState(SilkNode newNode){
		curNode = newNode;
	}

	public void TerminalEnterState(){

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
