using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Vector3 target;
    public float Speed = 10;
    public GameObject Explotion;
    [SerializeField] Audio audiomanager;
    void Awake ()
    {
        audiomanager=GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio>();
    }
    void Start()
    {
        target = GameObject.Find("Dir").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Speed>0)
        {
            Speed -= Random.Range(.1f,.25f);
            transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        }
        else if(Speed < 0)
        {
            Speed  = 0 ;
            StartCoroutine(Explode(1));
        }
    }
    IEnumerator Explode(float time)
    {
        
        yield return new WaitForSeconds(time);
        audiomanager.PlayMusiclaser(audiomanager.poewelClip);
        Destroy(gameObject);
        
        Instantiate(Explotion,transform.position,Quaternion.identity);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Zombie")
        {   
            print("HitEnemy");
            StartCoroutine(Explode(0));
        }
    }
}
