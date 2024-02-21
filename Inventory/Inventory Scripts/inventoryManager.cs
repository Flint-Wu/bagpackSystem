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
    //    //生成一个名为newItem的prefab实体,属于slot函数类
    //    slot newItem = Instantiate(instance.slotPrefab, instance.transform.position,Quaternion.identity);
    //    //将新创建的prefab设置为slotGrid的子集
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
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);//删除子集所有的空物体
            instance.slots.Clear();
        }
        for (int i = 0; i < instance.myBag.itemlist.Count; i++)
        {
            //CreaNewItem(instance.myBag.itemlist[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));//生成的过程也加入到list里
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);//将刚生成的slot放在Grid下
            instance.slots[i].GetComponent<slot>().slotID = i;//给当前物品按顺序编号
            instance.slots[i].GetComponent<slot>().SetUpSlot(instance.myBag.itemlist[i]);//将背包中的物品给slot的列表

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
