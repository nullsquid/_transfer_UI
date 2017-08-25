using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using Transfer.System;
namespace Transfer.Input {
    public class MainInputController : MonoBehaviour {
        #region Private Variables
        //private List<string> args = new List<string>();

		public bool _canRecordInput = true;
        private string _inputText = "";
        private string _returnText;


        #endregion

        #region Inspector Variables
        public int commandLength = 30;
        #endregion
        
        #region Public Accessors
        public string ReturnText
        {
            get
            {
                return _returnText;
            }



        }

        public string InputText
        {
            get
            {
                return _inputText;
            }
        }

        public bool CanRecordInput
        {
            set
            {
                _canRecordInput = value;
            }
        }
        #endregion

        #region Public Events

        public delegate void ReturnAction();
        public static event ReturnAction onReturnPressed;
        #endregion

        public string UpdateInput(Event e) {

            if (_canRecordInput) {
                if (e.keyCode != KeyCode.None) {

                    if (e.keyCode >= KeyCode.A && e.keyCode <= KeyCode.Z) {
                        //get only alphabetical characters
                        AddText(e);
                    }
                    else if(e.keyCode >=  KeyCode.Alpha1 && e.keyCode <= KeyCode.Alpha0) {
                        AddText(e);
                    }
                    else if (e.keyCode == KeyCode.Backspace) {
                        RemoveText();
                    }
                    else if (e.keyCode == KeyCode.Space) {
                        AddSpace();
                    }
                    else if (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter) {
                        EnterCommand();
                        _inputText = "";

                    }
                }
            }
            return null;
        }
        private string AddText(Event e) {
            if (_inputText.Length <= commandLength) {
                return _inputText += e.keyCode;
            }
            return null;
        }

        private void AddSpace() {
            _inputText += " ";

        }

        private void RemoveText() {
            
            if (_inputText.Length > 0) {
                _inputText = _inputText.Remove(_inputText.Length - 1);

            }
        }

        private void EnterCommand() {
            onReturnPressed();
            _returnText = ReturnInputText(_inputText);

        }
        private string ReturnInputText(string inputText) {
            inputText += " ";
            return inputText;
        }

        IEnumerator WaitAndEnter() {
            yield return new WaitForEndOfFrame();

        }



    }
}
