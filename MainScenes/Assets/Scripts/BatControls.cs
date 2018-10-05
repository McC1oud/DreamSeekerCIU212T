using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControls : MonoBehaviour
{
    public float batRotation;

	// Use this for initialization
	void Start ()
	{
	    batRotation = this.transform.rotation.y;

	}
	
	// Update is called once per frame
	void Update ()
    {
        //var x = Input.GetAxis("Horizontal") * Time.deltaTime + 150.0f;
        //var z = Input.GetAxis("Veritcal") * Time.deltaTime * 3.0f;
         Rigidbody rb = GetComponent<Rigidbody>();
        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);
        if (Input.GetKey(KeyCode.D))
        {
            //  batRotation += .01f;
            rb.AddForce(Vector3.left);

        }
        if (Input.GetKey(KeyCode.A))
        {
            // batRotation -= .01f;
            rb.AddForce(Vector3.right);
        }

        //this.transform.rotation = new Quaternion(transform.rotation.x, batRotation, transform.rotation.z, Quaternion.identity.w);

    }
}
