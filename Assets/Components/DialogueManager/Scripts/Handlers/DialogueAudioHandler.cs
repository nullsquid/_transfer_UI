using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAudioHandler : MonoBehaviour {
	public float volume = 1;
	public List<AudioClip> soundEffectRaw = new List<AudioClip> ();
	public Dictionary<string, AudioClip> soundEffects = new Dictionary<string, AudioClip> ();
    Terminal terminal;
    // Use this for initialization
	void Start () {
        terminal = GameObject.FindObjectOfType<Terminal>();
		for (int i = 0; i < soundEffectRaw.Count; i++) {
			soundEffects.Add (soundEffectRaw [i].name, soundEffectRaw [i]);
		}
	}

    private void OnEnable() {
        //AudioManager.Instance.audioClipComplete += AudioCleanup;
    }

    private void OnDisable() {
        //AudioManager.Instance.audioClipComplete -= AudioCleanup;
    }

    public void InvokeSoundEffect(string soundName, float vol = 1){
		AudioManager.Instance.PlaySoundAtPoint (soundEffects [soundName], gameObject, 1, volume);
	}

    public void InvokeAudioLog(string soundName) {
        //GameObject.FindObjectOfType<Terminal>().ChangeState(new AudioClipState());
        terminal.responsePannel.SetActive(false);
        AudioManager.Instance.PlayAudioClipAtPoint(soundEffects[soundName], gameObject);
        
    }
	
    public void AudioCleanup() {
        //terminal.GetPrevState();
		Debug.Log("cleanup");
        terminal.responsePannel.SetActive(true);
        GameObject.FindObjectOfType<ResponsePrinter>().UpdateResponses();

    }
}
