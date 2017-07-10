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
			//SetNextTree(args[0]
		} else {
			Value = "TOO MANY ARGS FOR TREE TAG";
		}
	}

}
