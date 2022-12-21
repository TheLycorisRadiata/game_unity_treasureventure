using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
    private static AudioManager am;
    private static int lives;
    private static int currentLifePoints;
    private static BoxCollider boxCollider;
    [SerializeField] private TextMeshProUGUI ShowHealth;

    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
    }
    
    private void Start()
    {
        lives = 3;
        currentLifePoints = 100;
        SetHealthText();
    }

    public void RemoveLifePoints(int lifePoints)
    {
        am.Play("ManDamaged");
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
