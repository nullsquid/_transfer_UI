using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class RunAction : ActionBase {
    //DialogueManager dm;
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
        //dm = GameObject.FindObjectOfType<DialogueManager>();
        Direction dir;

		//Debug.Log ("ACT ARG >>" + args [0]);
		//Debug.Log ("ARGH " + args[0]);

		destination = Silky.Instance.mother.GetNodeByName(DialogueManager.instance.CurStory.StoryName, args[0]);

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
		Debug.Log (destination.nodeName);
		//when fired on 4F Start node, hits node '1' and then falls to node '2' where it stops
		DialogueManager.instance.FindNextNodeByName(destination.nodeName);
    }
}
