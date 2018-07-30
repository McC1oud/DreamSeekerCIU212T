using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour {

    public GameObject sightTarget;
    public bool canSeePlayer = false;

    RaycastHit hit;

	
	void Start () {
        //Event subscriptions
        CheckForPlayer.detectionEnter += SetBool;
        CheckForPlayer.detectionExit += SetBool;
    }
	
	// Update is called once per frame
	void Update () {

        //Just Rotating the enemy
        transform.Rotate(0,1.5f,0);

        //RayCastchecks
        if (Physics.Raycast(transform.position, sightTarget.transform.position, out hit))
        {
            //This will cause the debug line to turn red. This represents that the player is currently within raycast sight of the enemy.
            if(hit.collider.tag == "Player")
            {
                Debug.DrawRay(transform.position, hit.point, Color.red);
            }

            //This will turn blue. This means that the player is not in line of sight, ie: Behind a wall.
            else
            {
                Debug.DrawRay(transform.position, sightTarget.transform.position, Color.blue);
            }

            //Turning green means the player is now in 'Line Of Sight' and withing the visual cone of the enemy. This is where we would activate the enemy to enter attack mode.
            if (hit.collider.tag == "Player" && canSeePlayer == true)
            {
                Debug.DrawRay(transform.position, hit.point, Color.green);
            }
        }

    }

    //This method takes the boolean parameter passed by the subscriptions.
    //This is the interface for the enemy Visual cone.
    public void SetBool(bool anu)
    {
        canSeePlayer = anu;
        print(canSeePlayer);
    }


}
