using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptData : MonoBehaviour {
	private string promptText;
	public delegate void SetPrompt(string prompt);
	public static event SetPrompt setPrompt;

	public void ClearPromptText(){
		promptText = "";
	}

	public void SetPromptText(string newText){
		ClearPromptText ();
		promptText = newText;
	}

}
