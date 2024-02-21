using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour
{
    public int slotID;//�ո�ID = ��ƷID
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public string slotInfo;

    public GameObject itemInSlot;

    public void ItemOnClicked()
    {
        inventoryManager.UpdateItemInfo(slotInfo);
    }

    public void SetUpSlot(Item item)//���ɵ�item������item
    {
        if (item == null)//�����item�����ǿյģ�����ͼ�겻��ʾ
        {
            itemInSlot.SetActive(false);
            return;
        }

        slotImage.sprite = item.itemImage;//ʹͼ�껻��Ŀ��ͼ��
        slotNum.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;

    }
}
