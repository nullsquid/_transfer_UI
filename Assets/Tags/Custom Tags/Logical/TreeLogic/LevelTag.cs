using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class LevelTag : SilkTagBase {

    public LevelTag(string name, List<string> args) {
        TagName = name;
        type = TagType.SEQUENCED;

        if (args.Count == 1) {
            //Value = ;
            _silkTagArgs = args;

            Value = "";
            //SetNextTree(args[0]
        }
        else {
            Value = "TOO MANY ARGS FOR TREE TAG";
        }
    }
    public override void ExecuteTagLogic(List<string> args) {
        DialogueManager.instance.level = args[0];
    }
}
