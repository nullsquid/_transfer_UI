using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class TextPrinter : MonoBehaviour {
    public float letterTime = .05f;
    public float softPauseTimeBase = 0.1f;
    public float hardPauseTimeBase = 0.3f;
	public bool isBlinking = true;
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

    public string helpMenu;

	public delegate string GetTextToPrint();
	public event GetTextToPrint onNodeChange;
	#region Public Events
    public delegate void PrintCompleteAction();
    public static event PrintCompleteAction onPrintComplete;

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
		//typewriterText.text = "";
        onPrintBegin();

    }

	#endregion
	public void InvokeCharacterPrint(){
		StartCoroutine(IterateThroughCharactersToPrint(onNodeChange(), letterTime, softPauseTimeBase, hardPauseTimeBase, true));

	}

    public void InvokeHelpMenu() {
        StartCoroutine(IterateThroughCharactersToPrint(helpMenu, letterTime, softPauseTimeBase, hardPauseTimeBase, false));

    }

    public IEnumerator IterateThroughCharactersToPrint(string text, float time, float softPause, float hardPause, bool callback) {
        float normalTime = time;

        if (text != null) {
			text.TrimEnd ();
            text += "\n>>\n>>\n";
			string speaker = "";
			/*for(int j = 0; j < text.Length; j++){
				if (text [j - 1] == ':') {
					break;
				} else {
					speaker += j;
				}
			}*/
			//typewriterText.text += speaker;
            for (int i = 0; i < text.Length; i++) {
				/*if (i - 1 > 0) {
					if (typewriterText.text [i - 1] == '_') {
						typewriterText.text.Remove (i - 1, 1);
					}
				}*/
                if (text[i] == '.' || text[i] == '?' || text[i] == '!') {
                    time += hardPause / Random.Range(1, 1.5f);
                }
                else if (text[i] == ',') {
                    time += softPause / Random.Range(2.5f, 4f);
                }
                else {
                    time = normalTime;
                }

				//if (i == typewriterText.text.Length) {
				//	typewriterText.text += "_";
				//}

                onLetterPrint.Invoke();
				//typewriterText.text.Replace (typewriterText.text[typewriterText.text.Length], text[i] += '_');
				//typewriterText.text.Replace (typewriterText.text [typewriterText.text.Length], '_');
				//typewriter.text += text[i];
				typewriterText.text = (text.Substring(0, i) + "_");


                yield return new WaitForSeconds(time);

            }

			///Delete if doesn't work
			//string cursor = typewriterText.text [typewriterText.text.Length].ToString();

			//typewriterText.text += "\n::\n::";

            if (callback == true) {
                onPrintComplete();
            }
			while (isBlinking == true) {
				if (typewriterText.text [typewriterText.text.Length - 1] == '_') {
					typewriterText.text = typewriterText.text.Remove (typewriterText.text.Length - 1);
				}
				//typewriterText.text.Remove (typewriterText.text.Last - 1, 1);
				yield return new WaitForSeconds (1f);
				if (typewriterText.text [typewriterText.text.Length - 1] != '_') {
					typewriterText.text = typewriterText.text + '_';
				}
				yield return new WaitForSeconds (1f);
			}

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
