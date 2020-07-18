using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public int objectID;
    public double spawnRate;


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

        bool keyPress = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D);

        //left row
        if (Time.timeScale == 0)
        {
            return;
        }
        else if (transform.position.x < -0.1f && keyPress)
        {
            transform.Translate(0.25f, 0, 0);
        }

        //right row
        else if (transform.position.x > 0.1f && keyPress)
        {
            transform.Translate(-0.25f, 0, 0);
        }

        //top row
        else if (transform.position.y > 0.1f && keyPress)
        {
            transform.Translate(0, -0.17f, 0);
        }

        //bottom row
        else if (transform.position.y < -0.1f && keyPress)
        {
            transform.Translate(0, 0.17f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {

            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
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
            }
            Destroy(this.gameObject);
        }
    }
}
