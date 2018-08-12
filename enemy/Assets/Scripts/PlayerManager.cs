using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    #region Singleton

    public static PlayerManager instance;
    public float delayTimer;

    void Awake ()
    {
        instance = this;
        delayTimer = 2f;
    }

    #endregion

    public GameObject player;

    public void KillPlayer ()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Reloaded");

    }
}
