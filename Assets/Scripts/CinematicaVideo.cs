using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;

public class CinematicaVideo : MonoBehaviour
{
    [Header("Cine / Timeline")]
    public PlayableDirector cine;
    public GameObject cineObject;
    public GameObject gamePlayObject;

    [Header("Video opcional")]
    public bool playVideoFirst = true;
    public GameObject videoCanvas;
    public VideoPlayer videoPlayer;

    bool playingTimeline = false;

    void Start()
    {
        if (videoCanvas != null)
            videoCanvas.SetActive(false);

        if (cineObject != null)
            cineObject.SetActive(false);
    }

    // Llamar este método para iniciar toda la secuencia
    public void PlaySequence()
    {
        gamePlayObject.SetActive(false);

        if (playVideoFirst && videoPlayer != null)
        {
            // Primero el video
            videoCanvas.SetActive(true);
            videoPlayer.loopPointReached += OnVideoEnd;
            videoPlayer.Play();
        }
        else
        {
            // Directo a la cinemática
            StartTimeline();
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        videoPlayer.loopPointReached -= OnVideoEnd;
        videoCanvas.SetActive(false);
        StartTimeline();
    }

    void StartTimeline()
    {
        cineObject.SetActive(true);
        cine.time = 0;
        cine.Play();
        playingTimeline = true;
    }

    void Update()
    {
        if (!playingTimeline) return;

        if (cine.state != PlayState.Playing)
        {
            cineObject.SetActive(false);
            gamePlayObject.SetActive(true);
            playingTimeline = false;
        }
    }
}
