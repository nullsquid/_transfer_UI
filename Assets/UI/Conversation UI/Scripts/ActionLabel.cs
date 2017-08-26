using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionLabel : MonoBehaviour {
    Text text;
    Text gText;
    public string actionText;
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponentInChildren<Text>();
        text.text = actionText;
        //gText = GameObject.Find("GlitchText").GetComponent<Text>();
        //gText.text = actionText;
        //gameObject.GetComponent<Image>().color = Color.white;
	}



}
