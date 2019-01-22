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
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Melee Attack");
            Movement = GetComponent<PlayerMovement>();
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(Movement.attackPoint.position, meleeRange);
            //check to see if any objects/enemies are present (except the player)
            if (hitObjects.Length > 1)
            {
                Debug.Log("Melee Attack on enemy");
                hitObjects[0].SendMessage("TakeDamageEnemy", meleeDamage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
