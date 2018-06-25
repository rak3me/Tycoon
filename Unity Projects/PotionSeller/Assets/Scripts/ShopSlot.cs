using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ShopSlot : MonoBehaviour {

    [Header("Item Info")]
    [SerializeField] private Item item;

    private void Awake () {
        
    }

    public void UpdateItem (Item newItem) {
        if (newItem.itemID == item.itemID) {
            return;
        }

        item = newItem;

        EmptyItemSlot();
        PopulateItemSlot(newItem);
    }

    public void EmptyItemSlot () {
        if (transform.childCount > 0) {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

    public void PopulateItemSlot (Item newItem) {
        GameObject itemGO = new GameObject();
        itemGO.name = "Item - " + newItem.itemName;
        itemGO.transform.SetParent(transform);
        itemGO.transform.localPosition = Vector3.zero;

        Image image = itemGO.AddComponent<Image>();
        image.sprite = newItem.itemIcon;
        image.color = Random.ColorHSV();

        RectTransform rectTransform = itemGO.GetComponent<RectTransform>();
        rectTransform.sizeDelta = Vector2.one * 50;
    }

}
