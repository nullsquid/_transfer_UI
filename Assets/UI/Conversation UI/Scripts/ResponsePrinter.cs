using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//TODO Fix Silk integration
using Silk;
public class ResponsePrinter : MonoBehaviour {

    List<GameObject> curDisplayResponses = new List<GameObject>();
    public GameObject responsePrefab;
    public GameObject dialogueEventHandler;
    public TextPrinter printer;


	public delegate void CaptureDialogueChoice(string responseText);
	public event CaptureDialogueChoice onButtonSubmit;
    private void OnEnable() {
        printer.onPrintComplete += UpdateResponses;
    }
    private void OnDisable() {
        printer.onPrintComplete -= UpdateResponses;
    }
    //TODO make this into an event that can be populated from Silk
    public void UpdateResponses(){
        ClearResponseUI();
		PopulateResponseUI();
	}
    void ClearResponseUI() {
		curDisplayResponses.Clear ();
        foreach(Transform child in this.transform) {
            Destroy(child.gameObject);
        }
    }
	void PopulateResponseUI(){
        
        //SilkNode node = Silky.Instance.mother.GetNodeByName("TRANSUBSTANCE", "Start");
		SilkNode node = DialogueManager.Instance.CurNode;
		for (int i = 0; i < node.silkLinks.Count; i++) {

            GameObject newresponse = Instantiate(responsePrefab);
            Button b = newresponse.GetComponent<Button>();
            ////////////////////////////////////////////////////////////////
            //this script must be attached to the parent of all responses///
            ////////////////////////////////////////////////////////////////
            newresponse.transform.SetParent(this.gameObject.transform);
            newresponse.transform.localScale = new Vector3(1, 1, 1);
            b.onClick.AddListener(() => OnButtonClick(newresponse.GetComponent<Response>()));
            curDisplayResponses.Add(newresponse);
            newresponse.transform.localPosition = new Vector3(newresponse.transform.position.x, newresponse.transform.position.y, 0);
            newresponse.GetComponent<Response>().responseText = node.silkLinks[i].LinkText;
            if (i == 0) {
                newresponse.GetComponent<Selectable>().Select();
                newresponse.GetComponent<Response>().navPos = Response.NavPosition.TOP;

            }
            else if (i == node.silkLinks.Count - 1) {

                newresponse.GetComponent<Response>().navPos = Response.NavPosition.BOTTOM;

            }
            else {
                newresponse.GetComponent<Response>().navPos = Response.NavPosition.MIDDLE;
            }

        }
        this.gameObject.GetComponent<ResponseNavHandler>().SetCustomNavigation(curDisplayResponses);


    }

    void OnButtonClick(Response response) {
        //Debug.Log(response.responseText);
		onButtonSubmit (response.responseText);
    }





}
