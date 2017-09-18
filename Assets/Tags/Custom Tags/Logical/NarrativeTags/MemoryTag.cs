using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class MemoryTag : SilkTagBase {

	public MemoryTag(string name, List<string> args){
		TagName = name;
		type = TagType.SEQUENCED;
		if (args.Count == 0) {
			Value = "";
			_silkTagArgs = args;
		}
	}

	public override void ExecuteTagLogic(List<string> args){
		MemoryManager.instance.UnlockMemory (DialogueManager.instance.level);
		//GameObject.FindObjectOfType<IdleTextPrinter> ().InvokeIdlePrint ("\n>>\n>>NEW MEMORY UNLOCKED");
		OnExecutionComplete ();
	}
}
