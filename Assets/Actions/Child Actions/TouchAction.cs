using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class TouchAction : ActionBase {
	SilkNode destination;
	public TouchAction(string name, List<string> args){
		ActionName = name;
		Args = args;

		destination = Silky.Instance.mother.GetNodeByName(DialogueManager.instance.CurStory.StoryName, args[0]);
	}

	public override void ExecuteActionLogic() {
		Debug.Log (destination.nodeName);
		//when fired on 4F Start node, hits node '1' and then falls to node '2' where it stops
		DialogueManager.instance.FindNextNodeByName(destination.nodeName);
	}

}
