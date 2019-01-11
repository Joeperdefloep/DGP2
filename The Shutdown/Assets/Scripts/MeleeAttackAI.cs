using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackAI : MonoBehaviour
{
    public Transform target;

    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Attacking AI

        //Check the distance between enemy and player (To see if close enough)
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange) {
            //check if enough time has passed
            if (Time.time > lastAttackTime + attackDelay) {
                target.SendMessage("TakeDamage", damage);
                //record the time we attacked
                lastAttackTime = Time.time;
            }
        }
    }
}
