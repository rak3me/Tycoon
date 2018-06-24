using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyHandler : MonoBehaviour {

    [SerializeField] private int startingGold = 200; //Gold on new game
    [SerializeField] private int debtLimit = 1000; //The point at which the players loses
    [SerializeField] private float debtInterestRate = 1.5f; //How much the unpaid debt increases every day

    private int gold;
    private int debt;
    private bool overdrawn = false;

	// Use this for initialization
	void Awake () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
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
