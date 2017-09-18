using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MemoryTextPrinter : MonoBehaviour {
    public Text memText;


    public void InvokeMemoryPrint(string text, float time) {
        StartCoroutine(PrintMemory(text, time));
    }

    IEnumerator PrintMemory(string text, float waitTime) {
        memText.text = "";
        text += "\n>>\n>>\n>>'EXIT'";
        for(int i = 0; i < text.Length; i++) {
            memText.text += text[i];
            yield return new WaitForSeconds(waitTime);
        }

    }
	
}
