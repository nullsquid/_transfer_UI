using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButtonEventHandler : MonoBehaviour {

    #region Singleton
    //will need to add an argument to changedialogueoptions
    public delegate void ChangeDialogueOptions();
    public event ChangeDialogueOptions onDialogueSubmitted;
    public static DialogueButtonEventHandler instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    #endregion
    }
