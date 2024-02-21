using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public inventory playerinventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }

    public void AddNewItem()
    {
        if (!playerinventory.itemlist.Contains(thisItem))//检测itemList是否包含当前类型item
        {
            //playerinventory.itemlist.Add(thisItem);
            for (int i = 0; i < playerinventory.itemlist.Count; i++)
            {
                if (playerinventory.itemlist[i]==null)
                {
                    playerinventory.itemlist[i] = thisItem;
                    break;
                }
            }
            thisItem.itemHeld += 1;
            //如果背包没有当前类型item，则在背包中创建一个该类型的item
            //inventoryManager.CreaNewItem(thisItem);
        }
        else
        {
            thisItem.itemHeld += 1;
        }

        inventoryManager.RefreshItem();
    }
}
