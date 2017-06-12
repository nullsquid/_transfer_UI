using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PrinterEventHandler : MonoBehaviour {

    public UnityEvent newEvent;
    // Use this for initialization
    private void OnEnable() {
        if(newEvent == null) {
            newEvent = new UnityEvent();
        }

    }

    // Update is called once per frame
    void Update () {
		
	}

}
