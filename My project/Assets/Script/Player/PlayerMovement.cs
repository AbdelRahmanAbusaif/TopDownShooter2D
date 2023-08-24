using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] Audio audiomanager;
    private Rigidbody2D rb;
    private Animator anim;
    [Header("Shooting")]
    [SerializeField] private Transform Weapon;
    [SerializeField] private float offset;
    [SerializeField] private Transform ShootPoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject Grenade;
    [SerializeField] private float Cooldown;
    private float nextShootTime;
    private float amoutBulletShotGun=3;
    static public float CurrentBullet;
    public float MaxBullet;
    void Awake ()
    {
        audiomanager=GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio>();
    }
    void Start()
    {   
        MaxBullet=30; 
        anim=GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        CurrentBullet=MaxBullet;
    }
    
    void Update()
    {
        //movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

       if (Mathf.Abs(moveHorizontal) > Mathf.Abs(moveVertical))
        {
            movement = new Vector2(moveHorizontal, 0f);
        }
        else if (Mathf.Abs(moveVertical) > Mathf.Abs(moveHorizontal))
        {
            movement = new Vector2(0f, moveVertical);
        }

        movement = movement.normalized * moveSpeed;
        rb.velocity = movement;
        /*animation
        anim.SetFloat("Horizontal",movement.x);
        anim.SetFloat("Vertical",movement.y);
        anim.SetFloat("Speed",movement.sqrMagnitude);*/
        //Weapon Rotatio*
        Vector3 disableformat = Weapon.position-Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angel=Mathf.Atan2(disableformat.y,disableformat.x)*Mathf.Rad2Deg;
        Weapon.rotation=Quaternion.Euler(0f,0f,angel+offset);
        //Shoohting
        Shoohting();
        //ShootingGrenade
        ShoohtingGrenade();
        //ShootingShootGun
        ShoohtingGun();
        //Reloading
        if(Input.GetKeyDown(KeyCode.R))
            Reloading();
    }
    public void Reloading()
    {
       if(CurrentBullet==0)
        {
            CurrentBullet=MaxBullet;
        }
    }
    public void ShoohtingGrenade()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {   
            audiomanager.PlayMusic(audiomanager.ErrorClip);
            if(ScoreKill.ScoreValue>=30)
            {
                ScoreKill.ScoreValue-=30;
                nextShootTime=Time.time+Cooldown;
                Instantiate(Grenade,ShootPoint.position,ShootPoint.rotation);
            }       
        }
    }
    public void  Shoohting()
    {       
        if(Input.GetMouseButtonDown(0))
        {
            if(CurrentBullet==0)
            {
                Invoke("Reloading",4f);
                audiomanager.PlayMusic(audiomanager.ErrorClip);
            }
            if(Time.time>nextShootTime&&CurrentBullet!=0)
                {
                    CurrentBullet--;
                    print(CurrentBullet);
                    audiomanager.PlayMusiclaser(audiomanager.ShootClip);
                    nextShootTime=Time.time+Cooldown;
                    Instantiate(projectile,ShootPoint.position,ShootPoint.rotation);
                }
        }
    }
    public void  ShoohtingGun()
    {
        
        if(Input.GetMouseButtonDown(1))
        {
            audiomanager.PlayMusic(audiomanager.ErrorClip);
            if(ScoreKill.ScoreValue>10)
            {
                ScoreKill.ScoreValue-=10;
                if(Time.time>nextShootTime)
                {
                            
                    for(int i=0;i<amoutBulletShotGun;i++){
                    audiomanager.PlayMusiclaser(audiomanager.ShotGunClip);
                    nextShootTime=Time.time+Cooldown;
                    Instantiate(projectile,ShootPoint.position,ShootPoint.rotation);}
                }
            }
        }
    }
}

//move just in 4 direction 
/*using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        bool horizontalInput = Mathf.Abs(moveHorizontal) > 0.1f;
        bool verticalInput = Mathf.Abs(moveVertical) > 0.1f;

        if (horizontalInput && verticalInput)
        {
            if (Mathf.Abs(moveHorizontal) > Mathf.Abs(moveVertical))
            {
                moveVertical = 0f;
            }
            else
            {
                moveHorizontal = 0f;
            }
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        movement = movement.normalized * moveSpeed;
        rb.velocity = movement;
    }
}
*/