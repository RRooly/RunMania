using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTile()
    {
      GameObject temp =  Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
      nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }
}
