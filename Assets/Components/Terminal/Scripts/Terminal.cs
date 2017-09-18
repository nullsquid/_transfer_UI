using System.Collections;
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
    public GameObject idleText;
	public GameObject memoryPannel;

    public TextPrinter printer;
    void Start(){
        printer = GameObject.FindObjectOfType<TextPrinter>();
		buddyList = GameObject.Find ("BuddyList");
        idleText = GameObject.Find("IdleText");
        mainText = GameObject.Find("Text_Scroll");
        videoPannel = GameObject.Find("Video_Pannel");
		memoryPannel = GameObject.Find ("MemoryPannel");
        if (gameHasStarted == true) {
            this.newTerminalStateMachine.ChangeTerminalState(new IdleState());
            //mainText.SetActive(false);
            
            //buddyList.GetComponentInChildren<BuddyListController>().StartPopulate();
        }
        else {
            this.newTerminalStateMachine.ChangeTerminalState(new TitleState());
            //mainText.SetActive(true);
        }
        //videoPannel.SetActive(false);
        //Debug.Log(GetState());
    }

    private void Update() {
        this.newTerminalStateMachine.TerminalStateUpdate();
        //Debug.Log(newTerminalStateMachine.CurState);
    }

    public void ChangeState(ITerminalState toState) {
        this.newTerminalStateMachine.ChangeTerminalState(toState);


            if (newTerminalStateMachine.CurState is IdleState) {
                //buddyList.SetActive(true);
                //videoPannel.SetActive(false);
                //buddyList.GetComponent<BuddyListController>().PopulateBuddyList();
                //buddyList.GetComponentInChildren<BuddyListController>().StartPopulate();
            }
            else {

                //buddyList.SetActive(false);
            }
            if (newTerminalStateMachine.CurState is ConnectState) {
                //mainText.SetActive(true);
            }


            else {
                //mainText.SetActive(false);
            }
            if (newTerminalStateMachine.CurState is VideoState) {
                videoPannel.SetActive(true);
            idleText.SetActive(false);
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
