using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemList : ScriptableObject {

    public static string path = "Assets/Resources/Prefabs/Items/ItemList.asset";
    public List<Item> items;

    public void AddItem (Item item) {
        AddItem(item.itemName, item.itemID, item.itemDesc, item.itemIcon, item.itemModel, item.itemCost);
    }

    public void AddItem (string name, int id, string desc, Sprite icon, GameObject model, int cost) {
        //Item item = ScriptableObject.CreateInstance<Item>();
        items.Add(new Item(name, id, desc, icon, model, cost));
    }

    public Item FindItemByID (int id) {
        foreach (var item in items) {
            if (item.itemID == id) {
                return item;
            }
        }
        return null;
    }

    public Item FindItemByName (string name) {
        foreach (var item in items) {
            if (item.itemName == name) {
                return item;
            }
        }
        return null;
    }

    public static ItemList GetAsset () {
        return (ItemList)(AssetDatabase.LoadAssetAtPath(path, typeof(ItemList)));
    }
}
