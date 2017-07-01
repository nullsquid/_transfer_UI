using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
using Transfer.System;
public class PronounTag : SilkTagBase {

	public PronounTag(List<string> args){
		//arg 0 is name
		//arg 1 is tense

		Value = CharacterManager.instance.GetCharacterPronounByID (args [0], args [1]);

	}
}
