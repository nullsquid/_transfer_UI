using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ResponseHandler : MonoBehaviour {
	public UnityEvent OnResponseListChanged;
	public UnityEvent OnDownKeyPressed;
	public UnityEvent OnUpKeyPressed;
	public UnityEvent OnConfirm;


	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			OnResponseListChanged.Invoke ();
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			OnDownKeyPressed.Invoke();
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			OnUpKeyPressed.Invoke ();
		}
		else if(Input.GetKeyDown(KeyCode.Return)){
			OnConfirm.Invoke ();
		}
			
	}


}
