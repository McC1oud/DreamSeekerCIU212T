using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBall : MonoBehaviour
{

    public GameObject prefabToSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        
	        Instantiate(prefabToSpawn,this.transform.position + new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)), Quaternion.identity);
	    }

	}
}
