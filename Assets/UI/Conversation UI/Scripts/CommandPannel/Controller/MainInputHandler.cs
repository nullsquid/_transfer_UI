using System.Collections;
using System.Collections.Generic;
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

    public List<string> args = new List<string>();
    public MainInputController input;

    private void OnEnable() {
        MainInputController.onReturnPressed += OnInputCapture;
    }

    private void OnDisable() {
        MainInputController.onReturnPressed -= OnInputCapture;
    }

    //TODO figure out why this isn't working
    void OnInputCapture() {
        Debug.Log("capture");
        _rawText = input.ReturnText;
    }

}
