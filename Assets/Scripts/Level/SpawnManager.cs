using System.Collections;
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
        if (FindObjectOfType<PauseMenu>().GameIsPaused == true || FindObjectOfType<GameOver>().gameOver == true)
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            GameObject newTopObject = Instantiate(
                getRandomSpawn(),
                GameObject.Find("PlaceBubbleT2").transform.position,
                Quaternion.identity
            );
            SpawnObject topSpawnObject = newTopObject.GetComponent<SpawnObject>();
            topSpawnObject.row = 'T';
            topSpawnObject.index = 2;

            GameObject newBottomObject = Instantiate(
                getRandomSpawn(),
                GameObject.Find("PlaceBubbleB2").transform.position,
                Quaternion.identity
            );
            SpawnObject bottomSpawnObject = newBottomObject.GetComponent<SpawnObject>();
            bottomSpawnObject.row = 'B';
            bottomSpawnObject.index = 2;

            GameObject newLeftObject = Instantiate(
                getRandomSpawn(),
                GameObject.Find("PlaceBubbleL2").transform.position,
                Quaternion.identity
            );
            SpawnObject leftSpawnObject = newLeftObject.GetComponent<SpawnObject>();
            leftSpawnObject.row = 'L';
            leftSpawnObject.index = 2;

            GameObject newRightObject = Instantiate(
                getRandomSpawn(),
                GameObject.Find("PlaceBubbleR2").transform.position,
                Quaternion.identity
            );
            SpawnObject rightSpawnObject = newRightObject.GetComponent<SpawnObject>();
            rightSpawnObject.row = 'R';
            rightSpawnObject.index = 2;

            //for organizing in heirarchy
            newTopObject.transform.parent = objectContainer.transform;
            newBottomObject.transform.parent = objectContainer.transform;
            newLeftObject.transform.parent = objectContainer.transform;
            newRightObject.transform.parent = objectContainer.transform;
        }
    }

    GameObject getRandomSpawn()
    {
        int roll = Random.Range(0, 100);

        List<GameObject> candidates = new List<GameObject>();
        foreach (GameObject spawn in spawnList) {
            if (spawn.GetComponent<SpawnObject>().DidSpawn(roll)) {
                candidates.Add(spawn);
            }
        }

        return candidates[Random.Range(0, candidates.Count)];
    }
}
