﻿using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Silk;
namespace Silk {
    public class Silky : MonoBehaviour {

        #region Public Variables
        public SilkMotherStory mother;
        #endregion

        #region Private Variables
        TagFactory tagFactory;
        Importer importer;
        string textToParse;
        string[] tweeNodesToInterpret;
        string[] delim = new string[] { ":: " };
        #endregion

        #region Testing Methods

        void LogNodeQueue() {
            foreach (KeyValuePair<string, SilkStory> story in mother.MotherStory) {
                foreach (KeyValuePair<string, SilkNode> node in story.Value.Story) {
                    foreach(SilkTagBase tag in node.Value.executionQueue) {
                        Debug.Log("TAG >>" + node.Value.nodeName + " " +  tag.TagName);
                    }
                }
            }
        }
        void LogNodes() {
            foreach (KeyValuePair<string, SilkStory> story in mother.MotherStory) {
                foreach (KeyValuePair<string, SilkNode> node in story.Value.Story) {
                    Debug.Log("NODE >>" + node.Value.GetNodeName());
                }
            }
        }

		void LogNodePrompt(){
			foreach (KeyValuePair<string, SilkStory> story in mother.MotherStory) {
				foreach (KeyValuePair<string, SilkNode> node in story.Value.Story) {
					Debug.Log ("PROMPT FOR " + story.Value.StoryName + ">>" + node.Value.nodePassage);
				}
			}
		}

		void LogNodeLinks(){
			foreach(KeyValuePair<string, SilkStory> story in mother.MotherStory){
				foreach(KeyValuePair<string, SilkNode> node in story.Value.Story){
					foreach (SilkLink link in node.Value.silkLinks) {
						Debug.Log ("LINK >>" + link.LinkText);
					}
				}
			}
		}
        #endregion

        #region Singleton
        public static Silky Instance { get; private set; }
        void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(gameObject);
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        #endregion

        //TODO sort out all of this nonsense, break into other methods, etc
        //TODO add each element of the node to a queue that will be parsed when it's the current node

        #region Initialization
        void ImportText() {
            //All of the "Getting Text Files to parse" code
        }
        void InitializeTagFactory() {

        }
		//TODO extract new methods from all of this
        void InitializeSilk() {
            tagFactory = new TagFactory();
            importer = GetComponent<Silk.Importer>();
            List<string> filenames = new List<string>();
            mother = new SilkMotherStory();
            
            foreach (TextAsset currentTweeFile in importer.rawTweeFiles) {
                SilkStory newSilkStory = new SilkStory();
                TextAsset tweeFile = currentTweeFile;
                string fileName = currentTweeFile.name;
                //Debug.LogWarning(currentTweeFile.name);
                //this works for single file
                //textToParse = testText.text;

                textToParse = tweeFile.text;
                tweeNodesToInterpret = textToParse.Split(delim, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tweeNodesToInterpret.Length; i++) {
                    string storyTitle = "";

					//this is where prompt parsing was supposed to go 
                    //TODO move to it's own method--everything that deals in extracting the prompt
                    
                    SilkNode newNode = new SilkNode();
					AssignDataToNodes(newSilkStory, newNode, tweeNodesToInterpret[i], GetPrompt(i, newSilkStory, newNode), fileName);
                }
				//newSilkStory.StoryName
				mother.AddToMother(fileName, newSilkStory);

            }
            //TODO Break This Out into its own method
            foreach (KeyValuePair<string, SilkStory> silkStory in mother.MotherStory) {
                filenames.Add(silkStory.Key);
            }
            //


            //TODO Make this its own method
            foreach (KeyValuePair<string, SilkStory> story in mother.MotherStory) {
                foreach (KeyValuePair<string, SilkNode> node in story.Value.Story) {
                    SilkNode cachedNode = node.Value;
                    foreach (TextLink link in node.Value.textLinks) {
                        string cachedLinkName = link.LinkedNodeName;

						//somewhere in here, fix linkname parsing to allow for structure that's like [[hello|hello]]
                        StringBuilder linkNameBuilder = new StringBuilder(cachedLinkName);
                        string linkName;
                        //it's right here
                        linkName = linkNameBuilder.ToString().TrimStart().TrimEnd();
                        //Debug.Log(linkName);
                        //After here, BLOOP doesn't show up

                        foreach (KeyValuePair<string, SilkNode> linkedNode in story.Value.Story) {
                            SilkNode cachedLinkedNode = linkedNode.Value;
                            string nodeName = "";
                            StringBuilder nodeNameBuilder = new StringBuilder();
                            //Debug.Log(linkName);
                            for (int a = 0; a < filenames.Count; a++) {
                                if (linkedNode.Value.nodeName.Contains(filenames[a] + "_")) {

                                    nodeNameBuilder.Append(linkedNode.Value.nodeName.Remove(0, filenames[a].Length + 1));
                                    nodeName = nodeNameBuilder.ToString().TrimEnd();

                                }
                            }
							if (linkName.ToString () == nodeName) {
                                //Debug.Log("BOOP! " + link.LinkText);
                                string strippedLink = "";
                                if (link.LinkText.Contains(link.LinkedNodeName)) {
                                    strippedLink = link.LinkText.Replace("|" + link.LinkedNodeName, string.Empty);
                                }
								SilkLink newSilkLink = new SilkLink (cachedNode, cachedLinkedNode, strippedLink);
								node.Value.silkLinks.Add (newSilkLink);

							}

                        }


                    }

                }
            }
            
        }

