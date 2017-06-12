using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour {
    public delegate void OnNewPrompt(string promptText);
    public static event OnNewPrompt printPrompt;
    // Use this for initialization
    #region Singleton
    private static UIEventHandler _instance;
    public static UIEventHandler Instance
    {
        get
        {
            if (_instance == null) {
                GameObject uiHandler = new GameObject("UI_EventHandler");
                uiHandler.AddComponent<UIEventHandler>();

            }
            return _instance;
        }

    }
    void Awake() {
        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);

    }
    #endregion

    private void OnEnable() {
        
    }

    private void OnDisable() {
        
    }

    public void InvokePrint() {
        
    }


}
