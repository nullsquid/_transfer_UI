using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class RunAction : ActionBase {
    DialogueManager dm;
    SilkNode destination;
    public enum Direction {
        NONE,
        NORTH,
        SOUTH,
        EAST,
        WEST
    }

    public RunAction(string name, List<string> args) {
		//Debug.Log ("HMMMMMMMMMMMMM???");
		ActionName = name;
        Args = args;
        dm = GameObject.FindObjectOfType<DialogueManager>();
        Direction dir;

		//Args[0] is throwing an error?
		//Debug.Log ("ACT ARG >>" + args [0]);
		Debug.Log (args);
		/*
        switch (args[0]) {
            case "north":
                dir = Direction.NORTH;
                break;
            case "south":
                dir = Direction.SOUTH;
                break;
            case "east":
                dir = Direction.EAST;
                break;
            case "west":
                dir = Direction.WEST;
                break;
            default:
                dir = Direction.NONE;
                break;

        }

        if(dir != Direction.NONE) {
            destination = Silky.Instance.mother.GetNodeByName(dm.CurStory.StoryName,args[1]);
        }
        else {
            destination = Silky.Instance.mother.GetNodeByName(dm.CurStory.StoryName, args[0]);
        }
		*/

        
    }

    public override void ExecuteActionLogic() {
        dm.FindNextNode(destination.nodeName);
    }
}
