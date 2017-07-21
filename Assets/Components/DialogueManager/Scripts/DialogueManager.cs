﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class DialogueManager : MonoBehaviour {
	//need to decouple this
	ResponsePrinter rp;
	TextPrinter tp;
    public delegate void NodeCleanup();
    public delegate void NodeStartSequence();
	public delegate void OnTagComplete ();
    public event NodeCleanup nodeCleanup;
    public event NodeStartSequence newNodeStart;
	public event OnTagComplete tagComplete;
    #region Singleton
    public static DialogueManager instance;
    void Awake() {

        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
    #endregion
	void OnEnable(){
		if (rp == null) {
			rp = GameObject.Find ("Response_Pannel").GetComponent<ResponsePrinter> ();
		}
		if (tp == null) {
			tp = GameObject.Find ("Text_pannel").GetComponent<TextPrinter> ();
		}
        //newNodeStart += SetNodeTags;
        //nodeCleanup += UnSetNodeTags;
        newNodeStart += ExecuteNode;
		rp.onButtonSubmit += FindNextNode;
		tp.onNodeChange += GetNodePassage;
	}

	void OnDisable(){
        //newNodeStart -= SetNodeTags;
        //nodeCleanup -= UnSetNodeTags;
        newNodeStart -= ExecuteNode;
		rp.onButtonSubmit -= FindNextNode;
		tp.onNodeChange -= GetNodePassage;
	}

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
		GetRootStory ("Sample");
		GetRootNode ();
	}
	public SilkNode CurNode{
		get{
			return curNode;
		}
	}

	public SilkStory CurStory{
        set
        {
            curStory = value;
        }
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
		SilkNode nextNode;
		foreach (SilkLink links in curNode.silkLinks) {
			
		}
	}

	void GetNextNode(string nextNodeName){
		curNode = curStory.GetNodeByName (nextNodeName);
		//SetNodeTags ();
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

	/*public IEnumerator ExecuteNode(){
		//Execute command queue ==> command pattern
		foreach (Silk.SilkTagBase tag in curNode.executionQueue) {
			
		}
		yield return null;
	}*/
    public void ExecuteNode() {
        foreach(Silk.SilkTagBase tag in curNode.executionQueue) {
            //Debug.Log(tag);
            if (tag != null) {
                if (curNode.executionQueue.Count >= 1) {
                    //Debug.Log("EXECUTE " + tag.TagName);
                    tag.TagExecute();
                    //curNode.executionQueue.Remove(tag);
                    //curNode.executionQueue.Dequeue();
                }
                else {
                    break;
                }
            }
            //else??
            else if (MoveToNextTag()) {
                Debug.Log("TRUE");
                continue;
            }
            else {
                Debug.Log("FALSE");
                
            }
        }
    }

	public bool MoveToNextTag(){
        return true;
	}

	/*void SetNodeTags(){
		foreach (Silk.SilkTagBase tag in curNode.executionQueue) {
			tag.tagComplete += MoveToNextTag;
		}
	}

	void UnSetNodeTags(){
		foreach (Silk.SilkTagBase tag in curNode.executionQueue) {
			tag.tagComplete -= MoveToNextTag;
		}
	}*/

	IEnumerator ProcessNodeTags(){
		foreach (Silk.SilkTagBase tag in curNode.executionQueue) {
			//run each tag in sequence
			//If it's an override tag, do that instead
			//OnTagComplete += tag.OnExecutionComplete;
		}
		yield return null;
	}

    /*IEnumerator TraverseToNextNode(SilkNode nextNode) {
        
    }*/

	public void FindNextNode(string response){
		//Debug.Log (response);
		SilkNode nextNode;
		foreach (SilkLink link in curNode.silkLinks) {
			if (response == link.LinkText) {
				nextNode = link.LinkedNode;
                nodeCleanup();
                curNode = nextNode;
                //Debug.Log(curNode.nodePassage);
                //something is happening at the "go away" node where it can't find the next node
                Debug.Log(curNode.nodeName + " " + curNode.silkLinks[0].LinkText);
                newNodeStart();
                break;

			}
		}

	}


}
