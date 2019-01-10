using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour {

    public PlayerMovement move;
    Vector3 pos;

    public GameObject[] inventory = new GameObject[10];
    public Button[] invButton = new Button[10];
    public Text coinCounter;
    public Text plankCounter;
    public Text nailCounter;

    public int coinCount;
    public int nailCount = 0;
    public int plankCount = 0;
  

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            if (PlayerPrefs.GetString("LastScene") != "Options")
            {
                coinCount = 2;
                coinCounter.text = "x " + coinCount.ToString();
                plankCounter.text = "x " + plankCount.ToString();
                PlayerPrefs.SetString("LastScene", "MainScene");
            }
            else
            {
                coinCount = PlayerPrefs.GetInt("muntjes");
                plankCount = PlayerPrefs.GetInt("planken");
                nailCount = PlayerPrefs.GetInt("schroeven");
            }
        }
        else
        {
            coinCount = PlayerPrefs.GetInt("muntjes");
            plankCount = PlayerPrefs.GetInt("planken");
            nailCount = PlayerPrefs.GetInt("schroeven");
            if (PlayerPrefs.GetString("LastScene") == "BridgeScene")
            {
                plankCount = 0;
                nailCount = 0;
            }
            coinCounter.text = "x " + coinCount.ToString();
            plankCounter.text = "x " + plankCount.ToString();
            nailCounter.text = "x " + nailCount.ToString();
        }
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
                if (item.name == "Coin")
                {
                    inventory[0] = item;
                    coinCount++;
                    Debug.Log("Total Coins: " + coinCount);
                    coinCounter.text = "x " + coinCount.ToString();
                    invButton[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                    Debug.Log(item.name + " was added to inventory");
                    itemAdded = true;
                    //Do something with that object
                    item.SendMessage("DoInteraction");
                    break;
                }
                if (item.name == "Plank")
                {
                    inventory[1] = item;
                    plankCount++;
                    Debug.Log("Total Planks: " + plankCount);
                    plankCounter.text = "x " + plankCount.ToString();
                    invButton[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                    Debug.Log(item.name + " was added to inventory");
                    itemAdded = true;
                    //Do something with that object
                    item.SendMessage("DoInteraction");
                    break;
                }
                if (item.name == "Nail")
                {
                    inventory[2] = item;
                    nailCount++;
                    Debug.Log("Total Nails: " + nailCount);
                    nailCounter.text = "x " + nailCount.ToString();
                    invButton[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                    Debug.Log(item.name + " was added to inventory");
                    itemAdded = true;
                    //Do something with that object
                    item.SendMessage("DoInteraction");
                    break;
                }
            }
            if (item.name == "Coin")
            {
                coinCount++;
                Debug.Log("Total Coins: " + coinCount);
                coinCounter.text = "x " + coinCount.ToString();
                itemAdded = true;
                item.SendMessage("DoInteraction");
                break;
            }
            if (item.name == "Plank")
            {
                plankCount++;
                Debug.Log("Total Planks: " + plankCount);
                plankCounter.text = "x " + plankCount.ToString();
                itemAdded = true;
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
        coinCounter.text = "x " + coinCount.ToString();
    }
}
