using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    public Image[] heartContainer;
    public Image[] emptyHeartContainer;
    public float fillAmount;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < emptyHeartContainer.Length; i++)
        {
            emptyHeartContainer[i].fillAmount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        for (int i = 0; i < 11; i = i+2) {
            if (health == i) {
                emptyHeartContainer[i/2].fillAmount =
            }
        }
        if (health <= 0)
        {
            Debug.Log("Dead");
        }
    }
}
