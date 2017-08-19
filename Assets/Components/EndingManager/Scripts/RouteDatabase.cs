using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteDatabase : MonoBehaviour {
	private int timesCompleted;
	private int timesStarted;

	private Dictionary<string,string> beginnings = new Dictionary<string, string>();
	private Dictionary<string, string> endings = new Dictionary<string, string> ();

	private string curStoryName;
	private string curNodeName;

	private string startedKey = "TimesStarted";
	// Use this for initialization
	void Start () {
		timesStarted = PlayerPrefs.GetInt(startedKey);
		PlayerPrefs.SetInt (startedKey, timesStarted += 1);
		Debug.LogWarning(PlayerPrefs.GetInt(startedKey));
	}

	public void AddBeginning(string key, string value){
		beginnings.Add (key, value);
	}

	public void CacheCurPosition(){

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			Debug.LogWarning ("CLEARING PLAYER DATA");
			PlayerPrefs.DeleteAll ();
		}
	}
}
