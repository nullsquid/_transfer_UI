using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Response : MonoBehaviour {
    public string responseText;
	public bool isSelected;
    Text text;
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponentInChildren<Text>();
        text.text = responseText;
	}
}
