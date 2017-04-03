using Assets.Code.Actors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateKey : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        Debug.Log("fucker");


        if (collider.gameObject.name == "Player" && Player.Inventory.UseKey())
        {
            Destroy(gameObject);
        }

        /*
        if (collider.gameObject.name == "Player" && Inventory.key>0)
        {
            Inventory.key--;
            Destroy(gameObject);
      // for destroying the gate? animation? gameObject.AddComponent<Rigidbody>();
        }
        */
    }
}
