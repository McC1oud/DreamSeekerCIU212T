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
    CharacterStats myStats;

    void Start()
    {
        myStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        Damage = Mathf.RoundToInt(myStats.damage.GetValue()*1.6f);
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
            collision.transform.GetComponent<CharacterStats>().TakeDamage(Mathf.RoundToInt(myStats.damage.GetValue() * 1.2f), CritChance());
            Dissipate();
        }
        
    }

    bool CritChance()
    {
        // Chance of critting hard coded to 50%
        // create formula to increase critcal chance based on stats
        int criticalchance = Random.Range(0, 100);
        if (criticalchance < 50)
            return true;
        // else
        return false;
    }

}
