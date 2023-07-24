using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public bool isFinish = false;
    public bool isGameOver = false;
    public TMP_Text scoreText; // Text mesh pro������Ʈ �� ���
    public GameObject gameoverUi;
    public float score = default;




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
        //if (isGameOver == false)
        //{
        //    score += Time.deltaTime * 2;
        //    scoreText.text = string.Format("Score : {0}M", (int)score);


        //}
    }



    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUi.SetActive(true);
    }

    public void Finish()
    {

    }
}
