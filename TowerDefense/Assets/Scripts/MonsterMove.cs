using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public Vector2[] wayPoint;
    private Vector2 currPosition;
    private int wayPointIndex;
    public float speed = 0.5f;
    public  float hp = 100.0f;

    //public GameObject[] obstacles;
    //private bool stepped = false;


    // Start is called before the first frame update
    void Start()
    {
        wayPoint = new Vector2[9];

        wayPoint.SetValue(new Vector2(-5.5f, -1.5f), 0);
        wayPoint.SetValue(new Vector2(-2.5f, -1.5f), 1);
        wayPoint.SetValue(new Vector2(-2.5f, 1.5f), 2);
        wayPoint.SetValue(new Vector2( 0.5f, 1.5f), 3);
        wayPoint.SetValue(new Vector2( 0.5f, -1.5f), 4);
        wayPoint.SetValue(new Vector2( 3.5f, -1.5f), 5);
        wayPoint.SetValue(new Vector2(3.5f, 1.5f), 6);
        wayPoint.SetValue(new Vector2(6.5f, 1.5f), 7);
        wayPoint.SetValue(new Vector2(6.5f, -1.5f), 8);


    }

    // Update is called once per frame
    void Update()
    {
        currPosition = transform.position;

        if(wayPointIndex < wayPoint.Length)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(currPosition, wayPoint[wayPointIndex], step);
            
            if(Vector2.Distance (wayPoint[wayPointIndex], currPosition) == 0f)
            
                wayPointIndex++;

            if(wayPointIndex == 9)
            {
                Destroy(gameObject);
            }
            
        }

    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            hp -=0.7f;
        }



        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
