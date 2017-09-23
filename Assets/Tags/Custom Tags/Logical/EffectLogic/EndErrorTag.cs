using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class EndErrorTag : SilkTagBase {
	string errorMessage = ">>\n>>\nARGUMENT OUT OF RANGE EXCEPTION";
	public EndErrorTag(string name, List<string> args){
		TagName = name;
		type = TagType.SEQUENCED;
		if (args.Count == 2) {
			Value = "";
			_silkTagArgs = args;
		} else {
			Debug.LogError ("WRONG NUMBER OF ARGUMENTS");
		}


	}

	public override void ExecuteTagLogic(List<string> args){
		GameObject.FindObjectOfType<TextPrinter> ().InvokeErrorText (errorMessage);

		EffectsManager.instance.ErrorEffect ();
		DialogueManager.instance.WaitForNextNode (float.Parse (args [0]), args [1]);
	}
}
