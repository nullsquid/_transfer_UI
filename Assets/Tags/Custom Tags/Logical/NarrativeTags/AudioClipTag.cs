using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;

public class AudioClipTag : SilkTagBase {
    DialogueAudioHandler audioHandler;
	public AudioClipTag(string name, List<string> args){
		TagName = name;
		type = TagType.SEQUENCED;
        audioHandler = GameObject.FindObjectOfType<DialogueAudioHandler>();
        if (args.Count == 1) {
			_silkTagArgs = args;
			Value = "";
		} else if (args.Count < 1) {
			Debug.LogError ("TAG REQUIRES AN AUDIO CLIP NAME TO BE PASSED");
		} else {
			Debug.LogError ("TOO MANY ARGUMENTS FOR AUDIOCLIP TAG");
		}
	}
    public override void ExecuteTagLogic(List<string> args) {
        audioHandler.InvokeAudioLog(args[0]);
        OnExecutionComplete();
    }
}
