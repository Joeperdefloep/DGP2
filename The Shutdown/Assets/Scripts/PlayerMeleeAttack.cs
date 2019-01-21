using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public int meleeDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, 1f );
            //check to see if any objects/enemies are present (except the player)
            if (hitObjects.Length > 1)
            {
                hitObjects[1].SendMessage("TakeDamage", meleeDamage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
