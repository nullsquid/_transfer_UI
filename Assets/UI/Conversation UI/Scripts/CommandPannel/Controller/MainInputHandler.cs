using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Transfer.Input;
public class MainInputHandler : MonoBehaviour {

    Terminal terminal;

    //initialize Commands
    #region Private Variables
    private string _rawText;
    private string _rootCommand;
    #endregion

    public string RawText
    {
        get
        {
            return _rawText;
        }
    }
    #region Events

    #endregion
    //public string RootCommand { get; set; }
	void Update(){
		//Debug.LogWarning (_rawText.Length);
	}

    public List<string> argumentList = new List<string>();
    public GameObject input;
    #region Unity Methods
    private void Start() {
        input = gameObject;
        terminal = GameObject.FindObjectOfType<Terminal>();
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
        argumentList.Clear();
        if (_args.Length > 1) {
            for (int i = 1; i < _args.Length - 1; i++) {
                if (_args[i] != "" || _args[i] != " ")
                    argumentList.Add(_args[i]);
            }
        }
        if (terminal.canRunCommands == true) {
            HandleInput(_rootCommand, argumentList.ToArray());
        }
    }
    #endregion

    #region Main Methods
    void HandleInput(string _root, string[] _args) {
        //if (terminal.GetState() is IdleState) {
        //if(terminal.canRunCommands == true) { 
            Debug.Log("boops boops");
            if (_root == "CONNECT") {
                ConnectCommand(_args);
            }
            else if (_root == "SLEEP") {
                SleepCommand(_args);
            }

            else if (_root == "HELP") {
                HelpCommand(_args);
            }
			else{
			//else if(terminal.GetComponent<ActionController>().activeActions.){
				for (int i = 0; i < terminal.GetComponent<ActionController> ().activeActions.Count; i++) {
					if (terminal.GetComponent<ActionController> ().activeActions [i].ActionName == _root) {
						terminal.GetComponent<ActionController> ().activeActions [i].ExecuteActionLogic ();
					}
				}
			
			//}
			}
        //}
    }
    #endregion

    #region Command Methods
    void ConnectCommand(string[] _args) {
        if (_args.Length == 1) {
			if (terminal.GetState() is IdleState) {
				if (_args [0] == DialogueManager.instance.connectID) {
				
					terminal.ChangeState (new ConnectState ());
					GameObject.FindObjectOfType<TextPrinter> ().TriggerPrinting ();
					Debug.Log ("CONNECTED " + _args [0]);
				} else {
					Debug.LogError ("NO ID FOUND");
				}
			}
        }
        else if(_args.Length <= 1) {
            Debug.LogError("TOO FEW ARGUMENTS");
        }
        else {
            Debug.LogError("TOO MANY ARGUMENTS");
        }
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
        HelpState helpState = null;
        if (_args.Length == 1) {
            helpState = new HelpState(_args[0]);
            helpState.TerminalEnterState();
        }
        
        else if (_args.Length == 0) {
            //HELP
            helpState = new HelpState("");
            helpState.TerminalEnterState();
        }

    }
    #endregion



}
