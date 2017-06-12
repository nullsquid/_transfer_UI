using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterAudioHandler : MonoBehaviour {
    public AudioClip clip;
	public void InvokePrinterSound() {
        Debug.Log("sup?");
        AudioManager.Instance.PlaySoundAtPoint(clip, gameObject,Random.Range(0.95f, 1.05f), .1f, 0, false, true);
    }
}
