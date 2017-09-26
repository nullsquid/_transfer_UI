﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpState : ITerminalState {
    string helpArg = "";
    Terminal terminal;
    TextPrinter tp;
    public HelpState(string arg) {
        helpArg = "";
        helpArg = arg;
        
        terminal = GameObject.FindObjectOfType<Terminal>();
    }
	public void TerminalEnterState() {
        //for now, clear out this way
        tp = GameObject.FindObjectOfType<TextPrinter>();
        //Debug.Log(tp);
        terminal.mainText.SetActive(true);
        terminal.idleText.SetActive(false);
        terminal.printer.typewriterText.text = "";
        terminal.printer.helpMenu = "";
        terminal.canRunCommands = false;
        if (helpArg == "") {
            terminal.printer.helpMenu = "\n>>INPUT 'CONNECT' FOLLOWED BY USER ID OF RECIPIENT TO COMMUNICATE\n\n>>INPUT 'SLEEP' TO SUSPEND OPERATIONS" +
                                        "\n\n>>INPUT 'MEMORY' TO VIEW .mem FILES";
            terminal.printer.InvokeHelpMenu();
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
