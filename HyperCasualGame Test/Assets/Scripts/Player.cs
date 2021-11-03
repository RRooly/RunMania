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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 60;
        healthBar.SetMaxHelth(maxHealth);
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
        TakeDamage(20);
        IsRunning = 1;
    }

    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
           
        }
    }



}