        private void Start() {
            InitializeSilk();
            GameObject.FindObjectOfType<DialogueManager>().InitializationCallback();
            foreach(KeyValuePair<string, SilkStory> story in mother.MotherStory) {
                foreach(KeyValuePair<string, SilkNode> node in story.Value.Story) {
                    foreach(TextLink textLink in node.Value.textLinks) {
                        if(textLink.LinkedNodeName == null) {
                            Debug.Log(story.Value.StoryName);
                        }
                    }
                }
            }
            
        }

        #endregion

		#region Get Prompts

        void ParseSectionOfNode(int c) {
            StringBuilder curText = new StringBuilder(tweeNodesToInterpret[c]);
            if(curText[0] == '\n') {
                curText.Remove(0, 1);
            }
            Debug.Log("PARSE! " + curText);
            for(int i = 0; i < curText.Length; i++) {
                if (i == 0) {
                    if (curText[i] == '<' && curText[i + 1] == '<') {

                    }
                }
            }
            /*
            while(curText[0] == '<') {
                GetPreTags(curText);
            }
            */
        }
        //make this a coroutine?
        /*void ParseSectionsOfNode(int c) {
            StringBuilder curText = new StringBuilder(tweeNodesToInterpret[c]);
            if(curText[0] == '\n') {
                curText.Remove(0, 1);
            }
            if(curText)
            //string curText = tweeNodesToInterpret[c];

        }*/

		void GetPreTags(StringBuilder sb){
			//get tags before linebreak
		}

		void GetPostTags(int c, SilkStory story){
			//get tags after prompt
		}

