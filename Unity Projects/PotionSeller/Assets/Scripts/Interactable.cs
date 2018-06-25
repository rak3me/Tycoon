
using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;

    private bool isFocus = false;
    private bool hasInteracted = false;
    private Transform player;

    public virtual void Interact ()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    void Update ()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused ()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
