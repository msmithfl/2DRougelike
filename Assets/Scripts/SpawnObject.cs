using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    private bool keyPress = false;

    void Start()
    {

    }

    void Update()
    {
        MoveObjects();
    }

    void MoveObjects()
    {

        keyPress = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D);

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
        Player player = other.transform.GetComponent<Player>();

        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
