using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] int lives;
    private int currentLifePoints;
    private BoxCollider boxCollider;

    private void Awake() {
        lives = 3;
        currentLifePoints = 100;
    }

    public void RemoveLifePoints(int lifePoints)
    {
        currentLifePoints -= lifePoints;
        if (currentLifePoints <= 0)
        {
            if (!IsLastLife())
            {
                lives -= 1;
                currentLifePoints = 100;
            }
            else GameOver();
        }
    }

    private bool IsLastLife()
    {
        if (lives == 0) return true;
        return false;
    }

    private void GameOver()
    {
        // TODO: End of game
        Debug.Log("End of game");
    }
}
