﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class WaitTag : SilkTagBase {
    Terminal terminal;
    public WaitTag(string name, List<string> args) {
        TagName = name;
        type = TagType.SEQUENCED;
        terminal = GameObject.FindObjectOfType<Terminal>();
        if(args.Count == 2) {
            Value = "";
            _silkTagArgs = args;
        }
    }

    public override void ExecuteTagLogic(List<string> args) {
		if (DialogueManager.instance.level != "1") {
			MemoryManager.instance.UnlockMemory (DialogueManager.instance.level);
		}
        DialogueManager.instance.WaitForNextStory(args[0], float.Parse(args[1]));

        OnExecutionComplete();
    }

    public override void OnExecutionComplete() {
        base.OnExecutionComplete();

        TextPrinter.onPrintComplete -= this.TagExecute;
    }



}
