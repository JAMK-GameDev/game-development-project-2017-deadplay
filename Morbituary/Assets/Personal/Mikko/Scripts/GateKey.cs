using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateKey : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        Debug.Log("fucker");
        if (collider.gameObject.name == "Player" && GameVariables.key>0)
        {
            GameVariables.key--;
            Destroy(gameObject);
      // for destroying the gate? animation? gameObject.AddComponent<Rigidbody>();
        }
    }
}
