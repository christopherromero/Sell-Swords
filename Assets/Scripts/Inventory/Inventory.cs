using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region  Singleton
    // Singleton pattern for Inventory
    // Ensures only 1 instance of Inventory at one time
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    // Create a delegate, which is a subscribable event
    public delegate void OnItemChanged();

    // Allows for subscribing to Inventory changes
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public int space = 20;

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }

            items.Add(item);
            // Triggering event so UI updates
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
        return true;

    }

    public void Remove(Item item)
    {
        items.Remove(item);
        // Triggering event so UI updates
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }


}
