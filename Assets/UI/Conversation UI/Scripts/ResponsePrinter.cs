using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//TODO Fix Silk integration
using Silk;
public class ResponsePrinter : MonoBehaviour {

    List<GameObject> curDisplayResponses = new List<GameObject>();
    public GameObject responsePrefab;

	//TODO make this into an event that can be populated from Silk
	public void UpdateResponses(){
        ClearResponseUI();
		PopulateResponseUI();
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
        foreach (KeyValuePair<string, SilkStory> story in Silky.Instance.mother.MotherStory) {
            foreach (KeyValuePair<string, SilkNode> node in story.Value.Story) {
                if (node.Value.GetNodeName() == "Start") {
                    for (int i = 0; i < node.Value.silkLinks.Count; i++) {

                        GameObject newresponse = Instantiate(responsePrefab);
                        ////////////////////////////////////////////////////////////////
                        //this script must be attached to the parent of all responses///
                        ////////////////////////////////////////////////////////////////
                        newresponse.transform.SetParent(this.gameObject.transform);
                        newresponse.transform.localScale = new Vector3(1, 1, 1);
                        curDisplayResponses.Add(newresponse);
                        newresponse.transform.localPosition = new Vector3(newresponse.transform.position.x, newresponse.transform.position.y, 0);
                        newresponse.GetComponent<Response>().responseText = node.Value.silkLinks[i].LinkText;
						Debug.Log(node.Value.silkLinks[i].LinkText);
                        if (i == 0) {
                            newresponse.GetComponent<Selectable>().Select();
                            newresponse.GetComponent<Response>().navPos = Response.NavPosition.TOP;

                        }
                        else if (i == node.Value.silkLinks.Count - 1) {

                            newresponse.GetComponent<Response>().navPos = Response.NavPosition.BOTTOM;

                        }
                        else {
                            newresponse.GetComponent<Response>().navPos = Response.NavPosition.MIDDLE;
                        }

                    }
                }
            }
        }
        this.gameObject.GetComponent<ResponseNavHandler>().SetCustomNavigation(curDisplayResponses);


    }





}
