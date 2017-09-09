using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Transfer.Input;
using UnityEngine.UI;
public class EffectsManager : MonoBehaviour {
	public Font shiftFont;
	public Font mainFont;
	string shiftTextBase = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb" +
	                       "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb" +
	                       "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb" +
	                       "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb" +
	                       "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb" +
	                       "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb" +
	                       "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb" +
	                       "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb" +
	                       "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb" +
	                       "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
	                    
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

	public Text mainText;
	public Camera mainCamera;
	public Terminal terminal;
	public TextPrinter printer;


	void Start(){
		mainCamera = Camera.main;
		terminal = GameObject.FindObjectOfType<Terminal> ();
		printer = GameObject.FindObjectOfType<TextPrinter> ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			//SurgeEffect ();
		}
	}
	public void ShiftEffect(){
		StartCoroutine (ShiftRoutine (15f, 6.0f));
	}
	public void SurgeEffect(){
		StartCoroutine(SurgeRoutine (5.0f));
	}

	IEnumerator ShiftRoutine(float shiftValue, float shiftTime){
		mainText.text = shiftTextBase;
		mainText.font = shiftFont;
		float bleed = mainCamera.GetComponent<postVHSPro> ().bleedAmount;
		terminal.GetComponentInChildren<MainInputController> ().CanRecordInput = false;
		terminal.ChangeState (new ConnectState ());
		printer.InvokeShiftText ();
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / shiftTime) {
			bleed = Mathf.Lerp (bleed, shiftValue, t);
			mainCamera.GetComponent<postVHSPro> ().bleedAmount = bleed;
			if (bleed >= 7.5f) {
				bleed = 0f;
			}
			yield return null;
		}
		mainText.font = mainFont;
		mainCamera.GetComponent<postVHSPro> ().bleedAmount = 0.0f;
		terminal.ChangeState (new IdleState ());
		terminal.GetComponentInChildren<MainInputController> ().CanRecordInput = true;



	}

	IEnumerator SurgeRoutine(float time){
		
		terminal.ChangeState (new ConnectState ());
		mainCamera.GetComponent<CameraGlitch> ().enabled = true;
		printer.InvokeSurgeText ();
		terminal.GetComponentInChildren<MainInputController> ().CanRecordInput = false;
		yield return new WaitForSeconds (time);
		terminal.GetComponentInChildren<MainInputController> ().CanRecordInput = true;
		mainCamera.GetComponent<CameraGlitch> ().enabled = false;

		terminal.ChangeState (new IdleState ());
	}


}
