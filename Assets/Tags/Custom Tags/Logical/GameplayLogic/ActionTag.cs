using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class ActionTag : SilkTagBase {
    List<string> actArgs = new List<string>();
    ActionController controller;
    public ActionTag(string name, List<string> args) {
        TagName = name;
        //Actually not sure
        type = TagType.SEQUENCED;

        Value = "";
        _silkTagArgs = args;
        for(int i = 1; i < args.Count; i++) {
			//Debug.Log ("BOOP" + args [i]);
            actArgs.Add(args[i]);
        }
		//Debug.Log ("BOOP>>" + args[0]);

        controller = GameObject.FindObjectOfType<ActionController>();
    }

    public override void ExecuteTagLogic(List<string> args) {
		//Debug.Log (args [0] + "<<");
		//Debug.Log("BOOP>>" +args[0]);
        string actName = args[0];

        switch (actName) {
		case "RUN":
			//Debug.Log ("sup?");
				
			RunAction newRunAction = new RunAction (actName, actArgs);
			controller.activeActions.Add (newRunAction);
			if (!controller.discoveredActions.ContainsKey (actName)) {
				controller.discoveredActions.Add (actName, newRunAction);
			}
            break;
		case "TOUCH":
			TouchAction newTouchAction = new TouchAction (actName, actArgs);
			controller.activeActions.Add (newTouchAction);
			if (!controller.discoveredActions.ContainsKey (actName)) {
				controller.discoveredActions.Add (actName, newTouchAction);
			}
			break;
		case "THROW":
			ThrowAction newThrowAction = new ThrowAction (actName, actArgs);
			controller.activeActions.Add (newThrowAction);
			if (!controller.discoveredActions.ContainsKey (actName)) {
				controller.discoveredActions.Add (actName, newThrowAction);
			}
			break;
		case "PUNCH":
			PunchAction newPunchAction = new PunchAction (actName, actArgs);
			controller.activeActions.Add (newPunchAction);
			if (!controller.discoveredActions.ContainsKey (actName)) {
				controller.discoveredActions.Add (actName, newPunchAction);
			}
			break;
		case "KICK":
			KickAction newKickAction = new KickAction (actName, actArgs);
			controller.activeActions.Add (newKickAction);
			if (!controller.discoveredActions.ContainsKey (actName)) {
				controller.discoveredActions.Add (actName, newKickAction);
			}
			break;
		case "KNIFE":
			KnifeAction newKnifeAction = new KnifeAction (actName, actArgs);
			controller.activeActions.Add (newKnifeAction);
			if (!controller.discoveredActions.ContainsKey (actName)) {
				controller.discoveredActions.Add (actName, newKnifeAction);
			}
			break;
		case "SWORD":
			SwordAction newSwordAction = new SwordAction (actName, actArgs);
			controller.activeActions.Add (newSwordAction);
			if (!controller.discoveredActions.ContainsKey (actName)) {
				controller.discoveredActions.Add (actName, newSwordAction);
			}
			break;
		case "AX":
			AxAction newAxAction = new AxAction (actName, actArgs);
			controller.activeActions.Add (newAxAction);
			if (!controller.discoveredActions.ContainsKey (actName)) {
				controller.discoveredActions.Add (actName, newAxAction);
			}
			break;
		case "PISTOL":
			PistolAction newPistolAction = new PistolAction (actName, actArgs);
			controller.activeActions.Add (newPistolAction);
			if (!controller.discoveredActions.ContainsKey (actName)) {
				controller.discoveredActions.Add (actName, newPistolAction);
			}
			break;
		case "OPEN":
			OpenAction newOpenAction = new OpenAction (actName, actArgs);
			controller.activeActions.Add (newOpenAction);
			if (!controller.discoveredActions.ContainsKey (actName)) {
				controller.discoveredActions.Add (actName, newOpenAction);
			}
			break;
        }
        

        OnExecutionComplete();

    }

}
