using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public int meleeDamage;
    public float meleeRange;

    PlayerMovement Movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("m"))
        {
            Movement = GetComponent<PlayerMovement>();
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(Movement.attackPoint.position, meleeRange);
            //check to see if any objects/enemies are present (except the player)
            if (hitObjects.Length > 1)
            {
                hitObjects[1].SendMessage("TakeDamageEnemy", meleeDamage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
