using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public bool isFinish = false;
    public bool isGameOver = false;
    public Text scoreText; 
    public GameObject gameoverUi;
    public Text GoldText;
    public float score = default;
    public float gold = default;




    private void Awake()
    {
        if (Instance.IsValid() == false)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            GFunc.LoadScene(GFunc.GetActiveSceneName());
        }

    }



    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUi.SetActive(true);
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        scoreText.text = string.Format("scoreText : {0}", score);
    }

    public void AddGold(int newGold)
    {
        gold += newGold;
        GoldText.text = string.Format("Gold : {0}" , gold);

    }


}
