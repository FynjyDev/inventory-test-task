using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Settings", menuName = "Settings/Inventory Settings")]

public class InventorySettings : ScriptableObject
{
    [Header("Lock Slots Pharameters")]

    public Sprite lockIcon;

    [Range(0, 30)]
    public int lockSlotsCount;
    public float unlockSlotPrice;

}
