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
		} else if (args.Count == 2 || args.Count == 3) {
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
            int percent = int.Parse(args[1]);
            int randChance = Random.Range(0, 100);
            if(randChance <= percent) {
                //do the thing
                audioHandler.InvokeSoundEffect(args[0]);
            }
            else if(randChance > percent) {
                //don't do the thing
            }
		}
        else if(args.Count == 3) {
            int percent = int.Parse(args[1]);
            int randChance = Random.Range(0, 100);
            if (randChance <= percent) {
                //do the thing
                audioHandler.InvokeSoundEffect(args[0],float.Parse(args[2]));
            }
        }
	}
	
}
