using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    void Pickup()
    {
        Debug.Log("Picking up " + item.name);

        // Add item to inventory
        bool wasPickedUp = Inventory.instance.Add(item);

        // Destroy Game object from scene
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }

}
