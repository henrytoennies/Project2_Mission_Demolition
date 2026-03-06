using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RubberSlingshot : MonoBehaviour
{
    [Header("Set In Inspector")]
    public LineRenderer line;
    public Transform firstPoint;
    public Transform secondPoint;
    public Transform launchPointTrans;

    private Vector3 launchPos;

    // Start is called before the first frame update
    void Start()
    {
        line.SetPosition(0, firstPoint.position);
        line.SetPosition(2, secondPoint.position);

        launchPos = launchPointTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the current mouse position in 2D screen coordinates
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //find the delta from the launchPos to the mousePos3D
        Vector3 mouseDelta = mousePos3D - launchPos;

        //limit mouseDelta to the radius of the Slingshot collider
        float maxMagnitude = 3.0f;

        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        //Move the projectile to this new position
        Vector3 projPos = launchPos + mouseDelta;
        line.SetPosition(1, projPos);
    }
}
