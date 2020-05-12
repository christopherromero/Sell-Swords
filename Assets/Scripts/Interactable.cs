using UnityEngine;

// Base class for interactable objects
public class Interactable : MonoBehaviour
{
    // distance how close player has to be to interact with object
    public float radius = 3f;

    // Handles direction of interactable object and moving towards 'front'
    public Transform interactionTransform;

    bool isFocus = false;

    // Allows player to move(transform position) to object
    Transform player;

    // Monitors if player has interacted with object already
    bool hasInteracted = false;

    public virtual void Interact()
    {
        // no implementation, done in child classes
        //Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            // Calculates distance to focused object 
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    // Monitors if player is interacting with currect object
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    // Monitors if player has defocused current object
    public void OnDeFocus()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    // draws interactable area of player
    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
