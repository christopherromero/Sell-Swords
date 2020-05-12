using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{

    public SkinnedMeshRenderer mesh;
    public EquipmentSlot equipSlot;
    public EquipmentMeshRegion[] coveredMeshRegion;
    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        // Equip the item to player
        EquipmentManager.instance.Equip(this);

        // Remove the item from the inventory
        this.RemoveFromInventory();
    }



}

public enum EquipmentSlot { Head, Chest, Legs, Weapons, Shield, Feet, MagicStone }
public enum EquipmentMeshRegion { Legs, Arms, Torso };  //Corresponds to body blendshapes