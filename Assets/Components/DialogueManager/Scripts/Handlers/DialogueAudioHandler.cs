using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAudioHandler : MonoBehaviour {
	public float volume = 1;
	public List<AudioClip> soundEffectRaw = new List<AudioClip> ();
	public Dictionary<string, AudioClip> soundEffects = new Dictionary<string, AudioClip> ();
	// Use this for initialization
	void Start () {
		for (int i = 0; i < soundEffectRaw.Count; i++) {
			soundEffects.Add (soundEffectRaw [i].name, soundEffectRaw [i]);
		}
	}
	public void InvokeSoundEffect(string soundName, float vol = 1){
		AudioManager.Instance.PlaySoundAtPoint (soundEffects [soundName], gameObject, 1, volume);
	}
	

}
