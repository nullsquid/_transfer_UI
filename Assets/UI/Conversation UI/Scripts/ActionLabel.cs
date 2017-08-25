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
        //gameObject.GetComponent<Image>().color = Color.white;
	}
    private void Update() {
        if(gameObject.GetComponent<Image>().color != Color.white) {
            Debug.Log("topo");
            gameObject.GetComponent<Image>().color = Color.white;

        }
    }


}
