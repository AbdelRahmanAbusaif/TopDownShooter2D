using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Vector2 Center;
    public float radius;
    

    // Update is called once per frame
    void Update()
    {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(transform.position,radius);
        foreach (Collider2D enemy in enemyHit)
        {
               Enemy enemyhealth = enemy.GetComponent<Enemy>();
               if(enemyhealth!=null) enemyhealth.TakeDamage(60);
        }    
    }
    void DestroyIT()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelect()
    {
        print("Drawing");
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
