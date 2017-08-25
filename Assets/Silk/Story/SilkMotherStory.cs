﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Silk
{
    public class SilkMotherStory
    {

        #region Data
        private Dictionary<string, SilkStory> motherStory = new Dictionary<string, SilkStory>();

        public Dictionary<string, SilkStory> MotherStory
        {
            get
            {
                return motherStory;
            }
        }
        #endregion

        #region Data Manipulation Methods
        public void AddToMother(string storyName, SilkStory story)
        {
            motherStory.Add(storyName, story);
        }
        #endregion

        #region Accessor Methods
        public SilkNode GetNodeByName(string storyName, string nodeName) {
            foreach(KeyValuePair<string, SilkStory> story in MotherStory) {
                if (story.Key == storyName) {
                    foreach (KeyValuePair<string, SilkNode> node in story.Value.Story) {
                        if (node.Value.GetNodeName() == nodeName) {
                            Debug.Log("Node " + nodeName + " in " + storyName + " returned");
                            return node.Value;
                        }
                        else{
                            //should rather be if nodeName does not exist inside current document, then error
                        }
                    }
                }
                else {
                    Debug.LogError("Story " + storyName + " not found. Try another?");
                }
            }
            return null;
        }

		public SilkStory GetStoryByName(string storyName){
			//NOTE There's something weird going on with what ~counts~ as a storyName
			//if(motherStory.ContainsKey(storyName)){
				foreach (KeyValuePair<string, SilkStory> story in motherStory) {
					//Debug.Log (story.Key);
					if (story.Key == storyName) {
						Debug.Log ("Story " + storyName + " returned");
						return story.Value;
					} 
				}
			if(!motherStory.ContainsKey(storyName)){
				Debug.LogError (storyName + " not found");
			}
			//}
			//else {
			//	Debug.LogError("No story named " + storyName + " found");
			//}
				
			return null;
		}
        #endregion
    }
}
