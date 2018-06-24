using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemWindow : EditorWindow {

    string itemName = "DefaultName";
    string itemDescription = "";
    Sprite itemIcon;
    GameObject itemModel;
    int itemCost = 1;

    [MenuItem("GameObject/Create Item")]
    public static void Init () {
        ItemWindow window = EditorWindow.GetWindow<ItemWindow>("Create Item");
        //Vector2 size = window.position.size;
        window.minSize = new Vector2(300, 200);
        window.maxSize = new Vector2(300, 200);
    }


    private void OnGUI () {
        GUILayout.Label ("Item Properties", EditorStyles.boldLabel);
        itemName = EditorGUILayout.TextField ("Item Name", itemName);
        itemDescription = EditorGUILayout.TextField("Description", itemDescription);
        itemCost = EditorGUILayout.IntSlider("Item Cost", itemCost, 0, 500);
        itemIcon = (Sprite)EditorGUILayout.ObjectField("Item Icon", itemIcon, typeof(Sprite), false);
        itemModel = (GameObject)EditorGUILayout.ObjectField("Item Model", itemModel, typeof(GameObject), false);

        if (GUILayout.Button("Create")) {
            CreateItem();
        }
    }

    private void CreateItem () {
        //new Item(itemName, Random.Range(0, int.MaxValue), itemDescription, itemIcon, itemModel)
        GameObject itemGO = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        //Item item = itemGO.AddComponent<Item>();
        //item = new Item(itemName, Random.Range(0, int.MaxValue), itemDescription, itemIcon, itemModel);

        Object temp = PrefabUtility.CreateEmptyPrefab("Assets/Resources/Prefabs/Items/" + itemName + ".prefab");
        PrefabUtility.ReplacePrefab(itemGO, temp);
        DestroyImmediate(itemGO);
        //AssetDatabase.CreateAsset(new Object(), "Assets/Resources/Prefabs/Items/" + itemName + ".asset");
    }
}