using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class ConnectTag :  SilkTagBase{

	public ConnectTag(string name, List<string> args) {
        TagName = name;
        type = TagType.INLINE;
        if (args.Count == 1) {
            Value = "";
            _silkTagArgs = args;
            //SetNextTree(args[0]
        }
        else {
            Value = "TOO MANY ARGS FOR TREE TAG";
        }
    }
}
