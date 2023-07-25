using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MakeObject : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject pref = default;
    private bool isTile = false;        // Ÿ�� ������ üũ
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



        // 1. ���콺 �������� ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // 2. ���콺 �����Ϳ� Ÿ���� �Ÿ��� üũ�Ͽ� Ÿ�� �ȿ� �ִ��� Ȯ��
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0f, tileLayer);

        if (hit.collider != null)
        {
            // ���콺 �����Ͱ� Ÿ�� �ȿ� �ִ� ���
            Debug.Log("���콺 �����Ͱ� Ÿ�� �ȿ� �ֽ��ϴ�!");
            isTile = true;
            Instantiate(pref , mousePosition,Quaternion.identity);            
        }
        else
        {
            // ���콺 �����Ͱ� Ÿ�� �ۿ� �ִ� ���
            Debug.Log("���콺 �����Ͱ� Ÿ�� �ۿ� �ֽ��ϴ�!");
            isTile = false;
        }
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = DefaultPos;


    }


}


