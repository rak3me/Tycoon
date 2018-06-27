using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyHandler : MonoBehaviour {

    public static CurrencyHandler instance;
    private static int instanceCount = 0;

    [SerializeField] private int startingGold = 200; //Gold on new game
    [SerializeField] private int debtLimit = 1000; //The point at which the players loses
    [SerializeField] private float debtInterestRate = 1.5f; //How much the unpaid debt increases every day

    [SerializeField] private int gold;
    [SerializeField] private int debt;
    [SerializeField] private bool overdrawn = false;

	// Use this for initialization
	void Awake () {
        //Singleton
        if (instanceCount++ == 0) {
            instance = this;
        } else {
            Destroy(this);
        }

        gold = startingGold;
	}
	
    public void AttemptPurchase (Item item) {
        int itemCost = item.itemCost;
        if (gold >= itemCost) {
            gold -= itemCost;
        } else {
            debt += (itemCost - gold);
            gold = 0;
        }
        PurchaseItem(item);
    }

    void PurchaseItem (Item item) {
        print("Purchased " + item.itemName + " for " + item.itemCost + " gold.");

    }

    //To be called when a new game is made
    void NewGame () {
        gold = startingGold;
        debt = 0;
        overdrawn = false;
    }

    //Called at the end of every day. Any unpaid debt has an interest
    void CompoundDebt () {
        debt = Mathf.RoundToInt(debt * debtInterestRate);

        CheckDebt();
    }

    //Overdrawing on debt should end the game
    void OnOverdraw () {
        overdrawn = true;
    }

    void CheckDebt () {
        if (debt > debtLimit) {
            OnOverdraw();
        }
    }

    public void OnItemPurchase (int cost) {
        gold -= cost;

        CheckDebt();
    }
}
