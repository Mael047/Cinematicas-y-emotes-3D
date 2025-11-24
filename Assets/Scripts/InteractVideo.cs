using UnityEngine;
using UnityEngine.Video;

public class InteractVideo : MonoBehaviour
{
    public GameObject canvasVideo;          // Canvas para esta interacción
    public VideoPlayer videoPlayer;        // Componente VideoPlayer
    public KeyCode interactKey = KeyCode.X;

    private bool playerNearby = false;

    private void Start()
    {
        canvasVideo.SetActive(false);       // El canvas arranca apagado
    }

    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(interactKey))
        {
            PlayVideo();
        }
    }

    private void PlayVideo()
    {
        canvasVideo.SetActive(true);
        videoPlayer.Play();

        // Cuando termine, cerrar el canvas
        videoPlayer.loopPointReached += EndVideo;
    }

    private void EndVideo(VideoPlayer vp)
    {
        canvasVideo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
