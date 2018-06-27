using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(ShopSlot))]
public class ShopSlotEditor : Editor {

    ShopSlot shopSlot;
    List<string> itemListNames;
    Item currentItem;
    Item lastItem;
    int currentItemIndex;
    int dropdownIndex;
    int lastDropdownIndex;

    public override void OnInspectorGUI () {
        GUI.enabled = false;
        base.OnInspectorGUI();
        GUI.enabled = true;

        shopSlot = (ShopSlot)target;

        UpdateItemListNames();

        if (itemListNames.Count == 0) {
            return;
        }
        dropdownIndex = EditorGUILayout.Popup("Item", dropdownIndex, itemListNames.ToArray());

        if (dropdownIndex == lastDropdownIndex) {
            lastDropdownIndex = dropdownIndex;
            return;
        }

        if (dropdownIndex > 0) {
            currentItemIndex = dropdownIndex - 1;
            currentItem = ItemList.GetAsset().items[currentItemIndex];
            shopSlot.UpdateItem(currentItem);
        } else {
            currentItem = null;
            shopSlot.UpdateItem(null);
        }

        lastDropdownIndex = dropdownIndex;
    }

    private void UpdateItemListNames () {
        itemListNames = new List<string>(new string[]{"None"});

        foreach (var item in ItemList.GetAsset().items) {
            itemListNames.Add(item.itemName);
        }
    }
}
