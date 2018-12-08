using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoStreamer : MonoBehaviour {
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
	void Start () { 
        StartCoroutine(PlayVideo());
	}
    
    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        while(!videoPlayer.isPrepared)
        {
            yield return new WaitForSeconds(1);
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
    }
}
