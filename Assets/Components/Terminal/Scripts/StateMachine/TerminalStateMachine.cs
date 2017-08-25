using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalStateMachine {

	private ITerminalState curState;
	private ITerminalState prevState;

    public ITerminalState CurState
    {
        get
        {
            return curState;
        }
    }

    public ITerminalState PrevState
    {
        get
        {
            return prevState;
        }
    }

	public void ChangeTerminalState(ITerminalState newState){
		if (curState != null) {
			curState.TerminalExitState ();
		}
		prevState = curState;
		curState = newState;
		curState.TerminalEnterState ();
	}

	public void TerminalStateUpdate(){
		var runningState = this.curState;
		if (runningState != null) {
			curState.TerminalExecuteState ();
		}
	}

	public void ChangeToPreviousState(){
		curState.TerminalExitState ();
		if (prevState != null) {
			curState = prevState;
		}
		curState.TerminalEnterState ();
	}






}
