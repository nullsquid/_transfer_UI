using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class RandEndTreeTag : SilkTagBase {

    List<string> endTrees;
    public RandEndTreeTag(string name, List<string> args) {
        TagName = name;
        type = TagType.SEQUENCED;
        endTrees = new List<string>();
        foreach(KeyValuePair<string,SilkStory> story in Silky.Instance.mother.MotherStory) {
            if(story.Key == "1M" || story.Key == "1N" || story.Key == "1O" || story.Key == "1P" || story.Key == "1Q" || story.Key == "1R") {
                endTrees.Add(story.Key);
            }
        }
    }

    public override void ExecuteTagLogic(List<string> args) {
        DialogueManager.instance.GetNextStory(endTrees[Random.Range(0, endTrees.Count)]);
        OnExecutionComplete();
    }
}
