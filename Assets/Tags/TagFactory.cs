using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Silk{
    public class TagFactory
    {

        string SetRawTag(string tagName, string[] args) {
            string rawTag = "<<" + tagName + '=';
            for (int i = 0; i < args.Length; i++) {
                rawTag += "\"" + args[i] + "\"";
            }
            rawTag += ">>";
            return rawTag;
        }
        public SilkTagBase SetTag(string tagName, List<string> args)
        {

			switch (tagName) {
			case "name":
				NameTag newName = new NameTag (tagName, args);
				return newName;
            case "prompt":
                PromptTag newPrompt = new PromptTag(tagName);
                return newPrompt;
			case "speaker":
				SpeakerTag newSpeaker = new SpeakerTag (tagName, args);
				return newSpeaker;
			case "pronoun":
				PronounTag newPronoun = new PronounTag (tagName, args);
				return newPronoun;
			case "nexttree":
				NextTreeTag newTreeTag = new NextTreeTag (tagName, args);
				return newTreeTag;
			case "state":
				StateTag newState = new StateTag (tagName, args);
				return newState;
			//case "unload":
                //break;
				//UnloadTag newUnload = new UnloadTag (tagName);
				//return newUnload;
			case "sfx":
				SoundEffectTag newSFX = new SoundEffectTag (tagName, args);
				return newSFX;
			case "audioclip":
				AudioClipTag newAudioClip = new AudioClipTag (tagName, args);
				return newAudioClip;
			case "noprompt":
				NoPrompTag newNoPrompt = new NoPrompTag (tagName, args);
				return newNoPrompt;
			case "videoclip":
				VideoClipTag newVideoClip = new VideoClipTag (tagName, args);
				return newVideoClip;
            case "connect":
                ConnectTag newConnectTag = new ConnectTag(tagName, args);
                return newConnectTag;
            case "action":
                ActionTag newActionTag = new ActionTag(tagName, args);
                return newActionTag;
			default:
				DummyTag newDummy = new DummyTag (tagName, args);
				return newDummy;

			}



        } 
    }
}

