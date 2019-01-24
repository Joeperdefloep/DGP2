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

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
        //takes damage
        health -= damage;
        //loop to check which array number corresponds to current health
        for (int i = 0; i < 10; i = i+2) {
            //checks if whole hearts need to be taken
            if (health == i)
            {
                emptyHeartContainer[i/2].fillAmount = 1;
            }
            //checks if half hearts need to be taken
            else if (health > i && health < i+2)
            {
                emptyHeartContainer[i/2].fillAmount = 0.5f;
            }
        }
        if (health <= 0)
        {
            anim.SetTrigger("Die");
            Debug.Log("Dead");
            health = 0;
        }
    }
}
