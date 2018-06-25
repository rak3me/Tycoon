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
    int dropdownIndex;

    public override void OnInspectorGUI () {
        GUI.enabled = false;
        base.OnInspectorGUI();
        GUI.enabled = true;

        shopSlot = (ShopSlot)target;
        UpdateItemListNames();

        currentItem = ItemList.GetAsset().items[dropdownIndex = EditorGUILayout.Popup("Item", dropdownIndex, itemListNames.ToArray())];

        shopSlot.UpdateItem(currentItem);

        if (lastItem != currentItem) {
            lastItem = currentItem;
        }
    }

    private void UpdateItemListNames () {
        itemListNames = new List<string>(0);

        foreach (var item in ItemList.GetAsset().items) {
            itemListNames.Add(item.itemName);
        }
    }
}
