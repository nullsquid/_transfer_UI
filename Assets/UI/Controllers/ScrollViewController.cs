using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyExtensions;
public class ScrollViewController : MonoBehaviour {

    public Scrollbar scrollBar;
	public TextPrinter printer;
	bool printComplete = false;
    public Text mainText;
    float startPosY;
    float startPosX;

    private void Start() {
        startPosY = mainText.rectTransform.position.y;
        startPosX = mainText.rectTransform.position.x;
    }

    void OnEnable(){
		//printer.on
		TextPrinter.onPrintBegin += StartPrinting;
		TextPrinter.onPrintComplete += FinishedPrinting;
        DialogueManager.instance.nodeCleanup += ResetScroll;
	}

	void OnDisable(){
		TextPrinter.onPrintBegin -= StartPrinting;
		TextPrinter.onPrintComplete -= FinishedPrinting;
        DialogueManager.instance.nodeCleanup -= ResetScroll;
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
    void ResetScroll() {
        Debug.Log("boop");
        //if(mainText.rectTransform.position.y != startPosY) {
        mainText.rectTransform.SetHeight(startPosY);
        //mainText.rectTransform.position = new Vector3(startPosX, -0.00012f,0f);
            
        //}
        scrollBar.value = 1;
        //mainText.GetComponent<RectTransform>().position.y = startPosY;

    }
	void StartPrinting(){
        scrollBar.size = 1;
		scrollBar.value = 0;
		printComplete = false;
	}
}
