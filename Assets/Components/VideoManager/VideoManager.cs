using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class VideoManager : MonoBehaviour {

    //public MovieTexture mTexture;
    public List<VideoClip> videos = new List<VideoClip>();
    public GameObject videoPannel;
    public Terminal terminal;

    public Dictionary<string, VideoClip> videoWithNames = new Dictionary<string,VideoClip>();

    private void OnEnable() {
        if (videoPannel != null) {
            videoPannel.GetComponentInChildren<StreamVideo>().onVideoComplete += VideoCleanup;
        }
    }

    private void OnDisable() {
        if (videoPannel != null) {
            videoPannel.GetComponentInChildren<StreamVideo>().onVideoComplete -= VideoCleanup;
        }
    }

    private void Start() {
        for(int i = 0; i < videos.Count; i++) {
            videoWithNames.Add(videos[i].name, videos[i]);
        }
    }


    public void PlayVideo(string videoName) {
        if (videoWithNames.ContainsKey(videoName)) {
            terminal.ChangeState(new VideoState());
            videoPannel.GetComponentInChildren<StreamVideo>().videoToPlay = videoWithNames[videoName];
            videoPannel.GetComponentInChildren<StreamVideo>().StartVideo();
            //Invoke("VideoCleanup", (float)videoWithNames[videoName].length);

        }
        else {
        }
    }
    public void PlayVideoMemory(string videoName) {
        if (videoWithNames.ContainsKey(videoName)) {
            terminal.ChangeState(new VideoState());
            videoPannel.GetComponentInChildren<StreamVideo>().videoToPlay = videoWithNames[videoName];
            videoPannel.GetComponentInChildren<StreamVideo>().StartVideoMemory();
            //Invoke("VideoCleanup", (float)videoWithNames[videoName].length);

        }
        else {
        }
    }

    public void VideoCleanup() {
        if (videoPannel.GetComponentInChildren<StreamVideo>().curVideoIsPlaying == false) {
            terminal.GetPrevState();
            videoPannel.SetActive(false);
            terminal.mainText.SetActive(true);
            GameObject.FindObjectOfType<ResponsePrinter>().UpdateResponses();
            videoPannel.GetComponentInChildren<StreamVideo>().videoToPlay = null;
        }
    }
}
