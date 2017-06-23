﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class DialogueManager : MonoBehaviour {
    #region Singleton
    private static DialogueManager _instance;
    public static DialogueManager Instance
    {
        get
        {
            if (_instance == null) {
                GameObject dm = new GameObject("DialogueManager");
                dm.AddComponent<DialogueManager>();

            }
            return _instance;
        }

    }
    void Awake() {
        _instance = this;

    }
    #endregion
	////////////////////////////////////////////
	////////////////////////////////////////////
	////////////////////////////////////////////
    //REQUIRES SILK 0.4.1 OR LATER TO FUNCTION//
	////////////////////////////////////////////
	////////////////////////////////////////////
	////////////////////////////////////////////
	/// 
	/// 
	SilkStory rootStory;
	SilkStory curStory;
	SilkNode rootNode;
	SilkNode curNode;

	void Start(){
		StartCoroutine (Test ());
	}

	//TODO remove once actual method for getting text in
	IEnumerator Test(){
		yield return new WaitForEndOfFrame ();
		GetRootStory ("_TRANSUBSTANCE");
		GetRootNode ();
	}
	public SilkNode CurNode{
		get{
			return curNode;
		}
	}

	public SilkStory CurStory{
		get{
			return curStory;
		}
	}
	#region Callbacks

	#endregion

	#region Accessor Methods
	void GetRootStory(string rootStoryName){
		rootStory = Silky.Instance.mother.GetStoryByName (rootStoryName);
		curStory = rootStory;
	}

	void GetNextStory(string nextStoryName){

	}

	void GetRootNode(){
		rootNode = curStory.GetNodeByName ("Start");
		curNode = rootNode;
	}

	void GetNextNode(SilkLink link){

	}

	void GetNextNode(string nextNodeName){
		curNode = curStory.GetNodeByName (nextNodeName);
	}
		

	public string GetNodePassage(){
		return curNode.nodePassage;
	}

	public List<SilkLink> GetSilkLinks(){
		return curNode.silkLinks;
	}
	#endregion

	void ParseNode(){
		StartCoroutine (ProcessNodeTags ());
	}

	public IEnumerator ExecuteNode(){
		yield return null;
	}

	IEnumerator ProcessNodeTags(){
		foreach (Silk.SilkTagBase tag in curNode.silkTags) {
			//run each tag in sequence
			//If it's an override tag, do that instead
		}
		yield return null;
	}
}