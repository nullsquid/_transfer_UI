using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class NodeWait : SilkTagBase {

    public NodeWait(string name, List<string> args) {
        TagName = name;
        type = TagType.SEQUENCED;
        if (args.Count == 2) {
            Value = "";
            _silkTagArgs = args;
        }
    }

    public override void ExecuteTagLogic(List<string> args) {
        DialogueManager.instance.WaitForNextNode(args[0], float.Parse(args[1]));
        OnExecutionComplete();
    }

}
