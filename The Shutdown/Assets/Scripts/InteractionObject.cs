using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionObject : MonoBehaviour {

    public Talking speaks;

    public bool inventory;      //If true, this object can be stored in inventory
    public bool openable;       //If true, this object can be opened
    public bool locked;         //If true, this object is locked
    public bool canTalk;          //If true, this object can talk to the player
    public string itemType;     //This will tell what type of item this object is

    public GameObject itemNeeded;      //Object required to interact with this item.
    public int coinsNeeded;
    public string message;             //The message this object will give the player

    
    public void DoInteraction()
    {
        Debug.Log("Open Sesame!");
        //gameObject.SetActive(false);
    }

    public void Talk()
    {
        Debug.Log(message);
        speaks.Speak();
    }

}
