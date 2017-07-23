using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class NextTreeTag : SilkTagBase {
	public NextTreeTag(string name,List<string> args){
        TagName = name;
        type = TagType.SEQUENCED;
		if (args.Count == 1) {
			Value = "";
            _silkTagArgs = args;
			//SetNextTree(args[0]
		} else {
			Value = "TOO MANY ARGS FOR TREE TAG";
		}
        
	}
    public override void ExecuteTagLogic(List<string> args) {
        //DialogueManager.instance.CurStory =
        Debug.Log("NEWTREE " + args[0]);
		DialogueManager.instance.GetNextStory (args [0]);
        //DialogueManager.instance.CurStory = Silky.Instance.mother.GetStoryByName(args[0]);
		//DialogueManager.instance.GetRootNode ();
		//DialogueManager.instance.newNodeStart ();
    }

}
