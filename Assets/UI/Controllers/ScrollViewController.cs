using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour {

    public Scrollbar scrollBar;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.PageDown)) {
            scrollBar.value -= .1f;
        }
        else if (Input.GetKeyDown(KeyCode.PageUp)) {
            scrollBar.value += .1f;
        }
	}
}
