using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] spawnList;

    void Start()
    {
        
    }


    void Update()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
                        
            Vector3 topPosToSpawn = new Vector3(0, 0.57f, 0);
            Vector3 bottomPosToSpawn = new Vector3(0, -0.565f, 0);
            Vector3 leftPosToSpawn = new Vector3(-0.751f, -0.02f, 0);
            Vector3 rightPosToSpawn = new Vector3(0.751f, -0.02f, 0);
            int topObject = Random.Range(0, 6);
            int bottomObject = Random.Range(0, 6);
            int leftObject = Random.Range(0, 6);
            int rightObject = Random.Range(0, 6);
            Instantiate(spawnList[topObject], topPosToSpawn, Quaternion.identity);
            Instantiate(spawnList[bottomObject], bottomPosToSpawn, Quaternion.identity);
            Instantiate(spawnList[leftObject], leftPosToSpawn, Quaternion.identity);
            Instantiate(spawnList[rightObject], rightPosToSpawn, Quaternion.identity);    

        }
    }
}
