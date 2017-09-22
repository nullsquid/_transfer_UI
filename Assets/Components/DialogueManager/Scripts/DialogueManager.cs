using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
using UnityEngine.Events;
public class DialogueManager : MonoBehaviour {
    public string level;
    public string connectID;
    
	//need to decouple this
	ResponsePrinter rp;
	TextPrinter tp;
	Terminal terminal;
    public delegate void NodeCleanup();
    public delegate void NodeStartSequence();
	public delegate void OnTagComplete ();
    public event NodeCleanup nodeCleanup;
    public event NodeStartSequence newNodeStart;
	public event OnTagComplete tagComplete;

	public UnityEvent onSoundEffect;

    public string startingNodeName;
    public bool isInTestingMode = false;
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
		//Debug.Log (curNode.silkLinks.Count);
		//HACK checks every frame for null connectID and if so, set it to what it should be
		if (connectID == null) {
			//Debug.Log ("booooop");
			//foreach () {
			//	if(tag
				GetConnectID ();

			//}
		}
        if(level == null) {
            GetCurLevel();
        }
		//if(connectID == null && 
		//curNode.LogQueue ();
    }
    #endregion
    void OnEnable(){
		if (rp == null) {
			rp = GameObject.Find ("Response_Pannel").GetComponent<ResponsePrinter> ();
		}
		if (tp == null) {
			tp = GameObject.Find ("Text_pannel").GetComponent<TextPrinter> ();
		}
		if (terminal == null) {
			terminal = GameObject.FindObjectOfType<Terminal> ();
		}
        //newNodeStart += SetNodeTags;
        //nodeCleanup += UnSetNodeTags;
        //newNodeStart += ExecuteNode;
		rp.onButtonSubmit += FindNextNode;
		tp.onNodeChange += GetNodePassage;
        //nodeCleanup += ClearConnectQueue;
	}

	void OnDisable(){
        //newNodeStart -= SetNodeTags;
        //nodeCleanup -= UnSetNodeTags;
        //newNodeStart -= ExecuteNode;
		rp.onButtonSubmit -= FindNextNode;
		tp.onNodeChange -= GetNodePassage;
        //nodeCleanup -= ClearConnectQueue;
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

	public void InitializationCallback(){
        if (isInTestingMode == false) {
            StartCoroutine(InitializeTransferText());
        }
        else if(isInTestingMode == true) {
            StartCoroutine(InitializeTestTransferText(startingNodeName));
        }
	}

	//TODO remove once actual method for getting text in
    IEnumerator InitializeTestTransferText(string nodeName) {
        yield return new WaitForEndOfFrame();

        if(GameObject.FindObjectOfType<Importer>().useFullText == true) {
            GetRootStory(nodeName);
            GetRootNode();
        }
    }
	IEnumerator InitializeTransferText(){
        yield return new WaitForEndOfFrame();
        //
        if (GameObject.FindObjectOfType<Importer>().useFullText == true) {
            GetRootStory("9" + Transfer.System.CharacterManager.instance.GetPlayerID());
        }
        else {
            GetRootStory("sample_withTags");
        }
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
        GetCurLevel();
	}
    void ClearConnectQueue() {
        curNode.executionQueue.Clear();
        curNode.connectQueue.Clear();

    }
    public void WaitForNextStory(string nextStory, float time) {
        StartCoroutine(WaitAndGetNextStory(nextStory, time));
        
    }
    IEnumerator WaitAndGetNextStory(string nextStoryName, float timeToWait) {
        yield return new WaitForSeconds(timeToWait);
        GetNextStory(nextStoryName);
        //bit ugly but whatever\\
        terminal.ChangeState(new IdleState());
		GameObject.FindObjectOfType<IdleTextPrinter> ().InvokeIdlePrint ("\n>>\n>>NEW MEMORY UNLOCKED");
		if (connectID == null || connectID == "") {
			//terminal.buddyList.SetActive(false);
			terminal.ChangeState (new ConnectState ());

			GameObject.FindObjectOfType<TextPrinter> ().TriggerPrinting ();
		}

    }

	//butts
	public void GetNextStory(string nextStoryName){
        Debug.Log("NEXT STORY FIRED");
        //ClearConnectQueue();
        curStory = Silky.Instance.mother.GetStoryByName (nextStoryName);
        GetRootNode ();
		GetConnectID();
        GetCurLevel();

		if (connectID == null || connectID == "") {
			//terminal.buddyList.SetActive(false);
			terminal.ChangeState (new ConnectState ());
            
			GameObject.FindObjectOfType<TextPrinter> ().TriggerPrinting ();
		}
		//else if


	}
    public void GetConnectID() {
        metaDataNode = curStory.GetNodeByName("MetaData");
        foreach(SilkTagBase tag in metaDataNode.executionQueue) {
            if(tag.TagName == "connect") {
                tag.TagExecute();
            }

        }

    }
    public void GetCurLevel() {
        metaDataNode = curStory.GetNodeByName("MetaData");
        foreach(SilkTagBase tag in metaDataNode.executionQueue) {
            if(tag.TagName == "level") {
                tag.TagExecute();
            }
        }
    }
	public void GetRootNode(){
        //ClearConnectQueue();
		//if (curStory.GetNodeName ("Start") != null) {
			rootNode = curStory.GetNodeByName ("Start");
			curNode = rootNode;
        //ClearConnectQueue();
        foreach (Silk.SilkTagBase tag in curNode.executionQueue) {

            //
            //Debug.Log(tag);
            if (tag != null) {

                if (tag.IsComplete == true) {
                    TextPrinter.onPrintComplete -= tag.TagExecute;
                    //Debug.Log("TRUE");
                    continue;
                }
                else if (tag.IsComplete == false) {
                    //Debug.Log("FALSE");
                    if (curNode.executionQueue.Count >= 1) {
                        //if(tag.TagName == "connect") {
                        //    Debug.Log("boop");
                        //    connectID = tag.Value;
                        //}
                        //Debug.Log(tag.TagName);
                        //if (tag.TagName == "wait") {
                        //    TextPrinter.onPrintComplete += tag.TagExecute;
                        //}
                        //else {
						if (tag.TagName == "sfx") {
							curNode.connectQueue.Add (tag);
						} else if (tag.TagName == "error") {
							curNode.connectQueue.Add (tag);
						} else if (tag.TagName == "wait") {
							curNode.connectQueue.Add (tag);
                            
                        }
                        if(tag.TagName == "prob") {
                            CurNode.connectQueue.Add(tag);
                        }
						else {
							tag.TagExecute ();
						}
                        //}

                    }
                    //break;
                }
            }
            //else??


        }

        //} else {
        //Debug.LogError ("No root node found");
        //}
        //newNodeStart ();
    }

	public void FindNextNodeByName(string nodeName){
		SilkNode nextNode;

		nextNode = curStory.GetNodeByKey(nodeName);
        //Debug.Log ("HI NAT " + nextNode);
        
        curNode = nextNode;
        //ClearConnectQueue();
        nodeCleanup();

        ExecuteNode ();
		//RunNodeData ();
		/*foreach (Silk.SilkTagBase tag in curNode.executionQueue) {

			//
			//Debug.Log(tag);
			if (tag != null) {

				if (tag.IsComplete == true) {
					//Debug.Log("TRUE");
					continue;
				} else if (tag.IsComplete == false) {
					//Debug.Log("FALSE");
					if (curNode.executionQueue.Count >= 1) {
						//if(tag.TagName == "connect") {
						//    Debug.Log("boop");
						//    connectID = tag.Value;
						//}
						//Debug.Log(tag.TagName);
						tag.TagExecute ();

					}
					//break;
				}
			}
		}
		RunNodeData ();
		*/

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
        //Debug.Log(curNode.silkLinks.Count);
//		if (curNode.nodePassage != null || curNode.nodePassage != "") {
			return curNode.nodePassage;
//		}
//		return null;
	}

	public List<SilkLink> GetSilkLinks(){
		return curNode.silkLinks;
	}
	#endregion




    public void ExecuteNode() {
        
        //Debug.Log ("NYOOM");
        //Debug.Log ("BORGH ! " + curNode.executionQueue);
        if (curNode.executionQueue != null) {
            foreach (Silk.SilkTagBase tag in curNode.executionQueue) {

                //
                //Debug.Log(tag);
                if (tag != null) {

                    if (tag.IsComplete == true) {
                        Debug.Log("TRUE");
                        TextPrinter.onPrintComplete -= tag.TagExecute;
                        continue;
                    }
                    else if (tag.IsComplete == false) {
                        Debug.Log("FALSE");
                        if (curNode.executionQueue.Count >= 1) {
                            //if(tag.TagName == "connect") {
                            //    Debug.Log("boop");
                            //    connectID = tag.Value;
                            //}
                            Debug.Log(tag.TagName);
                            if (tag.TagName == "wait") {
                                //I might want to make another list in the node
                                //where i put tags that need to be executed on connect
                                //and in connect state i run that

                                //need to remove this once  it's over
                                TextPrinter.onPrintComplete += tag.TagExecute;

                            }
                            else if (tag.TagName == "nodewait") {
                                TextPrinter.onPrintComplete += tag.TagExecute;
                            }
                            else if (tag.TagName == "sfx") {
                                //tag.TagExecute();
                                //Debug.Log("hey hi");
                                //StartCoroutine(WaitForConnect(tag));
                                tag.TagExecute();
                                //curNode.connectQueue.Add(tag);
                            }
                            else {
                                //StartCoroutine(WaitForConnect(tag));
                                tag.TagExecute();
                            }
                        }
                        //break;
                    }
                }
                //else??


            }
        }
        RunNodeData();
		//Debug.Log ("CURNODE IS " + curNode.nodeName + " || " + "ROOTNODE IS " + rootNode.nodeName);
    }
    /*public bool IEnumerator WaitForTagComplete() {
        yield return new WaitUntil(MoveToNextTag() == true)
    }*/

    IEnumerator WaitForConnect(SilkTagBase tag) {
        while(true) {
            if(terminal.GetState() == new ConnectState()) {
                Debug.Log(terminal.GetState());
                tag.TagExecute();
                yield return null;
            }
        }
    }
	public bool MoveToNextTag(){
        //Debug.Log("sup?");
        return true;
	}

    public void WaitForNextNode(float time, string nodeName) {
        Debug.Log(nodeName);
        StartCoroutine(WaitAndFindNextNode(time, nodeName));
    }

    IEnumerator WaitAndFindNextNode(float timeToWait, string nodeName) {
        SilkNode nextNode;
        yield return new WaitForSeconds(timeToWait);

        nextNode = curStory.GetNodeByName(nodeName);

        curNode = nextNode;
        nodeCleanup();
        ExecuteNode();
        //RunNodeData();
    }






}
