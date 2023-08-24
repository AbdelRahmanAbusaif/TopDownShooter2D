using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField]private float Speed;
    [SerializeField]public int Damage;
    private float currentTime;
    private float lifeTime=3f;
    public static int count;
    public static int sum;
    void Start()
    {   
        count = 0;
        sum=0;
        currentTime = Time.time;
    }
    void Update()
    {
        
        transform.Translate(Vector3.up*Speed*Time.deltaTime);
        if(Time.time-currentTime>lifeTime)
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Zombie")
        {
            Destroy(gameObject);
        }
    }
}
