using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [Header("Set in Inspector")]
    public static GameObject powerup;
    public AudioClip powerSoundClip;
    
    
    private Rigidbody projectileRigidbody;
    private Transform projectileTrans;
    private AudioSource audioSource;
    private GameObject mainCam;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            projectileRigidbody = other.GetComponent<Rigidbody>();
            projectileRigidbody.mass = 50;

            projectileTrans = other.GetComponent<Transform>();
            projectileTrans.localScale = new Vector3(1.5f,1.5f,1.5f);

            audioSource.clip = powerSoundClip;
            audioSource.Play();

            powerup.SetActive(false);
        }
    }

    void Awake()
    {
        powerup = GameObject.Find("Powerup");
        mainCam = GameObject.Find("_Main Camera");
        audioSource = mainCam.GetComponent<AudioSource>();
    }
}
