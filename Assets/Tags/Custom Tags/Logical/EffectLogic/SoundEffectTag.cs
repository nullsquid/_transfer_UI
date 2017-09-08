using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class SoundEffectTag : SilkTagBase {
	public SoundEffectTag(string name, List<string> args){
		TagName = name;
		type = TagType.SEQUENCED;
		if (args.Count == 1) {
			_silkTagArgs = args;
			Value = "";
		} else if (args.Count == 2) {
			_silkTagArgs = args;
			Value = "";
		}else if (args.Count < 1) {
			Debug.LogError ("TAG REQUIRES A SOUND EFFECT NAME TO BE PASSED");
		} else {
			Debug.LogError ("TOO MANY ARGUMENTS FOR SFX TAG");
		}
	}

	public override void ExecuteTagLogic(List<string> args){
		if (args.Count == 1) {
			//AudioManager.Instance.
		} else if (args.Count == 2) {

		}
	}
	
}