		string GetPrompt(int c, SilkStory story, SilkNode curNode){
			StringBuilder curNodeText = new StringBuilder(tweeNodesToInterpret[c]);
			StringBuilder promptContainer = new StringBuilder(tweeNodesToInterpret[c]);
			for (int p = 0; p < curNodeText.Length; p++) {
				//check for prompt
				if ((p + 2) < curNodeText.Length && (p - 2) > 0) {

					if (curNodeText [p - 1] == '>' && curNodeText [p - 2] == '>') {
							if (curNodeText [p] == '\n') {
								if (curNodeText [p + 1] != '<' && curNodeText [p + 1] != '[') {
									curNodeText.Insert (p + 1, "<<prompt>>");
								}
								
							}
					}
					

				}


			}
			//Debug.Log ("CUR NODE TEXT >>" + curNodeText);
            if (tweeNodesToInterpret[c].Contains("|")) {
				promptContainer.Replace("|", string.Empty);
			}
			if (tweeNodesToInterpret[c].Contains(ReturnTitle(tweeNodesToInterpret[c]))) {
				string storyTitleCheck = ReturnTitle(tweeNodesToInterpret[c]).TrimStart().TrimEnd();
				if (storyTitleCheck == "StoryTitle") {

					story.SetStoryName(ReturnStoryTitle(tweeNodesToInterpret[c]));
					//storyTitle = story.StoryName;
					//story.SetStoryName(filename);
				}
                else if(storyTitleCheck == "MetaData") {

                }
				else {
					promptContainer.Replace(ReturnTitle(tweeNodesToInterpret[c]), string.Empty, 0, ReturnTitle(tweeNodesToInterpret[c]).Length);
				}
			}
            
            for(int k = 0; k < curNodeText.Length; k++) {
                //problem??
                StringBuilder newTag;
                //while (promptContainer[0] == '\n') {
                    //promptContainer.Remove(0, 1);
                //}
                /*
                if(promptContainer[0] == '<' && promptContainer[1] == '<') {
                    newTag = new StringBuilder();
                    for (int i = 0; i < promptContainer.Length; i++) {
                        if(promptContainer[i] == '>' && promptContainer[i+1] == '>') {
                            //for testing
                            //if below says .Remove(); it should rather extract the tag
                            //and put it on the execution queue

                            promptContainer.Remove(0, newTag.Length);
                            break;
                        }
                        else {
                            newTag.Append(promptContainer[i]);
                        }
                    }
                    Debug.Log(newTag);
                }*/
                
                

                if (curNodeText[k] == '<' && curNodeText[k + 1] == '<') {
                    string rawTag = "";
                    for(int t = k; t < curNodeText.Length; t++) {
                        if(curNodeText[t - 1] == '>' && curNodeText[t - 2] == '>') {
                            break;
                        }
                        else {
                            rawTag += curNodeText[t];
                        }
                    }



                    //
					//TEST TAG REPLACEMENT
                    //promptContainer.Replace(rawTag, ParseRawTag(rawTag, tagFactory).Value);
					//if promptcontainer is empty and contains <<prompt>>, delete prompt

                    
					//Debug.Log ("RAWTAG" + rawTag);
                    if (ParseRawTag(rawTag, tagFactory).type == TagType.INLINE) {
                        //if (ParseRawTag(rawTag, tagFactory).TagName == "connect") {
                        //    ParseRawTag(rawTag, tagFactory).TagExecute();
                        //}

                        promptContainer.Replace(rawTag, ParseRawTag(rawTag, tagFactory).Value);
                        
                        //Debug.Log("IN");
                    }
                    else if(ParseRawTag(rawTag,tagFactory).type == TagType.SEQUENCED) {
                        curNode.executionQueue.Add(ParseRawTag(rawTag, tagFactory));
                        promptContainer.Replace(rawTag, ParseRawTag(rawTag, tagFactory).Value);
                        //Debug.Log("SQ");
                    }
					if (String.IsNullOrEmpty(promptContainer.ToString().Trim())) {
						if (curNodeText.ToString ().Contains ("<<prompt>>")) {
							curNodeText.Replace ("<<prompt>>", String.Empty);
						}
						//Debug.Log("NODE NODE::"+curNodeText);
					}


                    
                    //return to here
                    //Debug.Log(ParseRawTag(rawTag, tagFactory).TagName + " " + ParseRawTag(rawTag, tagFactory).type);

                }
				//if k is 




            }


			foreach (TextLink entry in ReturnLinks(tweeNodesToInterpret[c])) {
                //Debug.Log(entry.LinkText);
				if (tweeNodesToInterpret[c].Contains("[[" + entry.LinkText) || tweeNodesToInterpret[c].Contains("[[" + entry.LinkedNodeName)) {
                    //Debug.Log("PEWPEW " + entry.LinkText);
                    if (entry.LinkedNodeName != null) {
                        //strippedLink.Append(entry.LinkText.Replace(entry.LinkedNodeName, String.Empty));
                        //Debug.Log(strippedLink);
                    }
                    if(entry.LinkedNodeName == null) {
                        //Debug.Log("WEW?? " + curNode.GetStoryName());
                    }
                    promptContainer.Replace ("[[" + entry.LinkText, String.Empty);
					//////////////////////////////////////////////////////////////
					//this is to catch instances where the syntax [[link]] is used
					//in order to remove the trailing "]]"
					//////////////////////////////////////////////////////////////
					if (entry.LinkText == entry.LinkedNodeName) {
						promptContainer.Replace ("]]", String.Empty);
					}
					promptContainer.Replace(entry.LinkedNodeName + "]]", String.Empty);
				}
				else {
					for(int l = 0; l < promptContainer.Length; l++) {
						if(promptContainer[l] == '[' && promptContainer[l + 1] == '[') {
							string taggedLink = "";
							for(int t = l; t < promptContainer.Length; t++) {
								if(promptContainer[t] == ']' && promptContainer[t + 1] == ']') {
									taggedLink += "]]";
									break;
								}
								else {
									taggedLink += promptContainer[t];
								}
							}
							promptContainer = promptContainer.Remove(l, taggedLink.Length);
						}
					}
				}
			}
			promptContainer.Replace (System.Environment.NewLine, String.Empty);

            //test prompt
            //curNode.executionQueue.Enqueue(tagFactory.SetTag("prompt", null));
            
			return promptContainer.ToString ();
		}




