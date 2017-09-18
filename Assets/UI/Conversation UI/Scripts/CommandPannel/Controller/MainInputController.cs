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
                        Debug.Log(e);
                        AddText(e);
                    }
                    else if(e.keyCode == KeyCode.Alpha1 || e.keyCode == KeyCode.Keypad1) {
                        Add1();
                    }
                    else if (e.keyCode == KeyCode.Alpha2 || e.keyCode == KeyCode.Keypad2) {
                        Add2();
                    }
                    else if (e.keyCode == KeyCode.Alpha3 || e.keyCode == KeyCode.Keypad3) {
                        Add3();
                    }
                    else if (e.keyCode == KeyCode.Alpha4 || e.keyCode == KeyCode.Keypad4) {
                        Add4();
                    }
                    else if (e.keyCode == KeyCode.Alpha5 || e.keyCode == KeyCode.Keypad5) {
                        Add5();
                    }
                    else if (e.keyCode == KeyCode.Alpha6 || e.keyCode == KeyCode.Keypad6) {
                        Add6();
                    }
                    else if (e.keyCode == KeyCode.Alpha7 || e.keyCode == KeyCode.Keypad7) {
                        Add7();
                    }
                    else if (e.keyCode == KeyCode.Alpha8 || e.keyCode == KeyCode.Keypad8) {
                        Add8();
                    }
                    else if (e.keyCode == KeyCode.Alpha9 || e.keyCode == KeyCode.Keypad9) {
                        Add9();
                    }
                    else if (e.keyCode == KeyCode.Alpha0 || e.keyCode == KeyCode.Keypad0) {
                        Add0();
                    }
                    else if(e.keyCode >= KeyCode.Keypad1 &&  e.keyCode <= KeyCode.Keypad0) {
                        AddText(e);
                    }
                    else if(e.keyCode == KeyCode.Period) {
                        AddPeriod();
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
                return _inputText += e.keyCode.ToString();
            }
            return null;
        }
        private void AddPeriod() {
            _inputText += ".";
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
        void Add1() {
            _inputText += "1";
        }
        void Add2() {
            _inputText += "2";
        }
        void Add3() {
            _inputText += "3";
        }
        void Add4() {
            _inputText += "4";
        }
        void Add5() {
            _inputText += "5";
        }
        void Add6() {
            _inputText += "6";
        }
        void Add7() {
            _inputText += "7";
        }
        void Add8() {
            _inputText += "8";
        }
        void Add9() {
            _inputText += "9";
        }
        void Add0() {
            _inputText += "0";
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
