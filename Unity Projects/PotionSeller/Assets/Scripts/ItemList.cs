using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemList : ScriptableObject {

    public static string path = "Assets/Resources/Prefabs/Items/ItemList.asset";
    public List<Item> items;

    public void AddItem (Item item) {
        AddItem(item.itemName, item.itemDesc, item.itemIcon, item.itemModel, item.itemCost);
    }

    public void AddItem (string name, string desc, Sprite icon, GameObject model, int cost) {
        //Item item = ScriptableObject.CreateInstance<Item>();
        items.Add(new Item(name, GenerateID(), desc, icon, model, cost));
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

    public int GenerateID () {
        int id;
        bool valid = true;
        do {
            id = Random.Range(0, int.MaxValue);

            foreach (var item in items) {
                if (item.itemID == id) {
                    valid = false;
                }
            }
        } while (!valid);

        return id;
    }
}
