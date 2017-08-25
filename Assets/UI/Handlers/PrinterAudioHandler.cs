using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterAudioHandler : MonoBehaviour {
    public AudioClip clip;
    public List<AudioClip> speakingClips;
    public float speakingClipVolume = 1;
    void Start() {
        speakingClips = new List<AudioClip>();
    }
	public void InvokePrinterSound() {
        AudioManager.Instance.PlaySoundAtPoint(clip, gameObject, 1 , speakingClipVolume, 0, false, false);
    }
}