		#endregion
        

        void AssignDataToNodes(SilkStory newSilkStory, SilkNode newNode, string newTweeData, string newPassage, string storyTitle) {
            newNode.nodeName = storyTitle + "_" + ReturnTitle(newTweeData).TrimEnd(' ');
            //only to remove it when required in GetNodeName
            newNode.StoryName = storyTitle;
            //add custom tag names
			//
			//TODO TEST
            //newNode.tags = ReturnCustomTags(newTweeData);

            //add custom tags

            //TODO process tags just in time, rather than doing a tag-pass
            /*
            foreach (KeyValuePair<string, string[]> tagName in newNode.tags) {

                string newTagName = "";
                //Right now, you can't use underscores in your custom tag names
                if (tagName.Key.Contains("_")) {
                    newTagName = tagName.Key.Remove(tagName.Key.IndexOf('_')).TrimStart().TrimEnd();
                }
                if (tagFactory.SetTag(newTagName, tagName.Value) != null) {
                    newNode.silkTags.Add(tagFactory.SetTag(newTagName, tagName.Value));
                }
                else {
                    Debug.LogError(newTagName + " is not a recognized tag. Check your TagFactory");
                }
            }
            */
            //Debug.Log(newNode.silkTags[0].TagName);

            //add passage
            newNode.nodePassage = newPassage;
            //TODO Add the correct amount of links to the list
            //add link names
            //Debug.Log(ReturnLinks(newTweeData).Count);
            newNode.textLinks = ReturnLinks(newTweeData);

            newSilkStory.AddToStory(newNode.nodeName, newNode);
        }

        //finish this method
        void AssignLinksToNodes(SilkMotherStory mother) {
            foreach (KeyValuePair<string, SilkStory> story in mother.MotherStory) {
                foreach (KeyValuePair<string, SilkNode> node in story.Value.Story) {
                    foreach (SilkTagBase tag in node.Value.silkTags) {

                    }
                }
            }
        }
        void AssignPassageToNodes(string newTweeData) {

        }

        string ReturnTitle(string inputToExtractTitleFrom) {
            string title = "";
            for (int i = 0; i < inputToExtractTitleFrom.Length; i++) {
                if (inputToExtractTitleFrom[i] == '\n' || inputToExtractTitleFrom[i] == '[') {
                    break;
                }

                else {
                    title += inputToExtractTitleFrom[i];
                }
            }
            return title.TrimStart(' ').TrimEnd(' ');
        }

        string ReturnStoryTitle(string nodeToInterpret) {
            string storyTitle = "";
            if (nodeToInterpret.Contains(ReturnTitle(nodeToInterpret))) {
                storyTitle = nodeToInterpret.Replace(ReturnTitle(nodeToInterpret), string.Empty).TrimEnd().TrimStart();
            }
            return storyTitle;
        }

        //finish this method
        string ReturnPassageTags(string inputToExtractTagsFrom) {
            string newTag = "";
            return newTag;
        }

        string GetRawTag(string inputText) {
            Debug.Log("fired");
            string rawTag = "";
            for(int i = 0; i < inputText.Length; i++) {
                if(inputText[i] == '>' && inputText[i+1] == '>') {
                    break;
                }
                else {
                    rawTag += inputText[i];
                }
            }
            /*for (int t = 0; t < inputText.Length; t++) {
                //might wanna remove the outer conditional
                if (inputText[t] == '<' && inputText[t + 1] == '<') {
                    for (int i = 0; i < inputText.Length; i++) {
                        if (inputText[t] == '>' && inputText[t + 1] == '>') {
                            break;
                        }
                        else {
                            rawTag += inputText[t];
                        }
                    }
                }
            }
            */
            Debug.Log("RAW IS " + rawTag);
            return rawTag;
        }
        
