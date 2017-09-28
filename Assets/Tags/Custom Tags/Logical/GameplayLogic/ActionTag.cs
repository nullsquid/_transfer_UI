﻿using System.Collections;
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
        case "RUN UP":
            RunUpAction newUpAction = new RunUpAction(actName, actArgs);
            controller.activeActions.Add(newUpAction);
            if (!controller.discoveredActions.ContainsKey(actName)) {
                controller.discoveredActions.Add(actName, newUpAction);
            }
            break;
		case "RUN LEFT":
			RunLeftAction newLeftAction = new RunLeftAction(actName, actArgs);
			controller.activeActions.Add(newLeftAction);
			if (!controller.discoveredActions.ContainsKey(actName)) {
				controller.discoveredActions.Add(actName, newLeftAction);
			}
			break;
		case "RUN RIGHT":
			RunRightAction newRightAction = new RunRightAction(actName, actArgs);
			controller.activeActions.Add(newRightAction);
			if (!controller.discoveredActions.ContainsKey(actName)) {
				controller.discoveredActions.Add(actName, newRightAction);
			}
			break;
            case "RUN DOWN":
                RunDownAction newDownAction = new RunDownAction(actName, actArgs);
                controller.activeActions.Add(newDownAction);
                if (!controller.discoveredActions.ContainsKey(actName)) {
                    controller.discoveredActions.Add(actName, newDownAction);
                }
            break;
            case "RUN STRAIGHT":
                RunStraightAction newStraightAction = new RunStraightAction(actName, actArgs);
                controller.activeActions.Add(newStraightAction);
                if (!controller.discoveredActions.ContainsKey(actName)) {
                    controller.discoveredActions.Add(actName, newStraightAction);
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
        case "DIG":
            DigAction newDigAction = new DigAction(actName, actArgs);
            controller.activeActions.Add(newDigAction);
            if (!controller.discoveredActions.ContainsKey(actName)) {
                controller.discoveredActions.Add(actName, newDigAction);
            }
            break;
        case "PENETRATE":
            PenetrateAction newPenAction = new PenetrateAction(actName, actArgs);
            controller.activeActions.Add(newPenAction);
            if (!controller.discoveredActions.ContainsKey(actName)) {
                controller.discoveredActions.Add(actName, newPenAction);
            }
            break;
		case "FIRE":
			FireAction newFireAction = new FireAction (actName, actArgs);
			controller.activeActions.Add (newFireAction);
			if (!controller.discoveredActions.ContainsKey (actName)) {
				controller.discoveredActions.Add (actName, newFireAction);
			}
			break;
		case "BEHEAD":
			BeheadAction newBeheadAction = new BeheadAction (actName, actArgs);
			controller.activeActions.Add (newBeheadAction);
			if (!controller.discoveredActions.ContainsKey (actName)) {
				controller.discoveredActions.Add (actName, newBeheadAction);
			}
			break;
		case "TURNOFF":
			OffAction newOffAction = new OffAction (actName, actArgs);
			controller.activeActions.Add (newOffAction);
			if (!controller.discoveredActions.ContainsKey (actName)) {
				controller.discoveredActions.Add (actName, newOffAction);
			}
			break;
        case "EXIT":
            ExitAction newExitAction = new ExitAction(actName, actArgs);
            controller.activeActions.Add(newExitAction);
            if (!controller.discoveredActions.ContainsKey(actName)) {
                controller.discoveredActions.Add(actName, newExitAction);
            }
            break;

        }
        

        OnExecutionComplete();

    }

}
