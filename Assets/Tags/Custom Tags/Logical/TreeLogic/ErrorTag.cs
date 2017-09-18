using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class ErrorTag : SilkTagBase {
    string errorMessage = ">>\n>>\nCONNECTION INTERRUPTED \n>>\n>>\nRESTART CONNECTION";

    public ErrorTag(string name, List<string> args) {
        TagName = name;
        type = TagType.SEQUENCED;
        if (args.Count == 1) {
            Value = "";
            _silkTagArgs = args;
        }
        else {
            Debug.LogError("WRONG NUMBER OF ARGS, ERROR MESSAGE");
        }
    }

    public override void ExecuteTagLogic(List<string> args) {

        string curStoryLevel = DialogueManager.instance.CurStory.StoryName[0].ToString();
        string nextTreeName = "";
        string[] nextTreePossibilities;
        int index;
        switch (curStoryLevel) {
            case "7":
                nextTreePossibilities = new string[]{ "6H", "6I", "6J", "6K", "6L", "6M"};
                index = Random.Range(0, nextTreePossibilities.Length);
                nextTreeName = nextTreePossibilities[index];
                break;
            case "6":
                nextTreePossibilities = new string[] { "5I", "5J", "5K", "5L", "5M", "5N" };
                index = Random.Range(0, nextTreePossibilities.Length);
                nextTreeName = nextTreePossibilities[index];
                break;
            case "5":
                nextTreePossibilities = new string[] { "4J", "4K", "4L", "4N", "4M", "4O" };
                index = Random.Range(0, nextTreePossibilities.Length);
                nextTreeName = nextTreePossibilities[index];
                break;
            case "4":
                nextTreePossibilities = new string[] { "3K", "3L", "3M", "3N", "3O", "3P" };
                index = Random.Range(0, nextTreePossibilities.Length);
                nextTreeName = nextTreePossibilities[index];
                break;
            case "3":
                nextTreePossibilities = new string[] { "2L", "2M", "2N", "2O", "2P", "2Q" };
                index = Random.Range(0, nextTreePossibilities.Length);
                nextTreeName = nextTreePossibilities[index];
                break;
            case "2":
                nextTreePossibilities = new string[] { "1M", "1N", "1O", "1P", "1Q", "1R" };
                index = Random.Range(0, nextTreePossibilities.Length);
                nextTreeName = nextTreePossibilities[index];
                break;
        }

        GameObject.FindObjectOfType<TextPrinter>().InvokeErrorText(errorMessage);
        //placeholder
        EffectsManager.instance.ErrorEffect();
        DialogueManager.instance.WaitForNextStory(nextTreeName, float.Parse(args[0]));
    }


}
