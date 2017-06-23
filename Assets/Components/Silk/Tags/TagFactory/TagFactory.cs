using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Silk{
    public class TagFactory
    {
        public SilkTagBase SetTag(string tagName, string[] args)
        {
            if(tagName == "DummyTag")
            {
                if (tagName.Contains("_"))
                {
                    Debug.LogWarning("Tag cannot contain underscores");
                }

                DummyTag newDummyTag = new DummyTag(tagName, args);
                return newDummyTag;

            }
			else if (tagName == "name") {
				if (tagName.Contains ("_")) {
					Debug.LogWarning ("Tag cannot contain underscores");
				}
				NameTag newNameTag = new NameTag (tagName, args);
				return newNameTag;
			}

            //else if(tagName == "..."){
            //
            //note::tag names at present cannot include underscores
            //
            //
            //}

            else
            {
                return null;
            }
        } 
    }
}

