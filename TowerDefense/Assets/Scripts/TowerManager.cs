using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{
    public void IDragHandler()
    {
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(myAction);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void myAction()
    {
        Debug.Log("Pressed");
    }
}
