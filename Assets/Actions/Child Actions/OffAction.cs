using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class OffAction : ActionBase {
	SilkNode destination;
	public OffAction(string name, List<string> args){
		ActionName = name;
		Args = args;

		destination = Silky.Instance.mother.GetNodeByName(DialogueManager.instance.CurStory.StoryName, args[0]);

	}
	public override void ExecuteActionLogic(){
		DialogueManager.instance.FindNextNodeByName(destination.nodeName);

	}

}
