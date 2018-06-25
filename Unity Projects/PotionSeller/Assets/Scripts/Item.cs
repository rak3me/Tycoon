using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string itemName;                                     //itemName of the item
    public int itemID;                                          //itemID of the item
    public string itemDesc;                                     //itemDesc of the item
    public Sprite itemIcon;                                     //itemIcon of the item
    public GameObject itemModel;                                //itemModel of the item
    public int itemCost = 1;                                   //itemValue is at start 1
    
    public Item(){}

    public Item(string name, int id, string desc, Sprite icon, GameObject model, int cost)                 //function to create a instance of the Item
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemIcon = icon;
        itemModel = model;
        itemCost = cost;
    }

    public void SetProperties (string name, int id, string desc, Sprite icon, GameObject model, int cost) {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemIcon = icon;
        itemModel = model;
        itemCost = cost;
    }

    public Item getCopy()
    {
        return (Item)this.MemberwiseClone();        
    }   
    
    
}


