﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Transfer.Input;
public class MainInput : MonoBehaviour {
    public Text commandDisplay;
    public MainInputController input;

    string _curText = "";
    string _newText;
	// Use this for initialization
	void Start () {
		//TERMINAL@ + CharacterName
	}

    private void OnGUI() {
        Event e = Event.current;
        if(e.type == EventType.keyDown) {
            input.UpdateInput(e);
        }
        _newText = input.InputText;

        if (commandDisplay.text.Length <= 30) {
            commandDisplay.text = _curText + _newText;
        }
        //_returnText = input.ReturnText;
        //newText = input.InputText;
    }


}
