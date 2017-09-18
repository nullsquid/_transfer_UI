using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour {

    public Scrollbar scrollBar;
	public TextPrinter printer;
	bool printComplete = false;

	void OnEnable(){
		//printer.on
		TextPrinter.onPrintBegin += StartPrinting;
		TextPrinter.onPrintComplete += FinishedPrinting;
	}

	void OnDisable(){
		TextPrinter.onPrintBegin -= StartPrinting;
		TextPrinter.onPrintComplete -= FinishedPrinting;
	}
	// Update is called once per frame
	void Update () {
		if (printComplete == true) {
			if (Input.GetKeyDown (KeyCode.RightBracket)) {
				scrollBar.value -= .1f;
			} else if (Input.GetKeyDown (KeyCode.LeftBracket)) {
				scrollBar.value += .1f;
			}
		} else if (printComplete == false) {
			scrollBar.value = 0;
		}
	}

	void FinishedPrinting(){
		printComplete = true;
	}

	void StartPrinting(){
		scrollBar.value = 1;
		printComplete = false;
	}
}
