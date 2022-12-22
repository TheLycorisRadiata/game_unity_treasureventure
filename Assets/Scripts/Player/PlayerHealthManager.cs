using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
    private static AudioManager am;
    private static PlayerAnimationController ac;
    private static int lives;
    private static int currentLifePoints;
    private static BoxCollider boxCollider;
    [SerializeField] private TextMeshProUGUI ShowHealth;

    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        ac = transform.Find("Model").GetComponent<PlayerAnimationController>();
    }
    
    private void Start()
    {
        lives = 3;
        currentLifePoints = 100;
        SetHealthText();
    }

    public void RemoveLifePoints(int lifePoints)
    {
        am.Play("Hurt");
        //ac.PlayAnimation("Hurt");

        currentLifePoints -= lifePoints;
        if (currentLifePoints <= 0)
        {
            am.Play("LoseHeart");
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
        // TODO: Game over
        am.Play("Dead");
        //ac.PlayAnimation("Dying");
    }
    
    void SetHealthText()
    {
        ShowHealth.text = "Health: " + currentLifePoints + "% | Life: " + lives + "/3";
    }
}
