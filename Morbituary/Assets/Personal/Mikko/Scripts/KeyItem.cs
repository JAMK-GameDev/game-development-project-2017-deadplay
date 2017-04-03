using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            GameVariables.key += 1;
            Debug.Log(GameVariables.key);
            Destroy(gameObject);
        }
    }
}
