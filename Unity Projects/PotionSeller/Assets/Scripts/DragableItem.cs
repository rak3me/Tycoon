using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableItem : EventTrigger {
    
    private Vector3 cursorOffset;
    private Transform slotParent;
    private Transform currentSlot;
    private Transform closestSlot;
    private float minDistance = 50;

	// Use this for initialization
	void Start () {
        slotParent = transform.parent;

        while (!slotParent.CompareTag("Slots")) {
            if (slotParent == slotParent.root) break;
            slotParent = slotParent.parent;
        }
        print("Slots: " + slotParent.childCount);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnBeginDrag (PointerEventData eventData) {
//        print("Beginning drag");
        currentSlot = transform.parent;
        closestSlot = currentSlot;
        transform.SetParent(currentSlot.root);
    }

    public override void OnDrag (PointerEventData eventData) {
        //print("Dragging");
        transform.position = Input.mousePosition;
    }

    public override void OnEndDrag (PointerEventData eventData) {
        //print("Ending drag");
        Vector3 mousePosition = Input.mousePosition;

        foreach (Transform slot in slotParent) {
            if (Mathf.Abs(mousePosition.x - slot.position.x) < minDistance &&
                Mathf.Abs(mousePosition.y - slot.position.y) < minDistance) {
                print("Closest slot: " + closestSlot);
                closestSlot = slot;
                break;
            } else {
                print("Mouse position: " + mousePosition + "\tSlot position: " + slot.position);
            }
        }

        if (closestSlot.childCount > 0 && closestSlot != currentSlot) {
            Transform swapItem = closestSlot.GetChild(0);

            swapItem.SetParent(currentSlot);
            swapItem.localPosition = Vector3.zero;
        }

        transform.SetParent(closestSlot);
        transform.localPosition = Vector3.zero;
    }
}
