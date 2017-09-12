using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace Silk
{
    public class SilkNode
    {

        #region Data
        private string storyName;

        public string nodeName;
        public string nodePassage;
        public string nodeSpeaker = null;

        public List<SilkTagBase> executionQueue = new List<SilkTagBase>();
		public List<SilkTagBase> connectQueue = new List<SilkTagBase>();
        //public Dictionary<string, string> links = new Dictionary<string, string>();
        public List<TextLink> textLinks = new List<TextLink>();
        public Dictionary<string, string[]> tags = new Dictionary<string, string[]>();
        public List<SilkLink> silkLinks = new List<SilkLink>();
        public List<SilkTagBase> silkTags = new List<SilkTagBase>();
        #endregion

        #region Accessor Methods
        public string StoryName
        {
            set
            {
                storyName = value;
            }
        }

        public string GetNodeName()
        {
            StringBuilder strippedName = new StringBuilder();
            strippedName.Append(nodeName);

            strippedName.Replace(storyName + "_", "");
            
            return strippedName.ToString().TrimEnd().TrimStart();
        }

        /*public void AddLinkName(string linkText, string linkPointer)
        {
            links.Add(linkText, linkPointer);
        }*/

        public string GetLinkNameValue(string linkText)
        {
            foreach(TextLink linkName in textLinks)
            {
                if(linkName.LinkText == linkText)
                {
                    return linkName.LinkedNodeName;
                }
                
            }
            return null;
        }

        public SilkLink[] GetLinks()
        {
            return silkLinks.ToArray();
        }

        /*public Dictionary<string, string> Links
        {
            get
            {
                return links;
            }
        }*/
        public string GetStoryName() {
            return storyName;
        }
        public IEnumerator WaitAndLogQueue() {
            yield return new WaitForEndOfFrame();
            LogQueue();
        }
        public void LogQueue() {
            foreach(SilkTagBase value in executionQueue) {
				Debug.Log("ENQUEUED TAG >>" + value.TagName);
            }
        }

        #endregion

        #region Data Manipulation Methods

        #endregion





    }
}
