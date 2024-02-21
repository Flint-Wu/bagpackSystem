using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManager : MonoBehaviour
{
    static inventoryManager instance;

    public inventory myBag;
    public GameObject slotGrid;
    //public slot slotPrefab;
    public GameObject emptySlot;
    public Text itemInformation;

    public List<GameObject> slots = new List<GameObject>();
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = "";
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription;
    }

    //public static void CreaNewItem(Item item)
    //{
    //    //����һ����ΪnewItem��prefabʵ��,����slot������
    //    slot newItem = Instantiate(instance.slotPrefab, instance.transform.position,Quaternion.identity);
    //    //���´�����prefab����ΪslotGrid���Ӽ�
    //    newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
    //    newItem.slotItem = item;
    //    newItem.slotImage.sprite = item.itemImage;
    //    newItem.slotNum.text = item.itemHeld.ToString();
    //}

    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
            {
                break;
            }
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);//ɾ���Ӽ����еĿ�����
            instance.slots.Clear();
        }
        for (int i = 0; i < instance.myBag.itemlist.Count; i++)
        {
            //CreaNewItem(instance.myBag.itemlist[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));//���ɵĹ���Ҳ���뵽list��
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);//�������ɵ�slot����Grid��
            instance.slots[i].GetComponent<slot>().slotID = i;//����ǰ��Ʒ��˳����
            instance.slots[i].GetComponent<slot>().SetUpSlot(instance.myBag.itemlist[i]);//�������е���Ʒ��slot���б�

        }
    }

    private void list()
    {
        ArrayList mylist = new ArrayList();
        System.Random rand = new System.Random();

        int num = rand.Next(1,50);
        if (mylist.Contains(num))
            mylist.Add(num);
    }
}
