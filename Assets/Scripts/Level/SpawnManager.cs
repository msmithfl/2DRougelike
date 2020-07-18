using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] spawnList;
    public GameObject objectContainer;

    private Vector3 topPosition = new Vector3(0, 0.57f, 0);
    private Vector3 bottomPosition = new Vector3(0, -0.565f, 0);
    private Vector3 leftPosition = new Vector3(-0.751f, -0.02f, 0);
    private Vector3 rightPosition = new Vector3(0.751f, -0.02f, 0);

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
            GameObject newTopObject = Instantiate(
                getRandomSpawn(),
                topPosition,
                Quaternion.identity
            );
            GameObject newBottomObject = Instantiate(
                getRandomSpawn(),
                bottomPosition,
                Quaternion.identity
            );
            GameObject newLeftObject = Instantiate(
                getRandomSpawn(),
                leftPosition,
                Quaternion.identity
            );
            GameObject newRightObject = Instantiate(
                getRandomSpawn(),
                rightPosition,
                Quaternion.identity
            );

            //for organizing in heirarchy
            newTopObject.transform.parent = objectContainer.transform;
            newBottomObject.transform.parent = objectContainer.transform;
            newLeftObject.transform.parent = objectContainer.transform;
            newRightObject.transform.parent = objectContainer.transform;
        }
    }

    GameObject getRandomSpawn() {
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
