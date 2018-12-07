using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkenUiButton : MonoBehaviour {

    public Image TigerM;
    public Image DragonM;
    public Image SakuraM;
    public Image OptionM;

    // Use this for initialization
    void Start ()
    {
  
       
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DarkenButton()
    {
        var tempColor = TigerM.color;
        tempColor.g = 0.5f;
        tempColor.r = 0.5f;
        tempColor.b = 0.5f;
        TigerM.color = tempColor;

        var tempD = DragonM.color;
        tempD.g = 1;
        tempD.r = 1;
        tempD.b = 1;
        DragonM.color = tempD;

        var tempS = SakuraM.color;
        tempS.g = 1;
        tempS.r = 1;
        tempS.b = 1;
        SakuraM.color = tempS;
    }

    public void DarkenButtonD()
    {
        var tempColor = TigerM.color;
        tempColor.g = 1f;
        tempColor.r = 1f;
        tempColor.b = 1f;
        TigerM.color = tempColor;

        var tempD = DragonM.color;
        tempD.g = 0.5f;
        tempD.r = 0.5f;
        tempD.b = 0.5f;
        DragonM.color = tempD;

        var tempS = SakuraM.color;
        tempS.g = 1;
        tempS.r = 1;
        tempS.b = 1;
        SakuraM.color = tempS;
    }

    public void DarkenButtonS()
    {
        var tempColor = TigerM.color;
        tempColor.g = 1f;
        tempColor.r = 1f;
        tempColor.b = 1f;
        TigerM.color = tempColor;

        var tempD = DragonM.color;
        tempD.g = 1f;
        tempD.r = 1f;
        tempD.b = 1f;
        DragonM.color = tempD;

        var tempS = SakuraM.color;
        tempS.g = 0.5f;
        tempS.r = 0.5f;
        tempS.b = 0.5f;
        SakuraM.color = tempS;
    }

    public void DarkenButtonO()
    {
        var tempColor = TigerM.color;
        tempColor.g = 1f;
        tempColor.r = 1f;
        tempColor.b = 1f;
        TigerM.color = tempColor;

        var tempD = DragonM.color;
        tempD.g = 1f;
        tempD.r = 1f;
        tempD.b = 1f;
        DragonM.color = tempD;

        var tempS = SakuraM.color;
        tempS.g = 1f;
        tempS.r = 1f;
        tempS.b = 1f;
        SakuraM.color = tempS;
    }


}
