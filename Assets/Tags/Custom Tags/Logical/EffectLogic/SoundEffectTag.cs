using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class SoundEffectTag : SilkTagBase {
	DialogueAudioHandler audioHandler;
	public SoundEffectTag(string name, List<string> args){
		TagName = name;
		type = TagType.SEQUENCED;
		audioHandler = GameObject.FindObjectOfType<DialogueAudioHandler> ();
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
			audioHandler.InvokeSoundEffect (args [0]);
			//AudioManager.Instance.
		} else if (args.Count == 2) {

		}
	}
	
}
