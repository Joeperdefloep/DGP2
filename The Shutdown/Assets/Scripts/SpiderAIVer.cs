using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAIVer : MonoBehaviour
{

    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;



    // Use this for initialization
    void Start()
    {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
    }

    // Update is called once per frame
    void Update()
    {

        //Check to see if we have reached the patrol point
        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 1f)
        {
            //We have reached the patrol point, get ready for the next one
            //Check to see if we have anymore patrol points or go back to start
            if (currentPatrolIndex + 1 < patrolPoints.Length)
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
        Vector3 newScale;
        //Figure out if partol point is above or below of the enemy
        if (patrolPointDirection.y < 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            newScale = new Vector3(0.5f, 0.5f, 0.5f);
            transform.localScale = newScale;
        }
        if (patrolPointDirection.y > 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            newScale = new Vector3(-0.5f, 0.5f, 0.5f);
            transform.localScale = newScale;
        }
    }
}
