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
            actArgs.Add(args[i]);
        }
        controller = GameObject.FindObjectOfType<ActionController>();
    }

    public override void ExecuteTagLogic(List<string> args) {
        string actName = args[0];
        switch (actName) {
            case "run":
                RunAction newRunAction = new RunAction("run", actArgs);
                controller.activeActions.Add(actName, newRunAction);
                controller.discoveredActions.Add(actName, newRunAction);
                break;
                
        }
        

        OnExecutionComplete();

    }

}
