using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Silk;
public class ResponsePrinter : MonoBehaviour {
    //attach to container of responses
    //List<Response> curResponses = new List<Response>();
    List<GameObject> curDisplayResponses = new List<GameObject>();
	Response selectedResponse;
	public int curResponse;
    Navigation normalNav = new Navigation();
    Navigation customNav = new Navigation();
    Selectable topItem;
    Selectable bottomItem;

    public GameObject responsePrefab;
    
    void SetCustomNavigation() {

    }

	public void ChangeResponses(){
		ClearResponses ();
        ClearResponseUI();
		PopulateResponseUI ();
	}
    void ClearResponseUI() {
        foreach(Transform child in this.transform) {
            Destroy(child.gameObject);
        }
    }
	void PopulateResponseUI(){
		curResponse = 0;

        normalNav.mode = Navigation.Mode.Vertical;
        customNav.mode = Navigation.Mode.Explicit;
        

        //will need to get this from the current silknode in the traversal structure
        foreach (KeyValuePair<string, SilkGraph> story in Parser.Instance.mother.MotherGraph) {
			foreach(KeyValuePair<string, SilkNode> node in story.Value.Story) {
				if(node.Value.GetNodeName() == "Start") {
					for(int i = 0; i < node.Value.silkLinks.Count; i++) {
						
						GameObject newResponse = Instantiate(responsePrefab);
						AddResponse (newResponse.GetComponent<Response>());
						//means this script must be attached to the parent object
						newResponse.transform.SetParent(this.gameObject.transform);
						newResponse.transform.localScale = new Vector3(1, 1, 1);
                        curDisplayResponses.Add(newResponse);
						newResponse.transform.localPosition = new Vector3(newResponse.transform.position.x, newResponse.transform.position.y, 0);
						newResponse.GetComponent<Response>().responseText = node.Value.silkLinks[i].LinkText;
                        if(i == 0) {
                            topItem = newResponse.GetComponent<Selectable>();
                            customNav.selectOnDown = topItem.GetComponent<Selectable>();

                        }
                        else if (i == node.Value.silkLinks.Count - 1) {
                            bottomItem = newResponse.GetComponent<Selectable>();
                            customNav.selectOnUp = bottomItem;
                        }
                        if (i == 0 || i == node.Value.silkLinks.Count - 1) {
                            newResponse.GetComponent<Button>().navigation = customNav;

                        }
                        else {
                            newResponse.GetComponent<Button>().navigation = normalNav;
                        }
						if (i == 0) {
                            newResponse.GetComponent<Selectable>().Select();
						}
                        
                        
					}
                    /*
                    for(int j = 0; j < curDisplayResponses.Count; j++) {
                        topItem = curDisplayResponses[0];
                        bottomItem = curDisplayResponses[curDisplayResponses.Count - 1];
                        if(j == 0) {
                            customNav.mode = Navigation.Mode.Explicit;
                            customNav.selectOnUp = topItem.GetComponent<Selectable>();
                        }
                        else if(j == curDisplayResponses.Count - 1) {
                            customNav.mode = Navigation.Mode.Explicit;
                            customNav.selectOnDown = bottomItem.GetComponent<Selectable>();
                        }
                    }
                    */
                    

				}
			}
		}
		//selectedResponse = curResponses [curResponse];

	}
	void ClearResponses(){
		//curResponses.Clear ();
	}

	void AddResponse(Response newResponse){
		//curResponses.Add (newResponse);
	}

	public void SelectedResponseChange(int changeNum){
        /*
        if (curResponses != null) {
            if (curResponse + changeNum <= (curResponses.Count - 1) && curResponse + changeNum >= 0) {
                curResponse += changeNum;
                selectedResponse = curResponses[curResponse];
            }
            else if (curResponse + changeNum > (curResponses.Count - 1)) {
                curResponse = 0;
                selectedResponse = curResponses[curResponse];
            }
            else if (curResponse + changeNum < 0) {
                curResponse = (curResponses.Count - 1);
                selectedResponse = curResponses[curResponse];
            }
        }
        */

	}

    public void InvokeConfirm() {

        //ConfirmResponse();

    }

    //public Response ConfirmResponse() {
        //Debug.Log(curResponses[curResponse].responseText);
        //return curResponses[curResponse];
    //}




}
