using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text keyCountText;

	void Start()
	{
		UIPopupTextController.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
        setKeyCountToUI();
	}
    
    void setKeyCountToUI()
    {
        int keycount = Assets.Code.Actors.Player.Inventory.GetKeyCount();
        if (keycount != 0)
            keyCountText.text = keycount.ToString();
        else
            keyCountText.text = "0";
    }
}
