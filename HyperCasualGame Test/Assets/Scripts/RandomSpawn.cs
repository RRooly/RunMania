using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    //Create a list that contain the position of our spawners
    public Transform[] PickUpPosition;
    public Transform[] SpeedBoostPosition;

    public GameObject PickUpObject;
    public GameObject SpeedObject;

    public Transform PickUpLocation;
    public Transform SpeedBoostLocation;

    public bool toSpawn = true;
    public bool SpeedSpawn = true;

    void Start()
    {
        PickUpLocation = PickUpPosition[Random.Range(0, PickUpPosition.Length)];
        SpeedBoostLocation = SpeedBoostPosition[Random.Range(0, SpeedBoostPosition.Length)];
        
    }
    void Update()
    {
        StartCoroutine(PickUpSpawn());
        StartCoroutine(BoostSpawn());
    }

    IEnumerator PickUpSpawn()
    {
        PickUpLocation = PickUpPosition[Random.Range(0, PickUpPosition.Length)];

        if (toSpawn)
        {

            Instantiate(PickUpObject, PickUpLocation);
            toSpawn = false;
            yield return new WaitForSeconds(1);
            toSpawn = true;

        }
        
    }
    
    IEnumerator BoostSpawn()
    {
        SpeedBoostLocation = SpeedBoostPosition[Random.Range(0, SpeedBoostPosition.Length)];

        if (SpeedSpawn)
        {
            SpeedSpawn = false;
            yield return new WaitForSeconds(5);       
            Instantiate(SpeedObject, SpeedBoostLocation);   
            yield return new WaitForSeconds(10);      
            SpeedSpawn = true;

        }
        
    }
}
