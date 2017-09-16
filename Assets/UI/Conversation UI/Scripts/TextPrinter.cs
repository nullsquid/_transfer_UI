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

	string surgeText = "...#####..." +
	                   "##########________########" +
	                   "# 6 ^&*√∂˙ßåç #" +
					   "`ú88\a∞≠\u000f\u001d¯__Ò\u0014Q]È*≤≈\u0005»,\v*Ñ\" \a$‘SäˆëáClE>e*í—ËÜ¯˙O\bk:.ü\u000eàœ\u0018XH\u001egﬁ|ª\u0016‡\u007fµ“ªÕb1˝ï?ú¿\u0018Ìë\u000f<ÂQF+∆5\u001d\u0012kI4}:˘’fk/5A" +
					   "¡®\aö(‹B≈Yé\u0017\u001e`\u001fØA^´·Õ:“M\u001e{YÆ†∏i‘íc;Ç0¿Ô∆ÍÛ8åsh∑vñâ≤HÌU[ ‡\u001f3Åœ∞´ø\u000et∞ﬁ\u0017&Ì§IMƒôÚŒ\u000600+íN-Û3Z‘Á\u00a0‹{≠\rãØ\u0002i˙Œèk®ﬁ_√e\"£Fûfr\u0014HŸ8\u0015“|Cñ÷\u0005‘\u001a\u0017/\u00141.\u0019AÀ\u0005A»\u001e¯‚≤5\vΩ\u0012Û√ö\u007fïπ#Å$Ä+ú≥\u0014cñ'‹’ø\u0017Id©{hfLàë\b'ß»Ωk÷¡+∑#—·ö≤u‘dˆOCo¡æ+∑é∆„Rø∑ö⁄?‹D°◊.≈∏\u001c\fÒÎ_≥\u001f±˜Ì˘/¬M\fx\u0013‚\u0014R_iKÅopß/\b˛È\a™˙zW‚}ÌáÔ≠JO$H≈\u0003Ñl\u0006";

	string shiftText = "ggcGagaTgAggAtgc\n" +
						"aaaAAaaGAaatAgAtCt\n" +
						"aaaa\n" +
						"aagaaaaGAcTTGAaCCTGTGA\n" +
						"aaaattaa\n" +
						"aaaaggattaaaa\n" +
						"atagggtactacaaaccaaaga\n" +
						"aaaaaatatccaaaaa\n" +
						"aaaaaggggaattactaaaaaaaa\n" +
						"aaaaaatttagaccaaaaaa\n" +
						"AaaaaGTCTactgcgtcgAggcta" +
						"cggatC" +
						"catcatcat" +
						"gaccthaAa" +
						"GAGAAAAGAGagagggcgggtttgg" +
						"ccgcggagagcgagctgcggatcaga" +
						"gcat" +
						"cat";

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
    public void InvokeErrorText(string errorMessage) {
        StartCoroutine(IterateThroughCharactersToPrint(errorMessage, 0.01f, 0f, 0f, false));
    }

    public void InvokeHelpMenu() {
        StartCoroutine(IterateThroughCharactersToPrint(helpMenu, letterTime, softPauseTimeBase, hardPauseTimeBase, false));

    }

	//I probably actually will want that callback flag to do something
	public void InvokeOpeningPrint(string text){
		StartCoroutine (IterateThroughCharactersToPrint (text, 0.01f, 0, 0, false));
	}

	public void InvokeSurgeText(){
		StartCoroutine (IterateThroughCharactersToPrint(surgeText, 0.01f, 0f, 0f, false));
	}

	public void InvokeShiftText(){
		StartCoroutine(IterateThroughCharactersToPrint(shiftText,0.01f, 0f, 0f, false));
		//StartCoroutine(IterateThroughShiftCharacters());
	}

	public IEnumerator IterateThroughShiftCharacters(){
		string mt = EffectsManager.instance.mainText.text;
		for (int i = 0; i < mt.Length; i++) {
			string newShiftText = EffectsManager.instance.mainText.text.Replace (EffectsManager.instance.mainText.text [i], shiftText [i]);
			EffectsManager.instance.mainText.text = newShiftText;
			yield return new WaitForSeconds (0.01f);
		}
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
