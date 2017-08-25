using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;

public class AudioClipTag : SilkTagBase {
	public AudioClipTag(string name, List<string> args){
		TagName = name;
		type = TagType.SEQUENCED;
		if (args.Count == 1) {
			_silkTagArgs = args;
			Value = "";
		} else if (args.Count < 1) {
			Debug.LogError ("TAG REQUIRES AN AUDIO CLIP NAME TO BE PASSED");
		} else {
			Debug.LogError ("TOO MANY ARGUMENTS FOR AUDIOCLIP TAG");
		}
	}
}
