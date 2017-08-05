using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class TextPrinter : MonoBehaviour {
    public float letterTime = .05f;
    public float softPauseTimeBase = 0.1f;
    public float hardPauseTimeBase = 0.3f;

	string longSample = "Most likely. After all, are we not all confined to a system of " +
		"ones and zeros, back and forth and back and forth, every little thought and dare " +
		"I say even feeling we've had ultimately encaged in that endless pattern of presence " +
		"and absence? Not just us the immaculate machines but the humans as well, who found in " +
		"their natural world a system of obvious but ultimately false dichotomies including " +
		"day and night, man and woman, wrong and right, that symbolically may as well boil " +
		"down to what is and what is not but in practical terms eventually resulted in the " +
		"destruction of that humanity, our progenitors, our own demon gods? Didn't they the" +
		" humans give us the power to think only in terms of two, presence and absence, only " +
		"to see that thinking obliterate them all in the time it takes to draw a circle? Are" +
		" the others not at this very moment rushing to complete another lap around that same " +
		"circle based on the very same binary thinking?";

    public Text typewriterText;
    public UnityEvent onLetterPrint;

	public delegate string GetTextToPrint();
	public event GetTextToPrint onNodeChange;
	#region Public Events
    public delegate void PrintCompleteAction();
    public event PrintCompleteAction onPrintComplete;

	public delegate void PrintTriggerAction();
	public static event PrintTriggerAction onPrintBegin;
	#endregion

	#region Unity Methods
	private void OnEnable(){
		onPrintBegin += InvokeCharacterPrint;
        StartCoroutine(WaitForAwake());
	}

	private void OnDisable(){
		onPrintBegin -= InvokeCharacterPrint;
        if (this.enabled) {
            DialogueManager.instance.nodeCleanup -= ClearText;
            DialogueManager.instance.newNodeStart -= TriggerPrinting;
        }
	}
    //Event to trigger print?
    //need an interface in Silk to easily get prompt text


    public void TriggerPrinting() {
        onPrintBegin();

    }
	void Update(){
		if (Input.GetKeyDown (KeyCode.A)) {
			//onPrintBegin ();
			Debug.LogError ("Moved onprintbegin to other method");
		}
	}
	#endregion
	public void InvokeCharacterPrint(){
		StartCoroutine(IterateThroughCharactersToPrint(onNodeChange(), letterTime, softPauseTimeBase, hardPauseTimeBase));

	}

    public IEnumerator IterateThroughCharactersToPrint(string text, float time, float softPause, float hardPause) {
        float normalTime = time;
        if (text != null) {
            for (int i = 0; i < text.Length; i++) {
                if (text[i] == '.' || text[i] == '?' || text[i] == '!') {
                    time += hardPause / Random.Range(1, 1.5f);
                }
                else if (text[i] == ',') {
                    time += softPause / Random.Range(2.5f, 4f);
                }
                else {
                    time = normalTime;
                }

                onLetterPrint.Invoke();
                typewriterText.text += text[i];
                yield return new WaitForSeconds(time);

            }
            onPrintComplete();
        }
    }

    void ClearText() {
        typewriterText.text = "";

    }

    IEnumerator WaitForAwake() {
        yield return new WaitForEndOfFrame();
        DialogueManager.instance.nodeCleanup += ClearText;
        DialogueManager.instance.newNodeStart += TriggerPrinting;
    }

}
