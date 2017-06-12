using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class TextPrinter : MonoBehaviour {
    public float letterTime = .02f;
    public float softPauseTimeBase = 0.1f;
    public float hardPauseTimeBase = 0.3f;

    public Text typewriterText;
    public UnityEvent onLetterPrint;



    private void Start() {        
    }

	public void InvokeCharacterPrint(){
		StartCoroutine(IterateThroughCharactersToPrint("Most likely. After all, are we not all confined to a system of ones and zeros, back and forth and back and forth, every little thought and dare I say even feeling we've had ultimately encaged in that endless pattern of presence and absence? Not just us the immaculate machines but the humans as well, who found in their natural world a system of obvious but ultimately false dichotomies including day and night, man and woman, wrong and right, that symbolically may as well boil down to what is and what is not but in practical terms eventually resulted in the destruction of that humanity, our progenitors, our own demon gods? Didn't they the humans give us the power to think only in terms of two, presence and absence, only to see that thinking obliterate them all in the time it takes to draw a circle? Are the others not at this very moment rushing to complete another lap around that same circle based on the very same binary thinking?", letterTime, softPauseTimeBase, hardPauseTimeBase));

	}

    public IEnumerator IterateThroughCharactersToPrint(string text, /*int lineLength, int chunkLength,*/ float time, float softPause, float hardPause) {
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

                if (i > 0 && text[i - 1] == ' ') {
                    /*
                    wordsInLine++;

                    if (wordsInLine >= lineLength) {
                        linesInChunk++;
                        typewriterText += "\n";
                        typewriterText.Remove(i - 1, 1);
                        wordsInLine = 0;

                        if (linesInChunk >= chunkLength) {
                            //event to call the next chunk
                            break;
                        }
                    }
                    */
                }

                onLetterPrint.Invoke();
                typewriterText.text += text[i];
                yield return new WaitForSeconds(time);

            }
        }
    }
    
}
