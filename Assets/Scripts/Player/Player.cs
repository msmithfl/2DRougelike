﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth = 10;
    [SerializeField]
    private bool isHoldingKey = false;
    public Text healthUI;

    void Start()
    {
        healthUI.text = "HP " + currentHealth + "/" + maxHealth;
    }

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        healthUI.text = "HP " + currentHealth + "/" + maxHealth;
    }

    //Collect functions for interacting with items/enemies
    //Connected with SpawnObjects
    public void CollectHeart()
    {
        if(currentHealth >= 10)
        {
            Debug.Log("Health Max!");
            return;
        }
        else
        {
            currentHealth++;            
            Debug.Log("Heart Collected!");
        }       
    }

    public void CollectKey()
    {
        if (isHoldingKey == false)
        {
            isHoldingKey = true;
            Debug.Log("Key Collected!");
        }
        else
        {
            Debug.Log("Keys Full!");
            return;
        }
        
    }

    public void CollectEnemy()
    {
        currentHealth--;
        Debug.Log("Enemy Collected!");
    }

    public void CollectChest()
    {
        Debug.Log("Chest Collected!");
    }

    public void CollectDoor()
    {
        if (isHoldingKey)
        {
            isHoldingKey = false;
            Debug.Log("Door Opened!");
        }
        else
        {
            isHoldingKey = false;
            Debug.Log("Door Was Locked!");            
        }        
    }
}
