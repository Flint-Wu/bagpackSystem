using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class itemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform originalParent;
    public inventory myBag;
    public int currentItemID;//��ǰ��ƷID

    public void OnBeginDrag(PointerEventData eventData)//pointerΪ�����λ��
    {
        originalParent = transform.parent;//��¼��Ʒԭ���ĸ���
        currentItemID = originalParent.GetComponent<slot>().slotID;
        transform.SetParent(transform.parent.parent);//��item��ΪGrid���Ӽ�����slotͬ��
        transform.position = eventData.position;//ʹ��Ʒ��λ��=�����λ��
        GetComponent<CanvasGroup>().blocksRaycasts = false;//�رչ�����ĿCanvasGroup����е�blocksRaycastsѡ��
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;//ʹ��Ʒ��λ��=�����λ��
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);//������ߴ�������gameobject
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "itemImage")
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
            //itemList����Ʒ����λ�øı�

            var temp = myBag.itemlist[currentItemID];
            myBag.itemlist[currentItemID] = myBag.itemlist[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID];
            myBag.itemlist[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID] = temp;
            //������Ʒ�Ե�

            eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            //�������赲����Ȼ�޷��ٴ�ѡ���ƶ�����Ʒ
            return;
        }
        //����ֱ�ӹ��ڼ�⵽slot����
        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
        //itemList����Ʒ����λ�øı�

        myBag.itemlist[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID] = myBag.itemlist[currentItemID];
        myBag.itemlist[currentItemID] = null;

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    
}
