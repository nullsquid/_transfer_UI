using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpState : ITerminalState {
    string helpArg = "";
    public HelpState(string arg) {
        helpArg = "";
        helpArg = arg;
    }
    TextPrinter tp = GameObject.FindObjectOfType<TextPrinter>();
	public void TerminalEnterState() {
        //for now, clear out this way
        tp.typewriterText.text = "";
        tp.helpMenu = "";
        if (helpArg == "") {
            tp.helpMenu = "INPUT";
            tp.InvokeHelpMenu();
        }
        else {
            switch (helpArg) {

                case "CONNECT":
                    tp.helpMenu = "INPUT CONNECT FOLLOWED BY SUBJECT IDENTIFIER TO CONNECT";
                    tp.InvokeHelpMenu();
                    break;
                case "SLEEP":
                    tp.helpMenu = "SUSPEND ALL SUBSYSTEMS AND ENTER LOW POWER, LOW VISIBILITY STATE";
                    tp.InvokeHelpMenu();
                    break;
            }
        }

    }

    public void TerminalExecuteState() {


    }

    public void TerminalExitState() {

    }
}
