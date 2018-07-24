using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InventorySlotsManager))]
public class InventorySlotsManagerEditor : Editor {

    public override void OnInspectorGUI () {
        InventorySlotsManager instance = (InventorySlotsManager)target;

        base.OnInspectorGUI ();

        if (GUILayout.Button("Clear Inventory")) {
            instance.ClearInventory();
        }

        if (GUILayout.Button("Fill Inventory Random")) {
            instance.FillRandom();
        }
    }
}
