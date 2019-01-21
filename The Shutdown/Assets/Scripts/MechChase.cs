using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechChase : MonoBehaviour
{
    public int speed;
    public Transform target;
    public float chaseRange;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Chasing player AI
        //Get the distance to the target and check to see if it is close enough to chase
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        Vector3 targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        if (distanceToTarget < chaseRange)
        {
            //Start chasing the target - turn and move towards the target
         // Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
         // transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

            //transform.Translate(Vector3.up * Time.deltaTime * speed);
            transform.Translate(targetDir.normalized * Time.deltaTime * speed);
            Debug.Log(angle);

            if (angle < 45 && angle > -45)
            {
                anim.SetBool("WalkRight", true);
                anim.SetBool("WalkLeft", false);
                anim.SetBool("WalkUp", false);
                anim.SetBool("WalkDown", false);

                anim.SetBool("Right", false);
                anim.SetBool("Left", false);
                anim.SetBool("Up", false);
                anim.SetBool("Down", false);
            }
            else if (angle < 135 && angle > 45)
            {
                anim.SetBool("WalkRight", false);
                anim.SetBool("WalkLeft", false);
                anim.SetBool("WalkUp", true);
                anim.SetBool("WalkDown", false);

                anim.SetBool("Right", false);
                anim.SetBool("Left", false);
                anim.SetBool("Up", false);
                anim.SetBool("Down", false);
            }
            else if (angle < -135 || angle > 135)
            {
                anim.SetBool("WalkRight", false);
                anim.SetBool("WalkLeft", true);
                anim.SetBool("WalkUp", false);
                anim.SetBool("WalkDown", false);

                anim.SetBool("Right", false);
                anim.SetBool("Left", false);
                anim.SetBool("Up", false);
                anim.SetBool("Down", false);
            }
            else if (angle < -45 && angle > -135)
            {
                anim.SetBool("WalkRight", false);
                anim.SetBool("WalkLeft", false);
                anim.SetBool("WalkUp", false);
                anim.SetBool("WalkDown", true);
                
                anim.SetBool("Right", false);
                anim.SetBool("Left", false);
                anim.SetBool("Up", false);
                anim.SetBool("Down", false);
            }
            // GetComponent<PatrolAI>().enabled = false;
        }
        else
        {
            if (angle < 45 && angle > -45)
            {
                anim.SetBool("Right", true);
                anim.SetBool("Left", false);
                anim.SetBool("Up", false);
                anim.SetBool("Down", false);

                anim.SetBool("WalkRight", false);
                anim.SetBool("WalkLeft", false);
                anim.SetBool("WalkUp", false);
                anim.SetBool("WalkDown", false);
            }
            else if (angle < 135 && angle > 45)
            {
                anim.SetBool("Right", false);
                anim.SetBool("Left", false);
                anim.SetBool("Up", true);
                anim.SetBool("Down", false);

                anim.SetBool("WalkRight", false);
                anim.SetBool("WalkLeft", false);
                anim.SetBool("WalkUp", false);
                anim.SetBool("WalkDown", false);
            }
            else if (angle < -135 || angle > 135)
            {
                anim.SetBool("Right", false);
                anim.SetBool("Left", true);
                anim.SetBool("Up", false);
                anim.SetBool("Down", false);

                anim.SetBool("WalkRight", false);
                anim.SetBool("WalkLeft", false);
                anim.SetBool("WalkUp", false);
                anim.SetBool("WalkDown", false);
            }
            else if (angle < -45 && angle > -135)
            {
                anim.SetBool("Right", false);
                anim.SetBool("Left", false);
                anim.SetBool("Up", false);
                anim.SetBool("Down", true);

                anim.SetBool("WalkRight", false);
                anim.SetBool("WalkLeft", false);
                anim.SetBool("WalkUp", false);
                anim.SetBool("WalkDown", false);
            }
            // GetComponent<PatrolAI>().enabled = true;
        }
    }
}
