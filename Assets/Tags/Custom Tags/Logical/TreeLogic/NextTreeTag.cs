using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class NextTreeTag : SilkTagBase {
    Terminal terminal;
	public NextTreeTag(string name,List<string> args){
        TagName = name;
        type = TagType.SEQUENCED;
        terminal = GameObject.FindObjectOfType<Terminal>();

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
        //Debug.Log("NEWTREE " + args[0]);

        terminal.ChangeState(new IdleState());
        if(DialogueManager.instance.level != "1") {
            MemoryManager.instance.UnlockMemory(DialogueManager.instance.level);
        }
        GameObject.FindObjectOfType<IdleTextPrinter>().InvokeIdlePrint("\n>>\n>>NEW MEMORY UNLOCKED");
        DialogueManager.instance.GetNextStory (args [0]);
        

        OnExecutionComplete();
        //DialogueManager.instance.CurStory = Silky.Instance.mother.GetStoryByName(args[0]);
		//DialogueManager.instance.GetRootNode ();
		//DialogueManager.instance.newNodeStart ();
    }

}
