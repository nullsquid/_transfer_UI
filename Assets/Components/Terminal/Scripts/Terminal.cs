using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Terminal : MonoBehaviour {

	TerminalStateMachine newTerminalStateMachine = new TerminalStateMachine();
    public bool canRunCommands = true;
    [HideInInspector]
	public GameObject buddyList;

	void Start(){
		buddyList = GameObject.Find ("BuddyList");
        this.newTerminalStateMachine.ChangeTerminalState(new IdleState());
        //Debug.Log(GetState());
	}

    private void Update() {
        Debug.Log(canRunCommands);
        this.newTerminalStateMachine.TerminalStateUpdate();

    }

    public void ChangeState(ITerminalState toState) {
        this.newTerminalStateMachine.ChangeTerminalState(toState);
		if (newTerminalStateMachine.CurState is IdleState) {
			buddyList.SetActive (true);
		} else {
			
			buddyList.SetActive (false);
		}

    }

	public ITerminalState GetState() {
		//return newTerminalStateMachine.CurState.ToString ();
        return newTerminalStateMachine.CurState;
    }
}
