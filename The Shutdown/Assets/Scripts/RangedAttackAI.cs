using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackAI : MonoBehaviour
{
    public Transform target;
    public float attackRange;
    private float lastAttackTime;
    public float attackDelay;
    
    public GameObject projectile;
    public float bulletForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Attacking AI - Ranged
        //check to see if player is within attack range
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange) {
            //Turn towards the target

            //Vector3 targetDir = target.position - transform.position;
            //float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);
            
            //Check to see if its time to attack
            if(Time.time > lastAttackTime + attackDelay){
                //Raycast to see if we have lien of sight to target
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, attackRange);
                //Check to see if we hit anything and what it was
                if (hit.transform == target) {
                    //Hit the player - fire projectile
                    Debug.Log("Fired at player");
                    GameObject newBullet = Instantiate(projectile, transform.position, transform.rotation);
                    newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                    lastAttackTime = Time.time;
                }
            }
        }
    }
}
