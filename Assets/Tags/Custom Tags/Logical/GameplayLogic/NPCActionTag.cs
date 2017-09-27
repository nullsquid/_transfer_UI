using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class NPCActionTag : SilkTagBase {

	NPCActionController controller;
	List<string> actArgs = new List<string>();
	public NPCActionTag(string name, List<string> args){
		TagName = name;
		type = TagType.SEQUENCED;
		Value = "";
		_silkTagArgs = args;

		controller = GameObject.FindObjectOfType<NPCActionController> ();
	}

	public override void ExecuteTagLogic(List<string> args){
		string actName = args [0];
		//SilkNode destination = args [1];
		float timeToWait = float.Parse (args [2]);

	}
}
