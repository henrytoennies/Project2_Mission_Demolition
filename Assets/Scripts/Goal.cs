using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool goalMet = false;

    [Header("Set in Inspector")]
    public AudioClip goalSoundClip;

    private AudioSource audioSource;
    private GameObject mainCam;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Goal.goalMet = true;
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;

            audioSource.clip = goalSoundClip;
            audioSource.Play();
        }
    }

    void Start()
    {
        mainCam = GameObject.Find("_Main Camera");
        audioSource = mainCam.GetComponent<AudioSource>();
    }
}
