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
			case "unload":
				UnloadTag newUnload = new UnloadTag (tagName);
				return newUnload;
			default:
				DummyTag newDummy = new DummyTag (tagName, args);
				return newDummy;

			}



        } 
    }
}

