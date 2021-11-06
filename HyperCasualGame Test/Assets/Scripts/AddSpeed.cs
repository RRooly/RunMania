using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeed : MonoBehaviour
{

    public Rigidbody rb;
    public float moveForward = 3500;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        rb.velocity = Vector3.forward * moveForward * Time.deltaTime;
    }
}
