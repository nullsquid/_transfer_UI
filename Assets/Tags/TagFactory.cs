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
            case "wait":
                WaitTag newWaitTag = new WaitTag(tagName, args);
                return newWaitTag;
            case "nodewait":
                NodeWait newNodeWaitTag = new NodeWait(tagName, args);
                return newNodeWaitTag;
			//case "state":
			//	StateTag newState = new StateTag (tagName, args);
			//	return newState;
			//case "unload":
                //break;
				//UnloadTag newUnload = new UnloadTag (tagName);
				//return newUnload;
			case "sfx":
				SoundEffectTag newSFX = new SoundEffectTag (tagName, args);
				return newSFX;
			case "effect":
				EffectTag newEffect = new EffectTag (tagName, args);
				return newEffect;
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
            case "level":
                LevelTag newLevelTag = new LevelTag(tagName, args);
                return newLevelTag;
            case "action":
                ActionTag newActionTag = new ActionTag(tagName, args);
                return newActionTag;
            case "error":
                ErrorTag newErrorTag = new ErrorTag(tagName, args);
                return newErrorTag;
			case "memory":
				MemoryTag newMemoryTag = new MemoryTag (tagName, args);
				return newMemoryTag;
			case "end":
				EndingTag newEndingTag = new EndingTag (tagName, args);
				return newEndingTag;
			default:
				DummyTag newDummy = new DummyTag (tagName, args);
				return newDummy;

			}



        } 
    }
}