		SilkTagBase ParseRawTag(string inputRawTag, TagFactory tFactory) {
            RawTag newRawTag = new RawTag();
            string[] rawArguments;
            //string inputRawTag = rawTag.Replace(" ", String.Empty);
            for(int i = 0; i < inputRawTag.Length; i++) {
                if(i == 2) {
                    //inputRawTag.Replace(" ", "");

                    for (int j = i; j < inputRawTag.Length; j++) {
                        //Debug.Log(inputRawTag[j]);
                        if (!inputRawTag.Contains("=")) {
                            if (inputRawTag[j] != '>') {
                                newRawTag.RawTagName += inputRawTag[j];
                            }
                            else {
                                
                                break;
                            }
                        }
                        else if (inputRawTag[j] == '=') {
                            rawArguments = inputRawTag.Substring(j + 1).Split(',');
                            for (int r = 0; r < rawArguments.Length; r++) {
                                string rawArgument = rawArguments[r].Replace("\"", "").Replace(">>", String.Empty);
                                newRawTag.AddArgument(rawArgument);
                            }
                            
                            break;
                        }
                        else {

                            newRawTag.RawTagName += inputRawTag[j];


                        }
                    }
                    
                }
                
            }
			return tFactory.SetTag(newRawTag.RawTagName, newRawTag.TagArgs);
            
            
            //return newRawTag;
        }

        IEnumerator ParseCustomTag (string inputText) {
            string rawTag = "";
            for(int t = 0; t < inputText.Length; t++) {
                if(inputText[t] == '>' && inputText[t + 1] == '>') {
                    yield return null;
                }
                else {
                    rawTag += inputText[t];
                }
            }
        }
        Dictionary<string, string[]> ReturnCustomTags(string inputToExtractTagsFrom) {
            Dictionary<string, string[]> tags = new Dictionary<string, string[]>();
            List<string> rawTags = new List<string>();
            int iterations = 0;
            for (int i = 0; i < inputToExtractTagsFrom.Length; i++) { 
                string rawTag = "";
                //to find each custom tag
                if (inputToExtractTagsFrom[i] == '<' && inputToExtractTagsFrom[i + 1] == '<') {
                    //to get data out of each tag
                    for (int j = i + 2; j < inputToExtractTagsFrom.Length; j++) {
                        if (inputToExtractTagsFrom[j] == '>' && inputToExtractTagsFrom[j + 1] == '>') {
                            rawTags.Add(rawTag);
                            break;
                        }
                        else {
                            rawTag += inputToExtractTagsFrom[j];
                        }
                    }
                }
            }
            foreach (string tag in rawTags) {
                string tagName = "";
                string[] tagArgs = null;

                for (int i = 0; i < tag.Length; i++) {

                    if (tag[i] == '=') {
                        tagArgs = tag.Substring(i + 1).Split(',');
                        break;
                    }
                    else {
                        tagName += tag[i];

                    }
                }
                if (tagArgs != null) {

                    tags.Add(tagName + "_" + iterations, tagArgs);

                }
                else {
                    tags.Add(tagName, null);
                }
                iterations += 1;
            }
            foreach (KeyValuePair<string, string[]> tag in tags) {
                //Debug.Log(tag.Key);
            }
            return tags;

        }

