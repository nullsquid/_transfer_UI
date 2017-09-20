using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class AxAction : ActionBase {
	SilkNode destination;
	// Use this for initialization
	public AxAction(string name, List<string> args){
		ActionName = name;
		Args = args;

		destination = Silky.Instance.mother.GetNodeByName(DialogueManager.instance.CurStory.StoryName, args[0]);
	}

	public override void ExecuteActionLogic() {
		Debug.Log (destination.nodeName);
		DialogueManager.instance.FindNextNodeByName(destination.nodeName);
	}
}
