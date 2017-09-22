using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class StateTag : SilkTagBase {
    Terminal terminal;
	public StateTag(string name,List<string> args){
        TagName = name;
        _silkTagArgs = args;
        type = TagType.SEQUENCED;
		string state = args [0];
        terminal = GameObject.FindObjectOfType<Terminal>();
	}

    public override void ExecuteTagLogic(List<string> args) {
        Debug.Log("State change");
        switch (args[0]) {
            case "idle":
                //terminal.ChangeState(new IdleState());
                break;
        }
        //GameObject.FindObjectOfType<Terminal>().ChangeState()
        OnExecutionComplete();
    }

}
