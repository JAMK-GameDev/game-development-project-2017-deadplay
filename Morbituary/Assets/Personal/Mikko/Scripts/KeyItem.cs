using Assets.Code.Actors;
using Assets.Code.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            UIPopupTextController.CreatePopupText("Key picked up", transform);
            var inventory = Player.Inventory;
            inventory.AddKey();
            Destroy(gameObject);
        }
    }
}
