using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Health : MonoBehaviour
{
    [SerializeField] Audio audiomanager;
    [Header("Health")]
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] private float currentHealth = 100f;
    [Header("Iframes")]
    [SerializeField] private float invincibilityDuration;
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private SpriteRenderer sprite;
    [Header("HealthBar")]
    [SerializeField] HealthBar Healthbar;

    void Start()
    {
        audiomanager=GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio>();
        currentHealth = maxHealth;
        Healthbar.setMaxValue(maxHealth);
        Physics2D.IgnoreLayerCollision(6,7,false);
        
    }
    void FixedUpdate()
    {
        Invoke("AddHealth",2f);
    }
    public void TakeDamage(float damage)
    {
         audiomanager.PlayMusic(audiomanager.HitClip);
        currentHealth -= damage;
        StartCoroutine(invunerabilty());
        Healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            audiomanager.PlayMusic(audiomanager.DeathClip);
            Debug.Log("Game Over");
            currentHealth=100f;
            ScoreKill.ScoreValue=0;
            print("Score Kill");
            FindAnyObjectByType<GameManager>().UpdateHiscore();

            SceneManager.LoadScene("GameOver");
        }
    }
    private IEnumerator invunerabilty()
    {
        Physics2D.IgnoreLayerCollision(6,7,true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            sprite.color = new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(invincibilityDuration/(numberOfFlashes*2));
            sprite.color = Color.white;
            yield return new WaitForSeconds(invincibilityDuration/(numberOfFlashes*2));
        }
        Physics2D.IgnoreLayerCollision(6,7,false);
    }
    private void AddHealth()
    {
        if(Input.GetKeyDown( KeyCode.Space))
        { 
            audiomanager.PlayMusic(audiomanager.ErrorClip);  
            if(ScoreKill.ScoreValue>=20&&currentHealth<maxHealth)
            {
                audiomanager.PlayMusic(audiomanager.HealthClip);  
                currentHealth+=10;
                ScoreKill.ScoreValue-=20;
                print("Current health increased");
                Healthbar.SetHealth(currentHealth);
            }
        }
    }
}
