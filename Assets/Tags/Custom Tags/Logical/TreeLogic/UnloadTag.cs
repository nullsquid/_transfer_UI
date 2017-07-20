using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class UnloadTag : SilkTagBase {
	public UnloadTag(string name){
        TagName = name;
        type = TagType.SEQUENCED;
	}

	public override void ExecuteTagLogic(List<string> args){
		DialogueManager.instance.CurStory = null;
		OnExecutionComplete ();
	}
	
}
