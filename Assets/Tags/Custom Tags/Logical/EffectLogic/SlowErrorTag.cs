using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class SlowErrorTag : SilkTagBase {
	string printtext;
	public SlowErrorTag(string name, List<string> args){
		TagName = name;
		type = TagType.SEQUENCED;
		if (args.Count == 3) {
			Value = "";
			_silkTagArgs = args;

		} else {
			Debug.LogError ("WRONG NUMBER OF ERRORS");

		}
	}

	public override void ExecuteTagLogic(List<string> args){
		printtext = args [0];
		GameObject.FindObjectOfType<TextPrinter> ().InvokeErrorText (printtext);
		EffectsManager.instance.ErrorEffect ();
		DialogueManager.instance.WaitForNextNode (float.Parse (args [1]), args [2]);

	}
}
