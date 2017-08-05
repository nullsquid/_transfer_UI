using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;

public class NoPrompTag : SilkTagBase {

	public NoPrompTag(string name, List<string> args){
		TagName = name;
		type = TagType.INLINE;
		Value = "";
	}
}
