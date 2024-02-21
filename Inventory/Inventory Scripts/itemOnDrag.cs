using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class itemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform originalParent;
    public inventory myBag;
    public int currentItemID;//当前物品ID

    public void OnBeginDrag(PointerEventData eventData)//pointer为鼠标点击位置
    {
        originalParent = transform.parent;//记录物品原本的父级
        currentItemID = originalParent.GetComponent<slot>().slotID;
        transform.SetParent(transform.parent.parent);//将item设为Grid的子集，与slot同级
        transform.position = eventData.position;//使物品的位置=鼠标点击位置
        GetComponent<CanvasGroup>().blocksRaycasts = false;//关闭挂载项目CanvasGroup组件中的blocksRaycasts选项
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;//使物品的位置=鼠标点击位置
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);//鼠标射线触碰到的gameobject
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "itemImage")
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
            //itemList的物品储存位置改变

            var temp = myBag.itemlist[currentItemID];
            myBag.itemlist[currentItemID] = myBag.itemlist[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID];
            myBag.itemlist[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID] = temp;
            //两样物品对调

            eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            //打开射线阻挡，不然无法再次选中移动的物品
            return;
        }
        //否则直接挂在检测到slot下面
        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
        //itemList的物品储存位置改变

        myBag.itemlist[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<slot>().slotID] = myBag.itemlist[currentItemID];
        myBag.itemlist[currentItemID] = null;

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    
}
