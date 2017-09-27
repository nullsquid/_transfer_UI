using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Silk;
public class NPCActionController : MonoBehaviour {
    //public GameObject npcActionPanel;
    Terminal terminal;

    private void Start() {
        terminal = GameObject.FindObjectOfType<Terminal>();
    }

    public void InvokeNPCAction(string text, float time) {
        StartCoroutine(ShowAction(text, time));
    }

    IEnumerator ShowAction(string actionText, float timeToWait) {
        //npcActionPanel.
        terminal.npcActionPanel.GetComponentInChildren<Text>().text = actionText;
        terminal.npcActionPanel.SetActive(true);
        terminal.npcActionPanel.GetComponent<Image>().fillAmount = 0;
        float t = 0;
        while (terminal.npcActionPanel.GetComponent<Image>().fillAmount < 1) {
            t += Time.deltaTime / (timeToWait / 2);
            terminal.npcActionPanel.GetComponent<Image>().fillAmount = Mathf.Lerp(0, 1, t);
        }
        yield return new WaitForSeconds(timeToWait);
        terminal.npcActionPanel.SetActive(false);
    }

    
	
}
