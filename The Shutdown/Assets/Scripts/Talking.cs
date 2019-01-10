using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Talking : MonoBehaviour {

    public Inventory inventory;
    public PlayerMovement move;

    public Text theText;
    public GameObject textBox;
    public GameObject nails;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public TextAsset textFile;
    public TextAsset textFile2;
    public TextAsset textFile3;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            textBox.SetActive(true);
            theText.text = "Mayor: Hey you, come talk to me! Move with WASD, talk with 'E' and progress speech with the 'Enter' key.";
        }
    }

    public void Speak()
    {
        if (inventory.nailCount >= 20 && inventory.plankCount >= 5)
        {
            textBox.SetActive(true);
            Debug.Log("Burgm WIN");
            textLines = (textFile.text.Split('\n'));

            if (endAtLine == 0)
            {
                endAtLine = textLines.Length - 1;
            }
        } else if (inventory.coinCount < 10 && inventory.nailCount == 0)
        {
            textBox.SetActive(true);
            Debug.Log("Burgm FAAL");
            textLines = (textFile2.text.Split('\n'));

            if (endAtLine == 0)
            {
                endAtLine = textLines.Length - 1;
            }
        } else
        {
            textBox.SetActive(true);
            Debug.Log("Burgm BIJNA");
            textLines = (textFile3.text.Split('\n'));

            if (endAtLine == 0)
            {
                endAtLine = textLines.Length - 1;
            }
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (textBox == true)
        {
            theText.text = textLines[currentLine];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                currentLine += 1;
                Debug.Log(currentLine);
            }


            if (textFile != null)
            {
                if (currentLine <= endAtLine)
                {
                    theText.text = textLines[currentLine];
                }
            }
            if (currentLine > endAtLine)
            {
                textBox.SetActive(false);
                currentLine = 0;
                textLines = null;
                if(textFile3.name == "WorkshopTextWin" && inventory.coinCount >= 10)
                {
                    inventory.coinCount = inventory.coinCount - 10;
                    inventory.nailCount = inventory.nailCount + 20;
                    inventory.invButton[2].image.overrideSprite = nails.GetComponent<SpriteRenderer>().sprite;
                    inventory.inventory[2] = nails;
                }
                if(textFile.name == "WheelText" || textFile2.name == "WheelText" || textFile3.name == "WheelText")
                {
                    PlayerPrefs.SetInt("muntjes", inventory.coinCount);
                    PlayerPrefs.SetInt("planken", inventory.plankCount);
                    PlayerPrefs.SetInt("schroeven", inventory.nailCount);
                    PlayerPrefs.SetFloat("positieX", move.posX);
                    PlayerPrefs.SetFloat("positieY", move.posY);
                    PlayerPrefs.SetFloat("positieZ", move.posZ);
                    Debug.Log(move.posX + move.posY + move.posZ);
                    SceneManager.LoadScene("Wheel");
                }
                if ((textFile.name == "WheelTextWin" || textFile2.name == "WheelTextWin" || textFile3.name == "WheelTextWin") && inventory.coinCount < 10)
                {
                    inventory.coinCount = inventory.coinCount + 10;
                }
                if (textFile.name == "BridgeTextWin" && inventory.nailCount >= 20 && inventory.plankCount >= 5)
                {
                    PlayerPrefs.SetInt("muntjes", inventory.coinCount);
                    PlayerPrefs.SetInt("planken", inventory.plankCount);
                    PlayerPrefs.SetInt("schroeven", inventory.nailCount);
                    PlayerPrefs.SetFloat("positieX", move.posX);
                    PlayerPrefs.SetFloat("positieY", move.posY);
                    PlayerPrefs.SetFloat("positieZ", move.posZ);
                    Debug.Log("Minigame Tijd");
                    SceneManager.LoadScene("Choice1");
                }
            }
        }
        if(PlayerPrefs.GetString("LastScene") == "Bridge 1" || PlayerPrefs.GetString("LastScene") == "Bridge 2")
        {
            textBox.SetActive(true);
            theText.text = "Mayor: It seems like this design is not strong enough, try another one!";
        }
    }
}
