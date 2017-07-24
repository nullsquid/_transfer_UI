using System.Collections;
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

	public void GetNextStory(string nextStoryName){
		curStory = Silky.Instance.mother.GetStoryByName (nextStoryName);
		GetRootNode ();
	}

	public void GetRootNode(){
		rootNode = curStory.GetNodeByName ("Start");
		curNode = rootNode;
		//newNodeStart ();
	}


	public void FindNextNode(string response){
		//Debug.Log (response);
		SilkNode nextNode;
		//GetNextStory ("5M");
		//GetRootNode ();
		foreach (SilkLink link in curNode.silkLinks) {
			if (response == link.LinkText) {
				nextNode = link.LinkedNode;
				nodeCleanup();
				curNode = nextNode;

				Debug.Log (curNode.nodeName);

                //alright so this should probably wait for some kind of call to actually START 
                //the node and not put this in traversal
				newNodeStart();
				break;

			}
		}
        

	}
    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            //newNodeStart();
        }
    }


    public string GetNodePassage(){
		return curNode.nodePassage;
	}

	public List<SilkLink> GetSilkLinks(){
		return curNode.silkLinks;
	}
	#endregion




    public void ExecuteNode() {
		
        foreach(Silk.SilkTagBase tag in curNode.executionQueue) {

            //
            //Debug.Log(tag);
            if (tag != null) {
                if (curNode.executionQueue.Count >= 1) {
                    //Debug.Log("EXECUTE " + tag.TagName);
					//this isn't waiting for completion
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
        Debug.Log("sup?");
        return true;
	}






}
