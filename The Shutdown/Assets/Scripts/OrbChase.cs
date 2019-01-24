using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbChase : MonoBehaviour
{
    public int speed;
    public Transform target;
    public float chaseRange;


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
        if (distanceToTarget < chaseRange)
        {
            //Start chasing the target - turn and move towards the target
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

            transform.Translate(Vector3.up * Time.deltaTime * speed);

            GetComponent<SpiderAIHor>().enabled = false;
            GetComponent<SpiderAIVer>().enabled = false;
        }
        else
        {
            GetComponent<SpiderAIVer>().enabled = true;
            GetComponent<SpiderAIHor>().enabled = true;
        }
    }
}
