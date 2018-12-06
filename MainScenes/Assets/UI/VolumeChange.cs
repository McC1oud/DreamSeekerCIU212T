using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    // Add volume controls here

    private float volumebar;

    //[SerializeField]
    //private float fillAmount;

    [SerializeField]
    private Image volume;

    // Use this for initialization
    void Start ()
    {
        volumebar = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {

        volumebar = Mathf.Clamp(volumebar, 0, 0.9f);
        volume.fillAmount = volumebar;

    }

    public void DecreaseVolume()
    {
        volumebar -= 0.1f;
    }

    public void IncreaseVolume()
    {
        volumebar += 0.1f;
    }

    private void HandleBar()
    {
        volume.fillAmount = volumebar;
    }

}
