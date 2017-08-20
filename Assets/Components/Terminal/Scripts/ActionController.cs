using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionController : MonoBehaviour {
    
    public List<ActionBase> activeActions = new List<ActionBase>();
    //public Dictionary<string, ActionBase> activeActions = new Dictionary<string, ActionBase>();
    public Dictionary<string, ActionBase> discoveredActions = new Dictionary<string, ActionBase>();
    //As soon as this is run, it should clear out the actions dictionary
	public void ExecuteAction(string actionName) {


        for (int i = 0; i < activeActions.Count; i++) {
            if (activeActions[i].ActionName == actionName) {
                activeActions[i].ExecuteActionLogic();
                break;
            }
        }
        //i'm not sure if this is true for all instances but whatever for now
        //ClearActive();
    }
    public void ClearActive() {
        activeActions.Clear();
    }

    private void Update() {
        Debug.Log(activeActions.Count);
       // Debug.Log(activeActions["run"].ActionName + activeActions["run"].Args[0]);
    }
}
