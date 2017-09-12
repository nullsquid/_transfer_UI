﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Terminal : MonoBehaviour {

	TerminalStateMachine newTerminalStateMachine = new TerminalStateMachine();
    public bool canRunCommands = true;
    public bool gameHasStarted = false;
    [HideInInspector]
	public GameObject buddyList;
    public GameObject mainText;
    public GameObject videoPannel;
	void Start(){
		buddyList = GameObject.Find ("BuddyList");
        mainText = GameObject.Find("Text_Scroll");
        videoPannel = GameObject.Find("Video_Pannel");
        if (gameHasStarted == true) {
            this.newTerminalStateMachine.ChangeTerminalState(new IdleState());
            mainText.SetActive(false);
            
            buddyList.GetComponentInChildren<BuddyListController>().StartPopulate();
        }
        else {
            this.newTerminalStateMachine.ChangeTerminalState(new TitleState());
            mainText.SetActive(true);
            //buddyList.SetActive(false);
            //videoPannel.SetActive(false);
            //TurnOffEverythingONTitle();
        }
        videoPannel.SetActive(false);
        //Debug.Log(GetState());
    }

    private void Update() {
        this.newTerminalStateMachine.TerminalStateUpdate();
        Debug.Log(newTerminalStateMachine.CurState);
    }
    IEnumerator TurnOffEverythingONTitle() {
        yield return new WaitForEndOfFrame();
        buddyList.SetActive(false);
        videoPannel.SetActive(false);
        mainText.SetActive(true);
    }
    public void ChangeState(ITerminalState toState) {
        this.newTerminalStateMachine.ChangeTerminalState(toState);


            if (newTerminalStateMachine.CurState is IdleState) {
                buddyList.SetActive(true);
                videoPannel.SetActive(false);
                //buddyList.GetComponent<BuddyListController>().PopulateBuddyList();
                buddyList.GetComponentInChildren<BuddyListController>().StartPopulate();
            }
            else {

                buddyList.SetActive(false);
            }
            if (newTerminalStateMachine.CurState is ConnectState) {
                mainText.SetActive(true);
            }


            else {
                mainText.SetActive(false);
            }
            if (newTerminalStateMachine.CurState is VideoState) {
                videoPannel.SetActive(true);
            }
            else {
                videoPannel.SetActive(false);
            }
        

    }

    public void GetPrevState() {
        newTerminalStateMachine.ChangeToPreviousState();
    }

	public ITerminalState GetState() {
		//return newTerminalStateMachine.CurState.ToString ();
        return newTerminalStateMachine.CurState;
    }
}
