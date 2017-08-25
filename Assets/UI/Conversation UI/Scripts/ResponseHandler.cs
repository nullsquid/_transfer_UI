using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ResponseHandler : MonoBehaviour {
	public UnityEvent OnResponseListUpdate;
	public UnityEvent OnResponseListDisable;
	public UnityEvent OnResponseListEnable;

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			OnResponseListUpdate.Invoke ();
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			OnResponseListDisable.Invoke();
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			OnResponseListEnable.Invoke ();
		}
	}


}
