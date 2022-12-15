using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] int lives = 3;
    private int currentLifePoints = 100;
    private BoxCollider boxCollider;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RemoveLifePoints(int lifePoints)
    {
        currentLifePoints -= lifePoints;
        if (currentLifePoints <= 0)
        {
            if (!IsLastLife())
            {
                lives--;
                currentLifePoints = 100;
            }
            else
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        // TODO: End of game
    }

    private bool IsLastLife()
    {
        if (lives == 0)
        {
            return true;
        }
        return false;
    }

    public void DisablePhysics()
    {
        boxCollider.isTrigger = true;
    }

    public void EnablePhysics()
    {
        boxCollider.isTrigger = false;
    }
}
