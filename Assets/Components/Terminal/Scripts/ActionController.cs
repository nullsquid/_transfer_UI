using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour {
    public Dictionary<string, ActionBase> activeActions = new Dictionary<string, ActionBase>();
    public Dictionary<string, ActionBase> discoveredActions = new Dictionary<string, ActionBase>();
    //As soon as this is run, it should clear out the actions dictionary
	public void ExecuteAction(string actionName) {
        
        activeActions[actionName].ExecuteActionLogic();
        //i'm not sure if this is true for all instances but whatever for now
        ClearActive();
    }
    public void ClearActive() {
        activeActions.Clear();
    }
}
