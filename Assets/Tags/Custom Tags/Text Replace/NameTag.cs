using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
using Transfer.System;
public class NameTag : SilkTagBase {
    
	public NameTag(string name, List<string> args){
        type = TagType.INLINE;
        TagName = name;
		//dummy, this will actually
		if (args.Count == 1) {
			//Will really be something like Value = CharacterManager.GetCharacterName(args[0]);
			Value = CharacterManager.instance.GetCharacterNameByID(args[0]);

		} else {
			Value = "NOPE";
		}
	}

}
