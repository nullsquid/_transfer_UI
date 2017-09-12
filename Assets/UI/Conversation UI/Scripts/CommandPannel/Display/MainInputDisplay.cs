using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Transfer.Input;
using Transfer.Data;
public class MainInputDisplay : MonoBehaviour {
    public Text commandDisplay;
    public MainInputController input;
	public bool isBlinking = true;
    string _prompt;
    string _curText = "";
    string _newText;
	string cursor = "";

    public string CurText{
        get
        {
            return _curText;
        }
    }
	// Use this for initialization
	void Start () {
		
		_prompt = "TERMINAL@" + CharacterDatabase.GetPlayerName() + "$>>";
		StartCoroutine (CursorBlink ());
	}
    
    private void OnGUI() {
        Event e = Event.current;
        if(e.type == EventType.keyDown) {
            input.UpdateInput(e);
        }
        _newText = input.InputText;


		commandDisplay.text = _prompt + _curText + _newText + cursor;
        
        //_returnText = input.ReturnText;
        //newText = input.InputText;
    }

	IEnumerator CursorBlink(){
		while (isBlinking == true) {
			cursor = "_";
			yield return new WaitForSeconds (1f);
			cursor = "";
			yield return new WaitForSeconds (1f);
		}

	}


}
