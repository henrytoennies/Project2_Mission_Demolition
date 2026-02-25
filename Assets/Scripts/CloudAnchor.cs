using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAnchor : MonoBehaviour
{
    [Header("Set in Inspector")]
    public int numClouds = 40;
    public GameObject cloudPrefab;
    public Vector3 cloudPosMin = new Vector3(-50, -5, 10);
    public Vector3 cloudPosMax = new Vector3(150, 100, 10);
    public float cloudScaleMin = 1;
    public float cloudScaleMax = 3;
    public float cloudSpeedMult = 0.5f;

    private GameObject[] cloudInstances;

    void Awake()
    {
        //make an array large enough to hold all the cloud instances
        cloudInstances = new GameObject[numClouds];

        //find the cloudanchor parent gameobject
        GameObject anchor = GameObject.Find("CloudAnchor");

        //iterate through and make clouds
        GameObject cloud;
        
        for (int i = 0; i < numClouds; i++)
        {
            //make an instance of cloudPrefab
            cloud = Instantiate<GameObject>(cloudPrefab);
            //position cloud
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cPos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);
            //scale cloud
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);
            //smaller clouds should be nearer the ground
            cPos.y = Mathf.Lerp(cloudPosMin.y, cPos.y, scaleU);
            //smaller clouds should be further away
            cPos.z = 100 - 20 * scaleU;
            //apply these transforms to the cloud
            cloud.transform.position = cPos;
            cloud.transform. localScale = Vector3.one * scaleVal;
            //make cloud a child of the anchor
            cloud.transform.SetParent(anchor.transform);
            //add the cloud to cloudInstances
            cloudInstances[i] = cloud;
        }
    }

    void Update()
    {
        foreach (GameObject cloud in cloudInstances)
        {
            //get the cloud scale and position
            float scaleVal = cloud.transform.localScale.x;
            Vector3 cPos = cloud.transform.position;
            //move larger clouds faster
            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;
            // if a cloud has moved too far to the left
            if (cPos.x <= cloudPosMin.x)
            {
                //move it to the far right
                cPos.x = cloudPosMax.x;
            }
            //apply the new position to cloud
            cloud.transform.position = cPos;
        }
    } 
}
