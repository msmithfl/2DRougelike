using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public int objectID;
    public double spawnRate;

    public char row;
    public int index;

    public virtual bool DidSpawn(int roll) {
        return spawnRate * 100 >= roll;
    }

    void Start()
    {
    }

    void Update()
    {
        MoveObjects();
    }

    void MoveObjects()
    {
        if (FindObjectOfType<PauseMenu>().GameIsPaused == true || FindObjectOfType<GameOver>().gameOver == true)
        {
            return;
        } else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) {
            index -= 1;
            updatePosition();
        }
    }

    private void updatePosition()
    {
        if (index >= 0) {
            transform.position = GameObject.Find("PlaceBubble" + row.ToString() + index.ToString()).transform.position;
        } else {
            collision();
        }
    }

    private void collision()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();

        switch (objectID)
        {
            case 0:
                player.CollectHeart();
                break;
            case 1:
                player.CollectKey();
                break;
            case 2:
                player.CollectEnemy();
                break;
            case 3:
                player.CollectChest();
                break;
            case 4:
                player.CollectDoor();
                break;
            default:
                Debug.Log("Default Value");
                break;
        }

        Destroy(this.gameObject);
    }
}
