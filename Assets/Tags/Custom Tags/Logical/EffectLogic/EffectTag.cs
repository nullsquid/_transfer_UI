using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class EffectTag : SilkTagBase {

	public EffectTag(string name, List<string> args){
		TagName = name;
		type = TagType.SEQUENCED;
		if (args.Count == 1) {
			_silkTagArgs = args;
			Value = "";
		}
	}

	public override void ExecuteTagLogic(List<string> args){
		switch(args[0]){
			
			case "SURGE":
				EffectsManager.instance.SurgeEffect ();
				break;
			case "SHIFT":
				EffectsManager.instance.ShiftEffect ();
				break;
		}
	}

}
