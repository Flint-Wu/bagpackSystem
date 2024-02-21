using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new inventory",menuName = "inventory/new inventory")]
public class inventory : ScriptableObject
{
    public List<Item> itemlist = new List<Item>();    
}
