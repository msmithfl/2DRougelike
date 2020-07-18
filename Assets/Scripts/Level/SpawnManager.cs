﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] spawnList;
    public GameObject objectContainer;

    void Start()
    {
        
    }

    void Update()
    {
        SpawnObjects();        
    }

    void SpawnObjects()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
                        
            Vector3 topPosToSpawn = new Vector3(0, 0.57f, 0);
            Vector3 bottomPosToSpawn = new Vector3(0, -0.565f, 0);
            Vector3 leftPosToSpawn = new Vector3(-0.751f, -0.02f, 0);
            Vector3 rightPosToSpawn = new Vector3(0.751f, -0.02f, 0);
            int topObject = Random.Range(0, 6);
            int bottomObject = Random.Range(0, 6);
            int leftObject = Random.Range(0, 6);
            int rightObject = Random.Range(0, 6);
            GameObject newTopObject = Instantiate(spawnList[topObject], topPosToSpawn, Quaternion.identity);
            GameObject newBottomObject = Instantiate(spawnList[bottomObject], bottomPosToSpawn, Quaternion.identity);
            GameObject newLeftObject = Instantiate(spawnList[leftObject], leftPosToSpawn, Quaternion.identity);
            GameObject newRightObject = Instantiate(spawnList[rightObject], rightPosToSpawn, Quaternion.identity);

            //for organizing in heirarchy
            newTopObject.transform.parent = objectContainer.transform;
            newBottomObject.transform.parent = objectContainer.transform;
            newLeftObject.transform.parent = objectContainer.transform;
            newRightObject.transform.parent = objectContainer.transform;

        }
    }
}