using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterAudioHandler : MonoBehaviour {
    public AudioClip clip;
    public List<AudioClip> speakingClips;
    void Start() {
        speakingClips = new List<AudioClip>();
    }
	public void InvokePrinterSound() {
        Debug.Log("sup?");
        AudioManager.Instance.PlaySoundAtPoint(clip, gameObject, 1 , Random.Range(.1f, .13f), 0, false, false);
    }
}
