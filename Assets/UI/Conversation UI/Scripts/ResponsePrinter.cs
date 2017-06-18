using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Silk;
public class ResponsePrinter : MonoBehaviour {

    List<GameObject> curDisplayResponses = new List<GameObject>();
    public GameObject responsePrefab;

	//TODO make this into an event that can be populated from Silk
	public void UpdateResponses(){
        ClearResponseUI();
		PopulateResponseUI ();
	}
    void ClearResponseUI() {
		curDisplayResponses.Clear ();
        foreach(Transform child in this.transform) {
            Destroy(child.gameObject);
        }
    }
	void PopulateResponseUI(){
		
        //TODO need to get this from the current silknode in the traversal structure
		//TODO roll this loop series into Silk proper
        foreach (KeyValuePair<string, SilkGraph> story in Parser.Instance.mother.MotherGraph) {
			foreach(KeyValuePair<string, SilkNode> node in story.Value.Story) {
				if(node.Value.GetNodeName() == "Start") {
					for(int i = 0; i < node.Value.silkLinks.Count; i++) {
						
						GameObject newResponse = Instantiate(responsePrefab);
						////////////////////////////////////////////////////////////////
						//THIS SCRIPT MUST BE ATTACHED TO THE PARENT OF ALL RESPONSES///
						////////////////////////////////////////////////////////////////
						newResponse.transform.SetParent(this.gameObject.transform);
						newResponse.transform.localScale = new Vector3(1, 1, 1);
                        curDisplayResponses.Add(newResponse);
						newResponse.transform.localPosition = new Vector3(newResponse.transform.position.x, newResponse.transform.position.y, 0);
						newResponse.GetComponent<Response>().responseText = node.Value.silkLinks[i].LinkText;
						if (i == 0) {
							newResponse.GetComponent<Selectable>().Select();
							newResponse.GetComponent<Response> ().navPos = Response.NavPosition.TOP;

						} else if (i == node.Value.silkLinks.Count - 1) {
							
							newResponse.GetComponent<Response> ().navPos = Response.NavPosition.BOTTOM;

						} else {
							newResponse.GetComponent<Response> ().navPos = Response.NavPosition.MIDDLE;
						}
                        
					}
				}
			}
		}
		this.gameObject.GetComponent<ResponseNavHandler> ().SetCustomNavigation (curDisplayResponses);


	}
		




}
