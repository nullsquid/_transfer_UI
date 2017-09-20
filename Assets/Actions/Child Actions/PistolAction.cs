﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class PistolAction : ActionBase {
	SilkNode destination;
	public PistolAction(string name, List<string> args){
		ActionName = name;
		Args = args;

		destination = Silky.Instance.mother.GetNodeByName(DialogueManager.instance.CurStory.StoryName, args[0]);
	}

	public override void ExecuteActionLogic() {
		Debug.Log (destination.nodeName);
		DialogueManager.instance.FindNextNodeByName(destination.nodeName);
	}
}
