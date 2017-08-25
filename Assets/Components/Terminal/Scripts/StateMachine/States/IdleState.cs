﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IdleState : ITerminalState {

	public GameObject buddyList;


	public void TerminalEnterState(){
        //exit previous state
		//buddyList = GameObject.Find ("BuddyList");
        GameObject.FindObjectOfType<Terminal>().canRunCommands = true;
        GameObject.FindObjectOfType<Transfer.Input.MainInputController>().CanRecordInput = true;
		//GameObject.Find ("BuddyList").GetComponent<Image>().
		//buddyList.SetActive(true);
	}

	public void TerminalExecuteState(){
        //just hang out

	}

	public void TerminalExitState(){
        //ummmmmmm
		//GameObject.FindObjectOfType<BuddyListController>().gameObject.SetActive(false);
		//buddyList.SetActive(false);
		//GameObject.Find("BuddyList").GetComponent<Image>().canvasRenderer.SetAlpha(1.0f);
	}


}
