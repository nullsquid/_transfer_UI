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

    private Dictionary<string, VideoClip> videoWithNames = new Dictionary<string,VideoClip>();

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
        }
        else {
            Debug.LogWarning("VIDEO WITH NAME " + videoName + " NOT FOUND");
        }
    }

    public void VideoCleanup() {
        if (videoPannel.GetComponentInChildren<StreamVideo>().curVideoIsPlaying == false) {
            terminal.ChangeState(new IdleState());
            videoPannel.GetComponentInChildren<StreamVideo>().videoToPlay = null;
        }
    }
}
