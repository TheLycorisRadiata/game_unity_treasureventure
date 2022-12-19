using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] int lives;
    private int currentLifePoints;
    private BoxCollider boxCollider;
    [SerializeField] TextMeshProUGUI ShowHealth;

    private void Awake()
    {
        lives = 3;
        currentLifePoints = 100;
    }
    
    private void Start()
    {
        SetHealthText();
    }

    public void RemoveLifePoints(int lifePoints)
    {
        currentLifePoints -= lifePoints;
        if (currentLifePoints <= 0)
        {
            lives -= 1;
            if (lives == 0)
            {
                currentLifePoints = 0;
                GameOver();
            }  
            else
                currentLifePoints = 100;
        }
        SetHealthText();
    }

    private void GameOver()
    {
        // TODO: End of game
        Debug.Log("End of game");
    }
    
    void SetHealthText()
    {
        ShowHealth.text = "Health: " + currentLifePoints + "% | Life: " + lives + "/3";
    }
}
