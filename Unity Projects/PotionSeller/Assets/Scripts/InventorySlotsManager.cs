using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotsManager : MonoBehaviour {

    public void ClearInventory () {
        foreach (Transform child in transform) {
            if (child.childCount > 0) {
                DestroyImmediate(child.GetChild(0).gameObject);
            }
        }
    }

    public void FillRandom () {
        //List<Item> items = ItemList.GetItemList();
    }
}
