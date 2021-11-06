using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : MonoBehaviour
{
    PlayerMovement playerStat;
    AddSpeed spawnerSpeed;
    
    public Rigidbody rb;

    public float forwardForce = 3000;

    // Start is called before the first frame update
    void Start()
    {
        playerStat = FindObjectOfType<PlayerMovement>();
        spawnerSpeed = FindObjectOfType<AddSpeed>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
    }


    public void OnTriggerExit(Collider collide)
    {
        if (collide.CompareTag("Player"))
        {
            StartCoroutine(SpeedBoost());
        }
    }

    IEnumerator SpeedBoost()
    {
        FindObjectOfType<Player>().LaunchParticle();
        spawnerSpeed.moveForward = 15000;
        playerStat.forwardSpeed = 300;   
        yield return new WaitForSeconds(5);
        playerStat.forwardSpeed = 70;
        spawnerSpeed.moveForward = 3500;
        Destroy(gameObject);
    }
}
