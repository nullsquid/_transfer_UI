using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : ITerminalState {

	public void TerminalEnterState(){
        //exit previous state
        GameObject.FindObjectOfType<Terminal>().canRunCommands = true;
        GameObject.FindObjectOfType<Transfer.Input.MainInputController>().CanRecordInput = true;
		GameObject.FindObjectOfType<BuddyListController> ().gameObject.SetActive (true);
        Debug.Log("entered IDLE STATE");
	}

	public void TerminalExecuteState(){
        //just hang out
		if (GameObject.FindObjectOfType<BuddyListController> ().gameObject.activeSelf == false) {
			GameObject.FindObjectOfType<BuddyListController> ().gameObject.SetActive (true);
		}
        Debug.Log("IDLE STATE");
	}

	public void TerminalExitState(){
        //ummmmmmm
		GameObject.FindObjectOfType<BuddyListController>().gameObject.SetActive(false);
        Debug.Log("exited IDLE STATE");
	}


}
