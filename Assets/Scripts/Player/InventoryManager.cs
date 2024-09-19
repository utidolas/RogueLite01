using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<WeaponBase> weaponSlots = new List<WeaponBase>(5);
    public int[] weaponLevel = new int[5];

    public void AddWeapon(int slotIndex, WeaponBase weapon)
    {
        weaponSlots[slotIndex] = weapon;
    }
}
