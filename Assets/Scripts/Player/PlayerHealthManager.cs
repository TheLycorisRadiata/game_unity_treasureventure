using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    private static AudioManager am;
    private static PlayerAnimationController ac;
    private static int lives;
    private static int currentLifePoints;
    private static BoxCollider boxCollider;
    private static GameObject firstHeartFull, firstHeartEmpty, secondHeartFull, secondHeartEmpty, thirdHeartFull, thirdHeartEmpty;
    private static GameObject hundredsNumber, tensNumber, unitsNumber;
    [SerializeField] private GameObject[] arrNumberIcons;

    private void Awake()
    {
        Transform goLives = GameObject.Find("HUD (Canvas)").transform.Find("Lives");
        Transform firstHeart = goLives.Find("Life 1");
        Transform secondHeart = goLives.Find("Life 2");
        Transform thirdHeart = goLives.Find("Life 3");
        Transform percentage = goLives.Find("Percentage");

        // Set the heart fields
        firstHeartFull = firstHeart.Find("Full").gameObject;
        firstHeartEmpty = firstHeart.Find("Empty").gameObject;
        secondHeartFull = secondHeart.Find("Full").gameObject;
        secondHeartEmpty = secondHeart.Find("Empty").gameObject;
        thirdHeartFull = thirdHeart.Find("Full").gameObject;
        thirdHeartEmpty = thirdHeart.Find("Empty").gameObject;

        // Deactivate the empty hearts
        firstHeartEmpty.SetActive(false);
        secondHeartEmpty.SetActive(false);
        thirdHeartEmpty.SetActive(false);

        // Set the percentage fields
        hundredsNumber = percentage.Find("Hundreds Number").gameObject;
        tensNumber = percentage.Find("Tens Number").gameObject;
        unitsNumber = percentage.Find("Units Number").gameObject;

        // Set the script fields
        am = FindObjectOfType<AudioManager>();
        ac = transform.Find("Model").GetComponent<PlayerAnimationController>();
    }
    
    private void Start()
    {
        lives = 3;
        currentLifePoints = 100;
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
        SetHealthDisplay();
    }

    private void GameOver()
    {
        // TODO: Game over
        am.Play("Dead");
        //ac.PlayAnimation("Dying");
    }
    
    private void SetHealthDisplay()
    {
        DisplayHeart(1);
        DisplayHeart(2);
        DisplayHeart(3);
        DisplayPercentage();
    }

    private void DisplayHeart(int index)
    {
        bool isFull = index <= lives;

        switch (index)
        {
            case 1:
                firstHeartFull.SetActive(isFull);
                firstHeartEmpty.SetActive(!isFull);
                break;
            case 2:
                secondHeartFull.SetActive(isFull);
                secondHeartEmpty.SetActive(!isFull);
                break;
            case 3:
                thirdHeartFull.SetActive(isFull);
                thirdHeartEmpty.SetActive(!isFull);
                break;
        }
    }

    private void DisplayPercentage()
    {
        char[] tmp = currentLifePoints.ToString().ToCharArray();
        int[] arrPercentage = new int[3];
        GameObject[] arrGO = new GameObject[3];

        if (tmp.Length == 1)
        {
            arrPercentage[0] = 0;
            arrPercentage[1] = 0;
            arrPercentage[2] = (int)Char.GetNumericValue(tmp[0]);
        }
        else if (tmp.Length == 2)
        {
            arrPercentage[0] = 0;
            arrPercentage[1] = (int)Char.GetNumericValue(tmp[0]);
            arrPercentage[2] = (int)Char.GetNumericValue(tmp[1]);
        }
        else
        {
            arrPercentage[0] = (int)Char.GetNumericValue(tmp[0]);
            arrPercentage[1] = (int)Char.GetNumericValue(tmp[1]);
            arrPercentage[2] = (int)Char.GetNumericValue(tmp[2]);
        }

        arrGO[0] = Instantiate(arrNumberIcons[arrPercentage[0]], hundredsNumber.transform.position, hundredsNumber.transform.rotation);
        arrGO[0].transform.SetParent(hundredsNumber.transform.parent);
        arrGO[0].transform.localScale = hundredsNumber.transform.localScale;
        arrGO[0].layer = hundredsNumber.layer;
        arrGO[0].name = hundredsNumber.name;
        Destroy(hundredsNumber.gameObject);
        hundredsNumber = arrGO[0];

        arrGO[1] = Instantiate(arrNumberIcons[arrPercentage[1]], tensNumber.transform.position, tensNumber.transform.rotation);
        arrGO[1].transform.SetParent(tensNumber.transform.parent);
        arrGO[1].transform.localScale = tensNumber.transform.localScale;
        arrGO[1].layer = tensNumber.layer;
        arrGO[1].name = tensNumber.name;
        Destroy(tensNumber.gameObject);
        tensNumber = arrGO[1];

        arrGO[2] = Instantiate(arrNumberIcons[arrPercentage[2]], unitsNumber.transform.position, unitsNumber.transform.rotation);
        arrGO[2].transform.SetParent(unitsNumber.transform.parent);
        arrGO[2].transform.localScale = unitsNumber.transform.localScale;
        arrGO[2].layer = unitsNumber.layer;
        arrGO[2].name = unitsNumber.name;
        Destroy(unitsNumber.gameObject);
        unitsNumber = arrGO[2];

        if (tmp.Length == 2)
        {
            hundredsNumber.SetActive(false);
        }
        else if (tmp.Length == 1)
        {
            hundredsNumber.SetActive(false);
            tensNumber.SetActive(false);
        }
    }
}
