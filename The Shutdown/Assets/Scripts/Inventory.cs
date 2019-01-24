using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour {

    public PlayerMovement move;
    Vector3 pos;

    public GameObject[] inventory = new GameObject[10];

    void Start()
    {
       
    }

    public void AddItem(GameObject item)
    {

        bool itemAdded = false;

        //Find the first open slot in the inventory
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                //Update UI

                invButton[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                Debug.Log(item.name + " was added to inventory");
                itemAdded = true;
                //Do something with that object
                item.SendMessage("DoInteraction");
                break;
            }
        }

        //Inventory was full
        if (!itemAdded)
        {
            Debug.Log("Inventory was full. No item added");
        }
    }

    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                //We found the item
                return true;
            }
        }
        //Item not found
        return false;
    }

    public GameObject FindItemByType(string itemType)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] != null)
            {
                if(inventory[i].GetComponent<InteractionObject>().itemType == itemType)
                {
                    //We found an item of the type we were looking for
                    return inventory[i];
                }
            }
        }
        //Item not found
        return null;
    }

    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i] == item)
                {
                    //We found an item of the type we were looking for, remove it
                    inventory[i] = null;
                    Debug.Log(item.name + " was removed from inventory");
                    //Remove it from UI
                    invButton[i].image.overrideSprite = null;

                    break;
                }
            }
        }
    }

    void Update()
    {
    }
}
