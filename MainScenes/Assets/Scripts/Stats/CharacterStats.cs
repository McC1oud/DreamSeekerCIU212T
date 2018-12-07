
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public GameObject player;

    public int maxHealth = 100;
    public int currentHealth;   //  { get; private set; }

    public int maxEnergy = 100;
    public int currentEnergy; // { get; private set; }

    public int damage;
    public int defense;

    public int CriticalRate;
    public float CriticalDamage;
    public float energymultiplier = 1.3f;

    public int currentExperience;
    public int maxExperience;
    public int currentLevel;
    public int skillPoints = 0;
    public GameObject DamageTprefab;

    void Awake()
    {
        currentHealth = maxHealth;
        currentEnergy = 0;
        currentLevel = 1;
        maxExperience = 20;
        currentExperience = 0;
    }

    void Update()
    {
        //Set min health and max
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        //Set min energy and max
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);


        //Test that dealing damage is working
        //Deals damage to all units with the character stats script including children
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Need fix to take damage based on characters strength
            // TakeDamage(10,CritChance());
            currentExperience += 50;
        }

        if (currentExperience >= maxExperience)
        {
            LevelUp();
        }
    }

    bool CritChance()
    {
        //chance of critting hard coded
        //need to create formula to increase critical chance based on stats
        int criticalchance = Random.Range(0, 100);
        if (criticalchance < CriticalRate)
            return true;
        //else
        return false;


    }

    public void LevelUp()
    {
        currentExperience -= maxExperience;
        currentLevel += 1;
        skillPoints += 1;
        maxExperience = currentLevel ^ 2 * currentLevel * 10 + currentLevel;
    }
    // Call  method for taking damage
    // Change to public virtual so that 

    public void TakeDamage(int damage, bool isCrit, float CriticalDamage)
    {

        // Damage reduction based on defense
        damage -= defense;
        // Set minimum damage to 0 to avoid healing from defense being higher than damage
        damage = Mathf.Clamp(damage, 0, int.MaxValue);


        print(CritChance());
        // If not critting show hit damage animation
        if (!isCrit)
        {
            // Calls the animator and applies the damage as text
            currentHealth -= damage;
            InitCBT(damage.ToString()).GetComponent<Animator>().SetTrigger("Hit");
            print("hit");

        }
        // show crit animatio
        else
        {
            // Calls the animator and applies the damage as text
            damage = (int)(damage * CriticalDamage);
            currentHealth -= damage;
            InitCBT((damage).ToString()).GetComponent<Animator>().SetTrigger("Crit");
            print("crit " + (damage));

        }

        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            player.GetComponent<PlayerController>().DeletefromList(gameObject);
            Die();
        }
    }

    //public void TakeDamage (int damage)
    //{
    //    // Damage reduction based on defense
    //    damage -= defense.GetValue();
    //    // Set minimum damage to 0 to avoid healing from defense being higher than damage
    //    damage = Mathf.Clamp(damage, 0, int.MaxValue);

    //    print("1");
    //    InitCBT(damage.ToString()).GetComponent<Animator>().SetTrigger("Hit");
    //    print("2");

    //    currentHealth -= damage;
    //    Debug.Log(transform.name + " takes " + damage + " damage.");
    //    print("3");

    //    if (currentHealth <= 0)
    //    {
    //        player.GetComponent<PlayerController>().DeletefromList(gameObject);
    //        Die();
    //    }
    //}

    // virtual allows it to be overridden
    public virtual void Die()
    {
        Debug.Log(transform.name + " died.");
        // Add Delay to reload the game

        print("Reloading Scene");
        new WaitForSeconds(2);

        PlayerManager.instance.KillPlayer();
    }

    //GameObject InitDamageT(string text)
    ////void InitDamageT(string text)
    //{
    //    GameObject temp = Instantiate(DamageTprefab) as GameObject;
    //    RectTransform tempRect = temp.GetComponent<RectTransform>();
    //    temp.transform.SetParent(transform.Find("DamageCanvas"));
    //    temp.transform.localPosition = DamageTprefab.transform.localPosition;
    //    temp.transform.localRotation = DamageTprefab.transform.localRotation;
    //    temp.transform.localScale = DamageTprefab.transform.localScale;

    //    temp.GetComponent<Text>().text = text;
    //    //temp.GetComponent<Animator>().SetTrigger("Hit");
    //    Destroy(temp.gameObject, 1);
    //    return temp;

    //}


    GameObject InitCBT(string text)
    //void InitCBT(string text)
    {
        GameObject temp = Instantiate(DamageTprefab) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(transform.Find("DamageCanvas"));
        tempRect.transform.localPosition = DamageTprefab.transform.localPosition;
        tempRect.transform.localScale = DamageTprefab.transform.localScale;
        tempRect.transform.localRotation = DamageTprefab.transform.localRotation;

        temp.GetComponent<Text>().text = text;
        //temp.GetComponent<Animator>().SetTrigger("Hit");
        Destroy(temp.gameObject, 1);

        return temp;
    }


}
