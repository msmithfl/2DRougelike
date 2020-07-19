using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    [SerializeField]
    private bool isHoldingKey = false;
    public Text healthUI;
    public Text expUI;
    public GameObject keyImage;
    public ExperienceBar expBar;
    public int maxExp = 10;
    public int currentExp = 0;
    public int currentLvl = 1;
    

    void Start()
    {
        healthUI.text = "HP " + currentHealth + "/" + maxHealth;
        expUI.text = "LVL " + currentLvl;
        keyImage.SetActive(false);
        expBar.SetMaxExp(maxExp);
    }

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        healthUI.text = "HP " + currentHealth + "/" + maxHealth;

        if (isHoldingKey == false)
        {
            keyImage.SetActive(false);
        }

        //level up effects
        if (currentExp >= 10)
        {
            currentLvl++;
            expUI.text = "LVL " + currentLvl;            
            currentExp = 0;
            expBar.SetExp(0);
            maxHealth++;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    //Collect functions for interacting with items/enemies
    //Connected with SpawnObject
    public void CollectHeart()
    {
        if(currentHealth >= maxHealth)
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
            keyImage.SetActive(true);
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
        currentExp++;
        expBar.SetExp(currentExp);
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
            currentLvl++;
            expUI.text = "LVL " + currentLvl;
            maxHealth++;
            Debug.Log("Door Opened!");
        }
        else
        {
            isHoldingKey = false;
            Debug.Log("Door Was Locked!");            
        }
    }
}
