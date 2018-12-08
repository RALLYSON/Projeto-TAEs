using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoStreamer : MonoBehaviour {    //streaming de video , do componente video player para a GUI canvas do usuario
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
        rawImage.texture = videoPlayer.texture; //a iamgem do GUI canvas, recebe os frames do video
        videoPlayer.Play();
    }
}
