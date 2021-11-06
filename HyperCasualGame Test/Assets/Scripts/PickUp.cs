using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 5000;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0,0, -forwardForce * Time.deltaTime);
    }

    public void OnTriggerExit(Collider collide)
    {
        if (collide.CompareTag("Player"))
        {
            FindObjectOfType<Player>().Heal(10);
            Destroy(gameObject);
        }
    }

}
