using UnityEngine;

[CreateAssetMenu(fileName = "Armor Item", menuName = "Items/Armor Item")]
public class ArmorItems : Item
{
    [Header("Armor Pharameters")]
    public ItemsController.ArmorProtectionTypes armorProtectionType;
    public float armorProtection;
}
