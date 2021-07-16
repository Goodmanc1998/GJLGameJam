using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    GameObject[] spawnPositions;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        GetRandomSpawnLocation(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void GetRandomSpawnLocation()
    {

        spawnPositions = GameObject.FindGameObjectsWithTag("SpawnPositions");

        if (spawnPositions.Length > 1)
        {
            int randomPos = Random.Range(0, spawnPositions.Length);

            player.transform.position = spawnPositions[randomPos].transform.position;
            player.transform.rotation = spawnPositions[randomPos].transform.rotation;
        }

    }
}
