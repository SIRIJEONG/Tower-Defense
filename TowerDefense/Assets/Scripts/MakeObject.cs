using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MakeObject : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject pref = default;
    private bool isTile = false;        // 타일 안인지 체크
    public LayerMask tileLayer;
    public static Vector2 DefaultPos;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        DefaultPos = this.transform.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        this.transform.position = currentPos;


    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {



        // 1. 마우스 포인터의 스크린 좌표를 월드 좌표로 변환
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // 2. 마우스 포인터와 타일의 거리를 체크하여 타일 안에 있는지 확인
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0f, tileLayer);

        if (hit.collider != null)
        {
            // 마우스 포인터가 타일 안에 있는 경우
            Debug.Log("마우스 포인터가 타일 안에 있습니다!");
            isTile = true;
            Instantiate(pref , mousePosition,Quaternion.identity);            
        }
        else
        {
            // 마우스 포인터가 타일 밖에 있는 경우
            Debug.Log("마우스 포인터가 타일 밖에 있습니다!");
            isTile = false;
        }
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = DefaultPos;


    }


}


