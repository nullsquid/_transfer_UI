using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningManager : MonoBehaviour {
	public List<string> openings = new List<string>();
	Terminal terminal;
	TextPrinter printer;
	public static OpeningManager instance;
	void Awake() {
		
		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}
	string oneiText = ">>\n>>\n>>\nWELCOME TO ONEIRos";
	string startText = ">>\n>>\n>>\nINPUT 'START' TO TRANSFER\n>>\nOR 'CONFIG' TO VIEW OPTIONS";
	void Start(){
		//here, the terminal seems to be null
		//terminal.canRunCommands = false;

		terminal = GameObject.FindObjectOfType<Terminal> ();
		printer = GameObject.FindObjectOfType<TextPrinter> ();
		terminal.canRunCommands = false;
		StartCoroutine (PrintOpeningCrawl ());
	}
	// Use this for initialization
	public void TriggerOpening(string openingName){
		//Debug.Log ("hey hi hey");
		switch (openingName) {
			case "9A":
				Debug.Log ("9A Opening");
				PlayNormalOpening ();
				break;
			case "9E":
				break;
			case "9I":
				break;
			case "90":
				break;
			case "9B":
				break;
			default:
				Debug.LogError ("NO TREE WITH NAME " + openingName);
			break;
		}

	}
	void PlayNormalOpening(){
		StartCoroutine (NormalOpeningRoutine ());
	}

	IEnumerator NormalOpeningRoutine(){
		printer.typewriterText.text = "";
		printer.typewriterText.text += "\nNEURAL MASK ESTABLISHED";
		yield return new WaitForSeconds(1.0f);
		printer.typewriterText.text += "\nSEARCHING FOR OPTIMAL\nCONNECTION";
        yield return new WaitForSeconds(.5f);
        for (int i = 0; i < Random.Range(1, 5); i++) {
            printer.typewriterText.text += "\n>>";
            yield return new WaitForSeconds(.5f);
        }
        printer.typewriterText.text += "\nFOUND SUITABLE HOST";
        yield return new WaitForSeconds(.1f);
        printer.typewriterText.text += "\nCONNECTING";
        for (int i = 0; i < Random.Range(1, 5); i++) {
            printer.typewriterText.text += "\n>>";
            yield return new WaitForSeconds(.5f);
        }
        yield return new WaitForSeconds(0.5f);
        printer.typewriterText.text = "";
        yield return new WaitForSeconds(1.0f);
        printer.typewriterText.text += "\nCONNECTION COMPLETE\n\nWELCOME\n";
        yield return new WaitForSeconds(2.0f);
        terminal.ChangeState(new IdleState());

    }

	IEnumerator PrintOpeningCrawl(){
		yield return new WaitForSeconds (1.5f);
		printer.InvokeOpeningPrint (oneiText);
		yield return new WaitForSeconds (1.5f);
		printer.InvokeOpeningPrint (startText);
		yield return new WaitForSeconds (0.5f);
		terminal.canRunCommands = true;

	}
}
