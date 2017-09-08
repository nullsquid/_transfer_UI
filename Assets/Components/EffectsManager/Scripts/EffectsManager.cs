using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour {
	#region Singleton
	public static EffectsManager instance;
	void Awake() {

		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}
	#endregion

	public Camera mainCamera;
	void Start(){
		mainCamera = Camera.main;
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			//ShiftEffect ();
		}
	}
	public void ShiftEffect(){
		
		mainCamera.GetComponent<postVHSPro> ().bleedAmount = 15f;
		//bleed = 15f;
	}

	IEnumerator ShiftRoutine(){
		float bleed = mainCamera.GetComponent<postVHSPro> ().bleedAmount;
		yield return null;
	}
}
