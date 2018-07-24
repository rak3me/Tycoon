using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseItem : MonoBehaviour {

    Item item;
    CurrencyHandler currencyHandler;

    private void Start () {
        currencyHandler = CurrencyHandler.instance;
    }

    public void OnItemPurchase () {
        item = GetComponent<ShopSlot>().GetItem();

        if (item != null) {
            currencyHandler.AttemptPurchase(item);
        }
    }
}
