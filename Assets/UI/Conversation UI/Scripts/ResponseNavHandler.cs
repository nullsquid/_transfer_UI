using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResponseNavHandler : MonoBehaviour {
	Navigation normalNav = new Navigation();
	Navigation customNav = new Navigation();

	public void SetCustomNavigation(List<GameObject> curDisplayResponses){
		normalNav.mode = Navigation.Mode.Vertical;
		customNav.mode = Navigation.Mode.Explicit;

		foreach (Transform child in transform) {
			switch (child.GetComponent<Response> ().navPos) {

			case Response.NavPosition.TOP:

				for (int i = 0; i < curDisplayResponses.Count; i++) {
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
