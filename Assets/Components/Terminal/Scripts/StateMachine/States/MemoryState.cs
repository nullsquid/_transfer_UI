using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryState : ITerminalState {
	Terminal terminal;

	public MemoryState(){
		terminal = GameObject.FindObjectOfType<Terminal> ();
	}

	public void TerminalEnterState(){
		terminal.videoPannel.SetActive (false);
		terminal.idleText.SetActive (false);
		terminal.mainText.SetActive (true);
		terminal.printer.PrintMemFileNames ();
	}

	public void TerminalExecuteState(){
		
	}

	public void TerminalExitState(){

	}



}
