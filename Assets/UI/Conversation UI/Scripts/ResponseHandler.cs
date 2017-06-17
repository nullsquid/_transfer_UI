using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ResponseHandler : MonoBehaviour {
	public UnityEvent OnResponseListUpdate;


	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			OnResponseListUpdate.Invoke ();
		}
	}


}