        //TODO clean this code up and remove unused variables
        //TODO replace all of the inputToExtractLinksFrom variables with inputCopy
        //TODO remove the link substring from inputCopy once it's been added to the list
        List<TextLink> ReturnLinks(string inputToExtractLinksFrom) {
            
            StringBuilder inputCopy = new StringBuilder();
            inputCopy.Append(inputToExtractLinksFrom);
            List<SilkLink> newSilkLinks = new List<SilkLink>();
            List<TextLink> newLinks = new List<TextLink>();
            for (int i = 0; i < inputCopy.Length; i++) {
                if (inputCopy[i] == '[' && inputCopy[i + 1] == '[') {

                    TextLink newLink = new TextLink();
                    //I might want to reevaluate how I deal with link text that is repeated.
                    //for now this should work
                    for (int j = i + 2; j < inputCopy.Length; j++) {
                        //make sure that it breaks if there is no |
                        if (inputCopy[j] == '|') {
                            string newLinkValue = "";
							//in ReturnLinks once newLink is got
							if (newLink.LinkText.Contains("<<")) {

								string rawTag = "";
								for (int l = 0; l < newLink.LinkText.Length; l++) {
									if (newLink.LinkText[l] == '<' && newLink.LinkText[l + 1] == '<') {

										for (int t = l; t < newLink.LinkText.Length; t++) {
											if (newLink.LinkText[t] == '>' && newLink.LinkText[t + 1] == '>') {

												rawTag += ">>";

												newLink.LinkText = newLink.LinkText.Replace(rawTag, ParseRawTag(rawTag, tagFactory).Value);

												//Debug.LogWarning(newLink);
												//inputCopy.Remove(t, rawTag.Length);

												break;
											}
											else {
												rawTag += newLink.LinkText[t];

											}
										}
									}
								}
							}
                            for (int k = j + 1; k < inputCopy.Length; k++) {
                                if (inputCopy[k] == ']' && inputCopy[k + 1] == ']') {
                                    //Debug.Log(">> " + newLink);
                                    //Debug.Log("!!!!!!!! " + newLink.LinkText);
                                    if (newLink.LinkText.Contains(newLink.LinkedNodeName)) {
                                        //Debug.Log("HIIIIIIIIIIIIIIII");
                                        newLink.LinkText = newLink.LinkText.Replace(newLink.LinkedNodeName, string.Empty);
                                    }
                                    //Debug.Log("HIIIIIIIIIIIIIIII");

                                    newLinks.Add(newLink);
                                    if (newLinkValue.Length > 0) {
                                        inputCopy.Replace(newLinkValue, "");
                                    }
                                    //Debug.Log("NEW LINK IS " + newLink);

                                    //Debug.Log(inputCopy);
                                    break;
                                }
                                else {
                                    newLink.LinkedNodeName += inputCopy[k];
                                    if (inputCopy[j] == ']' && inputCopy[j + 1] == ']') {
                                        if (newLink.LinkText.Contains(newLink.LinkedNodeName)) {
                                            //newLink.LinkText = newLink.LinkText.Replace(newLink.LinkedNodeName, string.Empty);
                                        }
                                        //TODO test if this works
                                        //inputCopy.Replace(newLink, "");
                                        //newLink.Replace(
                                        newLinks.Add(newLink);
                                        break;
                                    }
                                }
                            }
                        }
                        if (inputCopy[j] == ']' && inputCopy[j + 1] == ']') {
                            //newLinks.Add(newLink, newLink);
                            //inputCopy.Replace(newLink, "");
                            //break;
                            //Debug.Log("NEW LINK IS " + newLink);
                            if (!newLink.LinkText.Contains("|")) {
                                
                                newLinks.Add(newLink);
                                break;
                            }
                            break;

                        }

                        else {
							//TODO add code to replace tags in linktext here probably
                            newLink.LinkText += inputCopy[j];


                        }
                    }
                }

            }

            //Debug.Log(newLinks.ContainsValue("2"));
            int linkNum = 0;
            foreach (TextLink link in newLinks) {
                linkNum++;
            }
            //Debug.Log(linkNum + " is the number of links");
            return newLinks;
        }


        //garbage fire
        //TODO bring Passage Setting code from start method down here
        string ReturnPassage(string inputToExtractPassageFrom) {
            Debug.Log("full text is " + inputToExtractPassageFrom);
            string passage = "";

            for (int i = 0; i < inputToExtractPassageFrom.Length; i++) {
                if (inputToExtractPassageFrom[i] == ':') {
                    for (int j = i; j < inputToExtractPassageFrom.Length; j++) {

                    }
                }
                else if (inputToExtractPassageFrom[i] == '[' || inputToExtractPassageFrom[i] == '<') {

                }
                else {
                    passage += inputToExtractPassageFrom[i];
                }
            }
            Debug.Log("passage is " + passage);
            return passage;
        }
    }
}
