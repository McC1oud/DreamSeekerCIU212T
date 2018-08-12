using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerTrack : MonoBehaviour {

    public float cameraHeight = 4.5f;

    public float cameraEaseDistance;

    public float cameraNearDistance;


    public GameObject target;

    public float smoothTime;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.LookAt(target.transform);
        Vector3 aV = transform.position;
        Vector3 bV = target.transform.position * cameraEaseDistance;


        if (Vector3.Distance(transform.position, target.transform.position) > cameraEaseDistance)
        {     
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, smoothTime);
            Vector3 defHeight = transform.position;
            defHeight.y = cameraHeight;
            transform.position = defHeight;
        }

    }
}
