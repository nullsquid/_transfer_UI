﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class StateTag : SilkTagBase {
	public StateTag(string name,List<string> args){
        TagName = name;
        type = TagType.SEQUENCED;
		string state = args [0];
	}

}
