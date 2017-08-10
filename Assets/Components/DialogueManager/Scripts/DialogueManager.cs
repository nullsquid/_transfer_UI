using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class DialogueManager : MonoBehaviour {
    public string connectID;
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
    private void Update() {
        Debug.Log(connectID);
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
        //newNodeStart += ExecuteNode;
		rp.onButtonSubmit += FindNextNode;
		tp.onNodeChange += GetNodePassage;
	}

	void OnDisable(){
        //newNodeStart -= SetNodeTags;
        //nodeCleanup -= UnSetNodeTags;
        //newNodeStart -= ExecuteNode;
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
    SilkNode metaDataNode;

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
        GetConnectID();
	}

	public void GetNextStory(string nextStoryName){
		curStory = Silky.Instance.mother.GetStoryByName (nextStoryName);
		GetRootNode ();
        GetConnectID();
	}
    public void GetConnectID() {
        metaDataNode = curStory.GetNodeByName("MetaData");
        foreach(SilkTagBase tag in metaDataNode.executionQueue) {
            if(tag.TagName == "connect") {
                tag.TagExecute();
            }
        }
    }
	public void GetRootNode(){
		//if (curStory.GetNodeName ("Start") != null) {
			rootNode = curStory.GetNodeByName ("Start");
			curNode = rootNode;
		//} else {
			//Debug.LogError ("No root node found");
		//}
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

				ExecuteNode();
				break;

			}
		}
	}

	public void RunNodeData(){
		if (rootNode != curNode) {
			newNodeStart ();
		} else {
			Debug.Log ("Waiting for input");
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
				
				if (tag.IsComplete == true) {
                    Debug.Log("TRUE");
                    continue;
                }
				else if(tag.IsComplete == false) {
                    Debug.Log("FALSE");
					if (curNode.executionQueue.Count >= 1) {
                        //if(tag.TagName == "connect") {
                        //    Debug.Log("boop");
                        //    connectID = tag.Value;
                        //}
                        Debug.Log(tag.TagName);
						tag.TagExecute();

					}
                    //break;
                }
            }
            //else??
            

        }
		RunNodeData ();
		//Debug.Log ("CURNODE IS " + curNode.nodeName + " || " + "ROOTNODE IS " + rootNode.nodeName);
    }
    /*public bool IEnumerator WaitForTagComplete() {
        yield return new WaitUntil(MoveToNextTag() == true)
    }*/
	public bool MoveToNextTag(){
        //Debug.Log("sup?");
        return true;
	}






}
