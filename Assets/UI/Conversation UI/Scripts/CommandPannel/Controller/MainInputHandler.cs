using System.Collections;
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

    public List<string> args = new List<string>();
	public GameObject input;

	private void Start(){
		input = gameObject;
	}
    private void OnEnable() {
        MainInputController.onReturnPressed += OnInputCapture;

    }

    private void OnDisable() {
        MainInputController.onReturnPressed -= OnInputCapture;
    }

    //TODO figure out why this isn't working
    void OnInputCapture() {
		StartCoroutine (WaitAndParseInput ());

    }
	void ParseInput(string textToParse){
		string[] _rawCommands = _rawText.Split (' ');

		_rootCommand = _rawCommands [0];
		if (_rawCommands.Length > 1) {
			for (int i = 1; i < _rawCommands.Length - 1; i++) {
				if (_rawCommands [i] != "" || _rawCommands [i] != " ")
					args.Add (_rawCommands [i]);
			}
		}
	}
	IEnumerator WaitAndParseInput(){
		yield return new WaitForEndOfFrame ();
		_rawText = input.GetComponent<MainInputController> ().ReturnText;
		ParseInput (_rawText);

	}

}
