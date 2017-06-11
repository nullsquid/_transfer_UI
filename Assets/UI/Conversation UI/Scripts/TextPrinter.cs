using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextPrinter : MonoBehaviour {
    public Text typewriterText;
    private void Start() {
        
        //typewriterText = this.gameObject.GetComponentInChildren<Text>().text;
        StartCoroutine(IterateThroughCharactersToPrint("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus sed mauris ut arcu luctus volutpat. Vivamus commodo, enim vitae egestas auctor, dui ex rhoncus felis, nec lacinia ipsum magna vel ligula. Sed ex elit, elementum non ex ac, placerat bibendum orci. Nam consequat ipsum venenatis est posuere aliquet. Duis dignissim accumsan turpis. Nulla scelerisque egestas tortor ultrices dapibus. Duis maximus rutrum ligula, molestie cursus quam. Vestibulum sollicitudin leo malesuada faucibus suscipit. Donec ac euismod felis, at efficitur ex. Cras facilisis bibendum pulvinar. Cras lacus lacus, pharetra nec accumsan eget, cursus in quam. Nunc suscipit leo et ornare pulvinar. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.", .02f, .5f));
    }
    public IEnumerator IterateThroughCharactersToPrint(string text, /*int lineLength, int chunkLength,*/ float time, float punctTime) {
        float normalTime = time;
        if (text != null) {
            for (int i = 0; i < text.Length; i++) {
                if (text[i] == '.') {
                    time += punctTime / Random.Range(1, 1.5f);
                }
                else if (text[i] == ',') {
                    time += punctTime / Random.Range(2.5f, 4f);
                }
                else {
                    time = normalTime;
                }

                if (i > 0 && text[i - 1] == ' ') {
                    /*
                    wordsInLine++;

                    if (wordsInLine >= lineLength) {
                        linesInChunk++;
                        typewriterText += "\n";
                        typewriterText.Remove(i - 1, 1);
                        wordsInLine = 0;

                        if (linesInChunk >= chunkLength) {
                            //event to call the next chunk
                            break;
                        }
                    }
                    */
                }

                typewriterText.text += text[i];
                yield return new WaitForSeconds(time);

            }
        }
    }

}
