using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;
    public PlayerMovement movement;

    void Start()
    {
     
    }

    void Update()
    {
        if(Input.GetButtonDown ("Interact") && currentInterObj)
        {
            //Check to see if object can be stored in inventory
            if (currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);
                currentInterObj = null;
            }

            //Check to see if object can be opened
            if (currentInterObjScript.openable)
            {
                //Check to see if the object is locked
                if (currentInterObjScript.locked)
                {
                    //Check to see if we have the item required
                    //Search our inventory for the item. If found, unlock object
                    if (inventory.coinCount >= currentInterObjScript.coinsNeeded)
                    {
                        //We found the item needed
                        currentInterObjScript.locked = false;
                        Debug.Log(currentInterObj.name + " was unlocked");
                        inventory.coinCount = inventory.coinCount - currentInterObjScript.coinsNeeded;
                        inventory.coinCounter.text = "x " + inventory.coinCount.ToString();
                    }
                    else
                    {
                        Debug.Log(currentInterObj.name + " was NOT unlocked");
                    }
                }
                else
                {
                    //Open the object if it wasn't locked
                    Debug.Log(currentInterObj.name + " is unlocked");
                    currentInterObjScript.SendMessage("DoInteraction");
                }
            }
            //Check to see if this object can talk and has a message
            if (currentInterObjScript.canTalk)
            {
                //Tell the object to give its message
                currentInterObjScript.Talk();
            }
        }
        //Use a potion
        if (Input.GetButtonDown("Use Potion"))
        {
            //Check the inventory for potion
            GameObject potion = inventory.FindItemByType("Speed Potion");
            if (potion != null)
            { 

                //Use the potion & apply effect
                movement.playerSpeed += 4;
               
                //Remove potion from inventory
                inventory.RemoveItem(potion);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
            
        }
    }
}
