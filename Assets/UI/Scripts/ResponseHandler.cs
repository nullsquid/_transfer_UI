using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ResponseHandler : MonoBehaviour {
	public UnityEvent OnResponseListChanged;
	public UnityEvent OnDownKeyPressed;
	public UnityEvent OnUpKeyPressed;
	void OnEnable(){

	}

	void OnDisable(){

	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			OnResponseListChanged.Invoke ();
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			OnDownKeyPressed.Invoke();
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			OnUpKeyPressed.Invoke ();
		}
			
	}


}
