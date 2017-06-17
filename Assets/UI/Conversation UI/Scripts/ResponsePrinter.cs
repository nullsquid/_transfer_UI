using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Silk;
public class ResponsePrinter : MonoBehaviour {

    List<GameObject> curDisplayResponses = new List<GameObject>();
	Response selectedResponse;
	public int curResponse;
    Navigation normalNav = new Navigation();
    Navigation customNav = new Navigation();
    Selectable topItem;
    Selectable bottomItem;
	Selectable secondItem;
	Selectable penultimateItem;


    public GameObject responsePrefab;
    
    void SetCustomNavigation() {

    }

	public void ChangeResponses(){
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
						//////////////////////////////////////////////////////
						//THIS SCRIPT MUST BE ATTACHED TO THE PARENT OBJECT///
						//////////////////////////////////////////////////////
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
					foreach (Transform child in transform) {
						switch (child.GetComponent<Response> ().navPos) {

						case Response.NavPosition.TOP:
							
							for (int i = 0; i < curDisplayResponses.Count; i++) {
								Debug.Log ("Hey");
								if (i == curDisplayResponses.Count - 1) {
									customNav.selectOnUp = curDisplayResponses [i].GetComponent<Selectable> ();
								} else if (i == 1) {
									customNav.selectOnDown = curDisplayResponses [i].GetComponent<Selectable>();
								}
							}
							child.GetComponent<Button>().navigation = customNav;


							//customNav.selectOnDown
							break;
						case Response.NavPosition.BOTTOM:
							for (int i = 0; i < curDisplayResponses.Count; i++) {
								if (i == 0) {
									customNav.selectOnDown = curDisplayResponses [i].GetComponent<Selectable> ();
								} else if (i == curDisplayResponses.Count - 2) {
									customNav.selectOnUp = curDisplayResponses [i].GetComponent<Selectable> ();
								}
							}
							child.GetComponent<Button> ().navigation = customNav;
							break;
						case Response.NavPosition.MIDDLE:
							child.GetComponent<Button> ().navigation = normalNav;
							break;
						}
					}
				}
			}
		}

	}
		




}
