using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResponseNavHandler : MonoBehaviour {
	Navigation normalNav = new Navigation();
	Navigation customNav = new Navigation();

	void Start(){
		Cursor.visible = false;
	}
	public void SetCustomNavigation(List<GameObject> curDisplayResponses){
		normalNav.mode = Navigation.Mode.Vertical;
		customNav.mode = Navigation.Mode.Explicit;

		foreach (Transform child in transform) {
			switch (child.GetComponent<Response> ().navPos) {

			case Response.NavPosition.TOP:

				for (int i = 0; i < curDisplayResponses.Count; i++) {
                        //Exception for if there is 2 responses is hardcoded
                        if (curDisplayResponses.Count != 2) {
                            if (i == curDisplayResponses.Count - 1) {
                                customNav.selectOnUp = curDisplayResponses[i].GetComponent<Selectable>();
                            }
                            else if (i == 1) {
                                customNav.selectOnDown = curDisplayResponses[i].GetComponent<Selectable>();
                            }
                        }
                        else if(curDisplayResponses.Count == 2) {
                            customNav.selectOnUp = curDisplayResponses[1].GetComponent<Selectable>();
                            customNav.selectOnDown = curDisplayResponses[1].GetComponent<Selectable>();
                        }
                    
				}
				child.GetComponent<Button>().navigation = customNav;


				break;
			case Response.NavPosition.BOTTOM:
				for (int i = 0; i < curDisplayResponses.Count; i++) {
                        if (curDisplayResponses.Count != 2) {
                            if (i == 0) {
                                customNav.selectOnDown = curDisplayResponses[i].GetComponent<Selectable>();
                            }
                            else if (i == curDisplayResponses.Count - 2) {
                                customNav.selectOnUp = curDisplayResponses[i].GetComponent<Selectable>();
                            }
                        }
                        else if(curDisplayResponses.Count == 2) {
                            customNav.selectOnUp = curDisplayResponses[0].GetComponent<Selectable>();
                            customNav.selectOnDown = curDisplayResponses[0].GetComponent<Selectable>();
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
