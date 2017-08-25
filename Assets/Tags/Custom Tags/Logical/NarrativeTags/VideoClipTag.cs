using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class VideoClipTag : SilkTagBase {

	public VideoClipTag(string name, List<string> args){
		TagName = name;
		type = TagType.SEQUENCED;
		if (args.Count == 0) {
			Value = "";
			_silkTagArgs = args;
		} else if (args.Count < 0) {
			Debug.LogError ("PASS A VIDEOCLIP NAME TO TAG PLEASE");
		} else {
			Debug.LogError ("TOO MANY VIDEO CLIP NAMES");
		}
	}

}
