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

    public Sprite topImage;
    public Sprite midImage;
    public Sprite botImage;


	public delegate void CaptureDialogueChoice(string responseText);
	public event CaptureDialogueChoice onButtonSubmit;
    private void OnEnable() {
        printer.onPrintComplete += UpdateResponses;
        StartCoroutine(WaitForAwake());
    }
    private void OnDisable() {
        printer.onPrintComplete -= UpdateResponses;
        if (this.enabled) {
            DialogueManager.instance.nodeCleanup -= ClearResponseUI;
        }

    }
    //TODO make this into an event that can be populated from Silk
    public void UpdateResponses(){
        ClearResponseUI();
		PopulateResponseUI();
	}
    public void ClearResponseUI() {
		curDisplayResponses.Clear ();
        foreach(Transform child in this.transform) {
            Destroy(child.gameObject);
        }
    }
	void PopulateResponseUI(){
        //Debug.Log("gogogogo");
        //SilkNode node = Silky.Instance.mother.GetNodeByName("TRANSUBSTANCE", "Start");
		SilkNode node = DialogueManager.instance.CurNode;
        //Debug.Log(node.silkLinks.Count);
		for (int i = 0; i < node.silkLinks.Count; i++) {
            

            GameObject newresponse = Instantiate(responsePrefab);
            Button b = newresponse.GetComponent<Button>();
            if(i == 0) {
                newresponse.GetComponent<Image>().sprite = topImage;
            }
            else if(i == node.silkLinks.Count - 1) {
                newresponse.GetComponent<Image>().sprite = botImage;
            }
            else {
                newresponse.GetComponent<Image>().sprite = midImage;
            }
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
        Debug.Log("TEST!! " + GameObject.FindObjectOfType<MainInputDisplay>().CurText);
        //if (GameObject.FindObjectOfType<MainInputHandler>().RawText.Trim() == "") {
            
            onButtonSubmit(response.responseText);
        //}
    }

    //HAVE TO HAVE A LOADING SCREEN TO SEQUENCE OUT THIS WHOLE SETUP
    IEnumerator WaitForAwake() {
        yield return new WaitForEndOfFrame();
        DialogueManager.instance.nodeCleanup += ClearResponseUI;
    }





}
