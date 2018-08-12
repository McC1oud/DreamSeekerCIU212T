
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;   //  { get; private set; }

    public int maxEnergy = 100;
    public int currentEnergy; // { get; private set; }

    public Stat damage;
    public Stat defense;

    void Awake()
    {
        currentHealth = maxHealth;
        currentEnergy = 0;
    }

    void Update()
    {
        //Set min health and max
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        //Set min energy and max
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
       
        //Test that dealing damage is working
        //Deals damage to all units with the character stats script including children
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Need fix to take damage based on characters strength
            TakeDamage(10);
        }
    }

    
    // Call  method for taking damage
    // Change to public virtual so that 
    public void TakeDamage (int damage)
    {
        // Damage reduction based on defense
        damage -= defense.GetValue();
        // Set minimum damage to 0 to avoid healing from defense being higher than damage
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // virtual allows it to be overridden
    public virtual void Die ()
    {
        Debug.Log(transform.name + " died.");
        // Add Delay to reload the game
        
        print("Reloading Scene");
        new WaitForSeconds(2);

        PlayerManager.instance.KillPlayer();
    }
    

}
