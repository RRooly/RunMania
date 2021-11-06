using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    TileSpawn tilespawner;

    // Start is called before the first frame update
    void Start()
    {
        tilespawner = GameObject.FindObjectOfType<TileSpawn>();
    }

    private void OnTriggerExit(Collider collide)
    {
        tilespawner.SpawnTile();
        Destroy(gameObject, 2);
    }
}
