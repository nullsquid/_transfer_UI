using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IdleState : ITerminalState {

	public GameObject buddyList;
    Terminal terminal;

    public IdleState() {
        terminal = GameObject.FindObjectOfType<Terminal>();

    }

	public void TerminalEnterState(){
        //exit previous state
		//buddyList = GameObject.Find ("BuddyList");
        terminal.canRunCommands = true;
        GameObject.FindObjectOfType<Transfer.Input.MainInputController>().CanRecordInput = true;
        terminal.buddyList.SetActive(true);
        terminal.idleText.SetActive(true);
        terminal.mainText.SetActive(false);
        terminal.videoPannel.SetActive(false);
        terminal.buddyList.GetComponentInChildren<BuddyListController>().StartPopulate();
		terminal.memoryPannel.SetActive (false);
		GameObject.FindObjectOfType<IdleTextPrinter> ().ClearIdleText ();
        //GameObject.Find ("BuddyList").GetComponent<Image>().
        //buddyList.SetActive(true);
    }

	public void TerminalExecuteState(){
        //just hang out

	}

	public void TerminalExitState(){
        terminal.idleText.SetActive(false);
        //ummmmmmm
		//GameObject.FindObjectOfType<BuddyListController>().gameObject.SetActive(false);
		//buddyList.SetActive(false);
		//GameObject.Find("BuddyList").GetComponent<Image>().canvasRenderer.SetAlpha(1.0f);
	}


}
