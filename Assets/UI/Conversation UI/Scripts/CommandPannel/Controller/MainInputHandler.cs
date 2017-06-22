﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Transfer.Input;
public class MainInputHandler : MonoBehaviour {

    //initialize Commands
    #region Private Variables
    private string _rawText;
    private string _rootCommand;
    #endregion

    #region Events

    #endregion
    //public string RootCommand { get; set; }

    public List<string> argumentList = new List<string>();
    public GameObject input;
    #region Unity Methods
    private void Start() {
        input = gameObject;
    }
    private void OnEnable() {
        MainInputController.onReturnPressed += OnInputCapture;

    }

    private void OnDisable() {
        MainInputController.onReturnPressed -= OnInputCapture;
    }
    #endregion

    IEnumerator WaitAndParseInput() {
        yield return new WaitForEndOfFrame();
        _rawText = input.GetComponent<MainInputController>().ReturnText;
        ParseInput(_rawText);

    }

    void OnInputCapture() {
        StartCoroutine(WaitAndParseInput());

    }

    #region Input Parsing Methods
    void ParseInput(string textToParse) {
        string[] _rawCommands = _rawText.Split(' ');

        _rootCommand = _rawCommands[0];
        ParseInputArgs(_rawCommands);

    }


    void ParseInputArgs(string[] _args) {
        if (_args.Length > 1) {
            for (int i = 1; i < _args.Length - 1; i++) {
                if (_args[i] != "" || _args[i] != " ")
                    argumentList.Add(_args[i]);
            }
        }
    }
    #endregion

    #region Main Methods
    void HandleInput(string _root, string[] _args) {
        if (_root == "CONNECT") {
            ConnectCommand(_args);
        }
        else if (_root == "SLEEP") {
            SleepCommand(_args);
        }
    }
    #endregion

    #region Command Methods
    void ConnectCommand(string[] _args) {

    }

    void RunCommand(string[] _args) {

    }

    void ScanCommand(string[] _args) {

    }

    void SleepCommand(string[] _args) {
        if(_args.Length == 0) {
            //SLEEP
        }
        else {
            //DON'T SLEEP, PRINT ERROR
        }
    }
    void HelpCommand(string[] _args) {
        if (_args.Length == 0) {
            //HELP
        }
        else if(_args.Length == 1 && _args[0] == "CONNECT"){
            //PRINT HELP MENU FOR CONNECT
        }

    }
    #endregion



}
