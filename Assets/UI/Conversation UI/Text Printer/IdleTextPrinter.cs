using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IdleTextPrinter : MonoBehaviour {
    public Text idleText;
    public void InvokeIdlePrint(string text) {
        IterateThroughIdleCharacters(text, 0.02f);
    }

    public IEnumerator IterateThroughIdleCharacters(string text, float time) {
        idleText.text = "";
        for (int i = 0; i < text.Length; i++) {
            idleText.text += text[i];
            yield return new WaitForSeconds(time);
        }
        yield return new WaitForSeconds(2.5f);
        idleText.text = "";
    }
}
