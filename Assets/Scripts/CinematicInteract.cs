using UnityEngine;

public class CinematicInteract : MonoBehaviour
{
    [Header("Cinemática a reproducir")]
    public CinematicaVideo cinematic;   // tu script de video+timeline

    [Header("Jugador")]
    public string playerTag = "Player";
    public KeyCode interactKey = KeyCode.E;

    [Header("UI")]
    public GameObject interactIcon;     // ícono "Presiona E"

    private bool playerInside = false;
    private bool used = false;          // por si sólo quieres que funcione una vez

    void Start()
    {
        // Asegurarnos de que el icono empiece apagado
        if (interactIcon != null)
        {
            interactIcon.SetActive(false);
        }
    }

    void Update()
    {
        if (!playerInside || used) return;

        if (Input.GetKeyDown(interactKey))
        {
            // Ocultamos el icono al interactuar
            if (interactIcon != null)
                interactIcon.SetActive(false);

            // Reproducir la secuencia (video + timeline + volver a gameplay)
            cinematic.PlaySequence();

            // Si solo quieres que se pueda usar una vez:
            used = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (used) return;

        if (other.CompareTag(playerTag))
        {
            playerInside = true;

            // Mostrar icono de "E"
            if (interactIcon != null)
                interactIcon.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerInside = false;

            // Ocultar icono cuando se aleja
            if (interactIcon != null)
                interactIcon.SetActive(false);
        }
    }
}
