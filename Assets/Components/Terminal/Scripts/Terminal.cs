using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour {

	TerminalStateMachine newTerminalStateMachine = new TerminalStateMachine();
    public bool canRunCommands = true;

	void Start(){
        this.newTerminalStateMachine.ChangeTerminalState(new IdleState());
        //Debug.Log(GetState());
	}

    private void Update() {
        Debug.Log(canRunCommands);
        this.newTerminalStateMachine.TerminalStateUpdate();
    }

    public void ChangeState(ITerminalState toState) {
        this.newTerminalStateMachine.ChangeTerminalState(toState);

    }

	public ITerminalState GetState() {
		//return newTerminalStateMachine.CurState.ToString ();
        return newTerminalStateMachine.CurState;
    }
}
