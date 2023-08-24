using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] static public float Cooldown = 2f;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public Transform[] SpawnPoint;
    private float nextSpawnTime;
    [SerializeField]static public float SwitchTime=10f;
    [SerializeField]static public float StartingTime;
   public float SwitchTimeWafe;
    // Update is called once per frame
     void Start()
    {   
        //to restar speed respawn
        Cooldown=2f;
        SwitchTime=10f;
        StartingTime= Time.time;
        nextSpawnTime = Time.time + Cooldown;
        SwitchTimeWafe=0;
    }
    void Update()
    {
       //for change speed respawn
       if(SwitchTime<Time.time-StartingTime&&Cooldown>0.5)
       {
            Cooldown=Cooldown-0.2f;
            SwitchTime*=2;
       }
       if(Time.time >= nextSpawnTime&&FindAnyObjectByType<GameManager>().ScoreTime<=60f)
       {
           SpawnEnemy(enemy1); 
       } 
       else if(Time.time >= nextSpawnTime&&FindAnyObjectByType<GameManager>().ScoreTime>=60f&&FindAnyObjectByType<GameManager>().ScoreTime<=120f)
       {
           SpawnEnemy(enemy2);
       }
       else if(Time.time >= nextSpawnTime&&FindAnyObjectByType<GameManager>().ScoreTime>=120f&&FindAnyObjectByType<GameManager>().ScoreTime<=180f)
       {
           SpawnEnemy(enemy3);
       }
       else if(Time.time >= nextSpawnTime&&FindAnyObjectByType<GameManager>().ScoreTime>=180f&&FindAnyObjectByType<GameManager>().ScoreTime<=240f)
       {
           SpawnEnemy(enemy4);
       }
       else if(Time.time >= nextSpawnTime&&FindAnyObjectByType<GameManager>().ScoreTime>=240f&&FindAnyObjectByType<GameManager>().ScoreTime<=300f)
       {
           SpawnEnemy(enemy5);
       }
       else if(Time.time >= nextSpawnTime&&FindAnyObjectByType<GameManager>().ScoreTime>=300f)
       {
           SpawnEnemy(enemy6);
       }
    }

    void SpawnEnemy(GameObject enemy)
    {
            Transform randomeSPawnPoint =SpawnPoint[Random.Range(0,SpawnPoint.Length)];
            Instantiate(enemy,randomeSPawnPoint.position,Quaternion.identity);
            nextSpawnTime = Time.time + Cooldown; // Set the next spawn time
    }
}
