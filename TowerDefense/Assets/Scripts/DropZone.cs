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
        // 프리팹을 타일 위치에 생성
        GameObject installedPrefab = Instantiate(prefabToInstall, transform.position, Quaternion.identity);
        // 설치한 프리팹을 타일의 자식으로 설정
        installedPrefab.transform.SetParent(transform);

    }
}
