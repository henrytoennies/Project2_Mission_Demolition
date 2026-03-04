using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using TMPro;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;

    [Header("set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;
    public TextMeshProUGUI uitButton;

    [Header("Set Dynamically")]
    public float camZ;

    void Awake()
    {
        camZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
        Vector3 destination;
        if (POI == null)
        {
            destination = Vector3.zero;
            uitButton.text = "Show Castle";
        } else
        {
            destination = POI.transform.position;
            if (POI.tag == "Projectile")
            {
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    POI = null;
                    return;
                }
            }
        }
        
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10;
    }
}
