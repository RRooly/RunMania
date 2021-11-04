using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    //Create a list that contain the position of our spawners
    public Transform[] Position;
    public GameObject gameObject;

    public Transform Location;

    public bool toSpawn = true;

    void Start()
    {
        Location = Position[Random.Range(0, Position.Length)];
    }
    void Update()
    {
     StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        Location = Position[Random.Range(0, Position.Length)];

        if (toSpawn)
        {

            Instantiate(gameObject, Location);
            toSpawn = false;
            yield return new WaitForSeconds(1);
            toSpawn = true;

        }
        
    }
}
