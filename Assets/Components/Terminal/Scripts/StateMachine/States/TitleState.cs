using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleState : ITerminalState {
    Terminal terminal;
    public TitleState() {
        terminal = GameObject.FindObjectOfType<Terminal>();

    }
    public void TerminalEnterState() {
        terminal.buddyList.SetActive(false);
        terminal.videoPannel.SetActive(false);
        terminal.mainText.SetActive(true);
    }

    public void TerminalExecuteState() {
        
    }

    public void TerminalExitState() {
        
    }

    
}
