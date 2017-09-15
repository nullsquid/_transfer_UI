using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
using Transfer.Data;
public class EndingTag : SilkTagBase {

	public EndingTag(string name, List<string> args){
        name = TagName;
        type = TagType.SEQUENCED;
        if(args.Count == 1) {
            Value = "";
            _silkTagArgs = args;
        }
	}

    public override void ExecuteTagLogic(List<string> args) {
        PlayerPrefs.SetString(CharacterDatabase.GetPlayerID(),"true");
    }
}
