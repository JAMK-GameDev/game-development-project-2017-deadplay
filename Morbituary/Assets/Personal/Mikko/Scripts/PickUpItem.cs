using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour {
    public Item item;
    private Inventory inventory;
	void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        inventory.AddItem(item);
    }


    protected void SpecificInit() //delayed reaction.cs original
    {
        //inventory = FindObjectOfType<Inventory>();
    }


    protected void ImmediateReaction()//delayed reaction.cs original
    {
        //inventory.AddItem(item);
    }
}






