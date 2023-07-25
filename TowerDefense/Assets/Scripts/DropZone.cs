using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour , IDropHandler
{
    public GameObject prefabToInstall;

    public void OnDrop(PointerEventData eventData)
    {
        MakeObject draggable = eventData.pointerDrag.GetComponent<MakeObject>();
        if (draggable != null)
        {
            InstallPrefab(draggable.gameObject);
        }
    }

    private void InstallPrefab(GameObject draggableObject)
    {
        // �������� Ÿ�� ��ġ�� ����
        GameObject installedPrefab = Instantiate(prefabToInstall, transform.position, Quaternion.identity);
        // ��ġ�� �������� Ÿ���� �ڽ����� ����
        installedPrefab.transform.SetParent(transform);

    }
}
