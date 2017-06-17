using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Response : MonoBehaviour {
    public string responseText;
	public bool isSelected;
	public enum NavPosition{
		TOP,
		MIDDLE,
		BOTTOM
	};
	public NavPosition navPos;
    Text text;
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponentInChildren<Text>();
        text.text = responseText;
	}
}
