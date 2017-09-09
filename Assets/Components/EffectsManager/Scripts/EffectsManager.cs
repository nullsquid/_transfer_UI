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
		StartCoroutine (ShiftRoutine (15f, 2.0f));
		//mainCamera.GetComponent<postVHSPro> ().bleedAmount = 15f;
		//bleed = 15f;
	}

	IEnumerator ShiftRoutine(float shiftValue, float shiftTime){
		float bleed = mainCamera.GetComponent<postVHSPro> ().bleedAmount;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / shiftTime) {
			bleed = Mathf.Lerp (bleed, shiftValue, t);
			mainCamera.GetComponent<postVHSPro> ().bleedAmount = bleed;
			if (bleed >= 7.5f) {
				bleed = 0f;
			}
			yield return null;
		}
		mainCamera.GetComponent<postVHSPro> ().bleedAmount = 0.0f;



		//yield return null;
	}
}
