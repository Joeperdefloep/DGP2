using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAI : MonoBehaviour {

    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;



    // Use this for initialization
    void Start () {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        //Check to see if we have reached the patrol point
        if(Vector3.Distance(transform.position, currentPatrolPoint.position) < 0.1f)
        {
            //We have reached the patrol point, get ready for the next one
            //Check to see if we have anymore patrol points or go back to start
            if(currentPatrolIndex + 1 < patrolPoints.Length)
            {
                currentPatrolIndex++;

            }
            else
            {
                currentPatrolIndex = 0;
            }
            currentPatrolPoint = patrolPoints[currentPatrolIndex];
        }

        //Turn to face current patrol point
        //Finding the direction Vector that points to the patrol point
        Vector3 patrolPointDirection = currentPatrolPoint.position - transform.position;
        //Figure out the rotation in degrees that we need to turn towards
        float angle = Mathf.Atan2(patrolPointDirection.y, patrolPointDirection.x) * Mathf.Rad2Deg;
        //Made the rotation that we need to face
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //Apply the rotation to our transform
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 5f);

	}
}
