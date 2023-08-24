using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private int health ;
    [SerializeField] Audio audiomanager;
    [SerializeField] private int damage;
    private bool explosion;
    void Start()
    {   
        audiomanager=GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio>();
        player =FindAnyObjectByType<PlayerMovement>().transform;
    }
    void Update()
    {
        transform.position=Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //take damage for enemy
        if(other.tag=="projectile")
        {
            
            TakeDamage(other.GetComponent<projectile>().Damage);
        }
        //take damage for player
        if(other.tag=="Player")
        {
            //change to  player health 
            other.GetComponent<Health>().TakeDamage(damage);           
            float Temp=Time.time;
            float temp1= Time.time-Temp;
            Spawn.StartingTime=temp1;
        }
    }
    public void TakeDamage(int DamageAmount)
    {
        health -=DamageAmount;
        if(health<=0)
        {
            Destroy(gameObject);
            audiomanager.PlayMusic(audiomanager.EnemydamageClip);
            ScoreKill.ScoreValue++;
        }
        if(!explosion)
        {
            explosion=true;
            health -=DamageAmount;
        }
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.2f);
        explosion=false;
    }
}
