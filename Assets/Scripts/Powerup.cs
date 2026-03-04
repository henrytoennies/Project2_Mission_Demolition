using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [Header("Set in Inspector")]
    public static GameObject powerup;
    
    
    private Rigidbody projectileRigidbody;
    private Transform projectileTrans;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            projectileRigidbody = other.GetComponent<Rigidbody>();
            projectileRigidbody.mass = 50;

            projectileTrans = other.GetComponent<Transform>();
            projectileTrans.localScale = new Vector3(1.5f,1.5f,1.5f);

            powerup.SetActive(false);
        }
    }

    void Start()
    {
        powerup = GameObject.Find("Powerup");
    }
}
