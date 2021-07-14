using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Transform[] spawnPositions;
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
        if (spawnPositions.Length > 1)
        {
            int randomPos = Random.Range(0, spawnPositions.Length);

            player.transform.position = spawnPositions[randomPos].position;
            player.transform.rotation = spawnPositions[randomPos].rotation;

            Debug.Log(randomPos);

        }


    }
}
