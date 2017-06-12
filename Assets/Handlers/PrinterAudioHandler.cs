using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterAudioHandler : MonoBehaviour {
    public AudioClip clip;
	public void InvokePrinterSound() {
        Debug.Log("sup?");
        AudioManager.Instance.PlaySoundAtPoint(clip, gameObject,Random.Range(0.8f, 1.2f), .2f, 0, false, true);
    }
}
