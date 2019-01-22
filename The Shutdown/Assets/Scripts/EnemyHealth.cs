using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamageEnemy(int damage) {
        health -= damage;
        if (health <= 0) {
            Debug.Log("Enemy Dead");
            //Needs death animation
            Destroy(gameObject);
        }
    }
}
