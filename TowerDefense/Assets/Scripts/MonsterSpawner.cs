using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject MonsterPrefab;
    public int count = 10;

    public float regenTime = 1.0f;

    private float regenSpawner;

    private int currentIndex = 0;

    private GameObject[] Monster;

    private Vector2 MonsterPosition = new Vector2 (-6, 1);

    private float lastSpawnTime;


    // Start is called before the first frame update
    void Start()
    {
        Monster = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            Monster[i] = Instantiate(MonsterPrefab , transform.position , Quaternion.identity);
            Monster[i].SetActive(false);

        }

        regenSpawner = 0f;
        lastSpawnTime = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        //if(GameManager.Instance.isGameOver)
        //{
        //    return;
        //}

        if(lastSpawnTime + regenSpawner <= Time.time)
        {
            lastSpawnTime = Time.time;

            regenSpawner = 1.0f;

            if(currentIndex < 10)
            {
                
            Monster[currentIndex].SetActive(true);
            Monster[currentIndex].transform.position = transform.position;
            currentIndex += 1;

            }
            else if (currentIndex == 11)
            {
                return;
            }


        }
    }
}
