using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ResponseHandler : MonoBehaviour {
	public UnityEvent OnResponseListChanged;


	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			OnResponseListChanged.Invoke ();
		}
	}


}
