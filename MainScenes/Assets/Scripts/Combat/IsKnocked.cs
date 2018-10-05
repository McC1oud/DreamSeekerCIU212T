using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsKnocked : MonoBehaviour {

    private Rigidbody enemeyRigidBody;

    private bool knock = false;
    private float knockbackDuration = .3f;
    private float knockbackTimer = 0;

    // Use this for initialization
    void Start ()
    {
        enemeyRigidBody = GetComponent<Rigidbody>();
        enemeyRigidBody.isKinematic = true;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (knock)
        {
            if (knockbackTimer > 0)
            {
                knockbackTimer -= Time.deltaTime;
            }
            else
            {
                knock = false;
                enemeyRigidBody.isKinematic = true;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "player")
        {
            Debug.Log("Knockback");
            knock = true;
            knockbackTimer = knockbackDuration;
            enemeyRigidBody.isKinematic = false;
            enemeyRigidBody.AddForce(Vector3.back * 100);
        }
    }
}
