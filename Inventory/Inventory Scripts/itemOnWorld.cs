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
        if (!playerinventory.itemlist.Contains(thisItem))//���itemList�Ƿ������ǰ����item
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
            //�������û�е�ǰ����item�����ڱ����д���һ�������͵�item
            //inventoryManager.CreaNewItem(thisItem);
        }
        else
        {
            thisItem.itemHeld += 1;
        }

        inventoryManager.RefreshItem();
    }
}
