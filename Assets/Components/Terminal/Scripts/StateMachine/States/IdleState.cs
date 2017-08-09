using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : ITerminalState {

	public void TerminalEnterState(){
        //exit previous state
        Debug.Log("entered IDLE STATE");
	}

	public void TerminalExecuteState(){
        //just hang out
        Debug.Log("IDLE STATE");
	}

	public void TerminalExitState(){
        //ummmmmmm
        Debug.Log("exited IDLE STATE");
	}


}
