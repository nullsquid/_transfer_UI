using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipState : ITerminalState {
    Terminal terminal;
    public AudioClipState() {
        terminal = GameObject.FindObjectOfType<Terminal>();
    }
    public void TerminalEnterState() {
        //terminal.responsePannel.SetActive(false);
        //throw new NotImplementedException();
    }

    public void TerminalExecuteState() {
        //throw new NotImplementedException();
    }

    public void TerminalExitState() {
        //throw new NotImplementedException();
    }

    
}
