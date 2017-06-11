using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighlightsScaler : MonoBehaviour {
    public RectTransform curSelection;
    public RectTransform container;
	// Use this for initialization
	void Start () {
        container = GameObject.Find("Response_Pannel").GetComponent<RectTransform>();
        this.transform.localScale = new Vector3(1, 1, 1);
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(container.rect.width, this.GetComponent<RectTransform>().rect.height + 2);
        //works
        //this.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().rect.width + 1000f, this.GetComponent<RectTransform>().rect.height + 2f);
	}
	
}
