using UnityEngine;

public class Interactable : MonoBehaviour {

    //Heal items??
    public float radius = 3f;

    public virtual void Interact ()
    {
        // This method will be overwritten for items and enemies
        Debug.Log("Interacting with " + transform.name);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
