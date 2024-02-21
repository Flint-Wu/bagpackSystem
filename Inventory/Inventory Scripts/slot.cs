using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour
{
    public int slotID;//空格ID = 物品ID
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public string slotInfo;

    public GameObject itemInSlot;

    public void ItemOnClicked()
    {
        inventoryManager.UpdateItemInfo(slotInfo);
    }

    public void SetUpSlot(Item item)//生成的item归属于item
    {
        if (item == null)//如果有item格子是空的，则令图标不显示
        {
            itemInSlot.SetActive(false);
            return;
        }

        slotImage.sprite = item.itemImage;//使图标换成目标图标
        slotNum.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;

    }
}
