using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingToPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject playerLocation;
    public Vector3 position;
    public Rigidbody rb;
    public bool waiting = true;
    public int Damage { get; set; }


    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "player")
        {
            print("Range Hit");
            waiting = false;
            //rb.AddForce(other.contacts[0].normal * 1000);

            //Add script to deal damage to player here
            other.transform.GetComponent<CharacterStats>().TakeDamage(Damage);

            Destroy(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject, 2f);
        }
    }


    // Use this for initialization
	void Start ()
	{
	    rb = GetComponent<Rigidbody>();
	    //player = GameObject.FindGameObjectWithTag("player");
        playerLocation = GameObject.FindGameObjectWithTag("PlayerLocation");
        transform.LookAt(playerLocation.transform);

        Damage = 5;
    }
	
	// Update is called once per frame
    void Update()
    {
        if (waiting)
        {

            rb.AddForce(transform.forward * 10);
           // transform.LookAt(player.transform);
            //position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, Time.deltaTime);
            //position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, Time.deltaTime);
            //position.z = Mathf.Lerp(this.transform.position.z, player.transform.position.z, Time.deltaTime);
            // transform.position = position;
        }
    }

    //Need to recode so that the ball doesnt target the players feet. The players pivot however is also located at the feet

  

}
