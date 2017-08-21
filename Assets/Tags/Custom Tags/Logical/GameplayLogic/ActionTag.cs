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
                Debug.Log("sup?");
				
				RunAction newRunAction = new RunAction(actName, actArgs);
                controller.activeActions.Add(newRunAction);
                controller.discoveredActions.Add(actName, newRunAction);
                break;
        }
        

        OnExecutionComplete();

    }

}
