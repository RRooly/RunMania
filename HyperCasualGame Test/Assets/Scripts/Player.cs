using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public int IsRunning = 1;
    public int NumberofSeconds;

    public ParticleSystem speedSpark;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 60;
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRunning == 1)
        {
            StartCoroutine(ConstantDamage());
        }
    }

    //Function that reduce health time by time
    public IEnumerator ConstantDamage()
    {
        IsRunning = 0;
        yield return new WaitForSeconds(NumberofSeconds); 
        TakeDamage(15);
        IsRunning = 1;
    }

    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
        if (currentHealth >= maxHealth)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void LaunchParticle()
    {
        speedSpark.Play();
    }
    
}
