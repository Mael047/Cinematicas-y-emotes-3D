using UnityEngine;
using UnityEngine.Playables;


public class Cinematica : MonoBehaviour
{
    public PlayableDirector Cine;
    public float DuracionCinematica;
    float t;

    public GameObject CineObject;
    public GameObject GamePlayObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DuracionCinematica = (float)Cine.duration;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t >= DuracionCinematica)
        {
            CineObject.SetActive(false);
            GamePlayObject.SetActive(true);
            Destroy(this);
        }
    }
}
