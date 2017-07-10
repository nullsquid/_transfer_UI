using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
using Transfer.System;
public class SpeakerTag : SilkTagBase {

	public SpeakerTag(List<string> args){
        type = TagType.INLINE;
		if (args.Count == 1) {

			Value = CharacterManager.instance.GetCharacterNameByID(args[0]) + ": ";
		} else {
			Value = "YA DOOFED UP";
		}
	}
}
