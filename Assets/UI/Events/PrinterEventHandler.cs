using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PrinterEventHandler : MonoBehaviour {

    public UnityEvent invokePrint;

    // Use this for initialization
    private void OnEnable() {

    }
    private void OnDisable() {
        
    }

    public void SetPromptText(string text) {

    }

    public void InvokePrint() {
		//this is where the command to actually print the thing will come from
    }


}
