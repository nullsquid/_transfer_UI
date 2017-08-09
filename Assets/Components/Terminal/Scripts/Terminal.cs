using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour {

	TerminalStateMachine newTerminalStateMachine = new TerminalStateMachine();

	void Start(){
        this.newTerminalStateMachine.ChangeTerminalState(new IdleState());
	}

    private void Update() {
        this.newTerminalStateMachine.TerminalStateUpdate();
    }

    void ChangeState(ITerminalState toState) {
        //newTerminalStateMachine
        /*switch (toState) {
            case "CONNECT":
                break;
            case "HELP":

                break;
        }*/

    }

}
