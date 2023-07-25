using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Tower : MonoBehaviour
{
    public Animator animator1 = default;
    public Animator animator2 = default;
    public Animator animator3 = default;
    public GameObject bullet = null;
    private GameObject closeEnemy = null;
    public bool isAttack = false;

    private float time = default;



    //public CapsuleCollider2D capsuleCollider2D = default;
    public CircleCollider2D circleCollider2 = default;


    private List<GameObject> collEnemys = new List<GameObject>();
    private float fTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        animator1 = animator1.GetComponentInChildren<Animator>();
        animator2 = animator2.GetComponentInChildren<Animator>();
        animator3 = animator3.GetComponentInChildren<Animator>();
        circleCollider2.enabled = false;
        //edgeCollider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //fTime += Time.deltaTime;
        //if (collEnemys.Count > 0)
        //{
        //    GameObject target = collEnemys[0];
        //    if (gameObject.tag == "Tower")
        //    {
        //        if (target != null && fTime > 1.0f)
        //        {
        //            fTime = 0.0f;
        //            var aBullet = Instantiate(bullet, transform.position, Quaternion.identity, transform);
        //            aBullet.GetComponent<Lamp>().targetPosition = (target.transform.position - transform.position).normalized;
        //            aBullet.transform.localScale = new Vector3(0.5f, 0.5f);
        //        }
        //    }
        //}

        time += Time.deltaTime;
    }
    //public void onOff()
    //{

    //    if(time > 0f)
    //    {
    //        circleCollider2.enabled = true;
    //        //edgeCollider2D.enabled = true;
    //        time = -1.0f;
    //    }
    //    else if(time < 0) 
    //    {
    //        circleCollider2.enabled = false;
    //        //edgeCollider2D.enabled = false;

    //    }





    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            isAttack = true;
            collEnemys.Add(collision.gameObject);
            animator1.SetBool("Attack2 Bool", isAttack);
            animator2.SetBool("Attack3 Bool", isAttack);
            animator3.SetBool("Attack Bool", isAttack);
            circleCollider2.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            isAttack = false;
            animator1.SetBool("Attack2 Bool", isAttack);
            animator2.SetBool("Attack3 Bool", isAttack);
            animator3.SetBool("Attack Bool", isAttack);
        }
        foreach (GameObject go in collEnemys)
        {

            if (go == collision.gameObject)
            {
                collEnemys.Remove(go);
                break;
            }
        }
    }
}
