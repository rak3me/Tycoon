using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ShopSlot : MonoBehaviour {

    [Header("Item Info")]
    [SerializeField] private Item item;

    private void Awake () {
        
    }

    void ToggleBuyButton (bool enabled) {
        GameObject buyButton = transform.GetChild(1).gameObject;
        buyButton.SetActive(enabled);
    }

    public void UpdateItem (Item newItem) {
        if (newItem == null) {
            EmptyItemSlot();
            ToggleBuyButton(false);
            return;
        }

        EmptyItemSlot();
        ToggleBuyButton(true);
        PopulateItemSlot(newItem);
    }

    public void EmptyItemSlot () {
        Transform itemHolder = transform.GetChild(0);
        item = null;
        if (itemHolder.childCount > 0) {
            DestroyImmediate(itemHolder.GetChild(0).gameObject);
        }
    }

    public void PopulateItemSlot (Item newItem) {
        item = newItem;
        GameObject itemGO = new GameObject();
        itemGO.name = "Item - " + newItem.itemName;
        itemGO.transform.SetParent(transform.GetChild(0));
        itemGO.transform.localPosition = Vector3.zero;

        Image image = itemGO.AddComponent<Image>();
        image.sprite = newItem.itemIcon;
        image.color = Random.ColorHSV();

        RectTransform rectTransform = itemGO.GetComponent<RectTransform>();
        rectTransform.sizeDelta = Vector2.one * 50;
    }

    public Item GetItem () { return item; }

}
