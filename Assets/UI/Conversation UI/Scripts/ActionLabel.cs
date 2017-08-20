using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionLabel : MonoBehaviour {
    Text text;
    public string actionText;
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponentInChildren<Text>();
        text.text = actionText;
	}
	
	
}
