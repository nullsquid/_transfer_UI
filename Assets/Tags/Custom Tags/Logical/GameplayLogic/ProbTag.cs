using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class ProbTag : SilkTagBase {
    public ProbTag(string name, List<string> args) {
        TagName = name;
        type = TagType.SEQUENCED;
        if(args.Count == 4) {
            Value = "";
            _silkTagArgs = args;
        }
    }
    //arguments are follows::
    //::::::::::::
    //wait time
    //number to beat
    //if lower
    //if higher
    public override void ExecuteTagLogic(List<string> args) {
        float timeToWait = float.Parse(args[0]);
        float numberToBeat = float.Parse(args[1]);
        float randNum = Random.Range(0, 100);
        string failNode = args[2];
        string successNode = args[3];
        if(randNum < numberToBeat) {
            DialogueManager.instance.WaitForNextNode(timeToWait, failNode);
        }
        else {
            DialogueManager.instance.WaitForNextNode(timeToWait, successNode);
        }
        OnExecutionComplete();
    }
}
