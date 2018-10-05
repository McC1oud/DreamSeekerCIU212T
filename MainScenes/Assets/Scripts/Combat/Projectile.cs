using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }

    Vector3 spawnPosition;
    GameObject player;
    public Rigidbody rb;

    void Start()
    {
        Damage = 10;
        Range = 20f;
        spawnPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().AddForce(Direction * 50f);
        player = GameObject.Find("RotationContainer");

    }

    void Update()
    {
        if (Vector3.Distance(spawnPosition, transform.position) >= Range)
        {
            Dissipate();
        }

        rb.AddForce(player.transform.forward * 100);

    }

    void Dissipate()
    {

        // add sounds effects or animation
        Destroy(gameObject);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "enemy")
        {
            print("DamageDealt");
            collision.transform.GetComponent<CharacterStats>().TakeDamage(Damage);
            Dissipate();
        }
        
    }



}
