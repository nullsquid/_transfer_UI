using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Silk;
public class ResponsePrinter : MonoBehaviour {
    //attach to container of responses
	List<Response> curResponses = new List<Response>();
	Response selectedResponse;
	public int curResponse;

    public GameObject responsePrefab;
    
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
		//will need to get this from the current silknode in the traversal structure
		foreach(KeyValuePair<string, SilkGraph> story in Parser.Instance.mother.MotherGraph) {
			foreach(KeyValuePair<string, SilkNode> node in story.Value.Story) {
				if(node.Value.GetNodeName() == "Start") {
					for(int i = 0; i < node.Value.silkLinks.Count; i++) {
						GameObject newResponse = Instantiate(responsePrefab);
						AddResponse (newResponse.GetComponent<Response>());
						//means this script must be attached to the parent object
						newResponse.transform.SetParent(this.gameObject.transform);
						newResponse.transform.localScale = new Vector3(1, 1, 1);
						newResponse.transform.localPosition = new Vector3(newResponse.transform.position.x, newResponse.transform.position.y, 0);
						newResponse.GetComponent<Response>().responseText = node.Value.silkLinks[i].LinkText;

					}
				}
			}
		}
		selectedResponse = curResponses [curResponse];

	}
	void ClearResponses(){
		curResponses.Clear ();
	}

	void AddResponse(Response newResponse){
		curResponses.Add (newResponse);
	}

	public void SelectedResponseChange(int changeNum){

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
        
		

	}




}
