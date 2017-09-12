using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class VideoClipTag : SilkTagBase {

    VideoManager videoManager;
	public VideoClipTag(string name, List<string> args){
        videoManager = GameObject.FindObjectOfType<VideoManager>();
		TagName = name;
		type = TagType.SEQUENCED;
		if (args.Count == 1) {
			Value = "";
			_silkTagArgs = args;
            
		} else if (args.Count < 0) {
			Debug.LogError ("PASS A VIDEOCLIP NAME TO TAG PLEASE");
		} else {
			Debug.LogError ("TOO MANY VIDEO CLIP NAMES");
		}
	}

    public override void ExecuteTagLogic(List<string> args) {
        videoManager.PlayVideo(args[0]);
        OnExecutionComplete();
    }

}
