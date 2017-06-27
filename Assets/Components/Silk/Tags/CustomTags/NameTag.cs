using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
using Transfer.Data;
public class NameTag : SilkTagBase {

    public NameTag(string tagName, string[] args) {
        DefineArguments(args);
        _tagName = tagName;

    }

    public override void SilkTagDefinition() {

        //ReplaceTagWithName(_tagName, _silkTagArgs);

    }

    public string ReplaceTagWithName(string name, List<string> args) {
        string rawTag = "";
        string outputText;
        if(args.Count == 1) {
            rawTag = "<<" + name + "=" + args[0] + ">>";
            outputText = CharacterDatabase.GetCharacterName(args[0]);
            return outputText;
        }
        else {
            Debug.LogError("you passed too many arguments to the tag");
        }
        return null;
    }

	public string ReplaceTag(string tagToReplace){
		return null;
	}
    
}
