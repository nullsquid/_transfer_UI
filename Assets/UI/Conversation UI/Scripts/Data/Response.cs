﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Response : MonoBehaviour {
    public string responseText;
    Text text;
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
        text.text = responseText;
	}
}
