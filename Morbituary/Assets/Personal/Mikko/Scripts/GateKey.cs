using Assets.Code.Actors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateKey : MonoBehaviour {


	void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player" && Player.Inventory.UseKey())
        {
            UIPopupTextController.CreatePopupText("Used a key, and opened the gate", transform);
            Destroy(gameObject);
        }

        if (collider.gameObject.name == "Player" && !Player.Inventory.UseKey())
        {
            UIPopupTextController.CreatePopupText("You need a key to open a gate", transform);
        }
    }
}
