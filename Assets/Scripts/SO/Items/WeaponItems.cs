using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Item", menuName = "Items/Weapon Item")]
public class WeaponItems : Item
{
    [Header("Weapon Pharameters")]
    public ItemsController.PatronsTypes patronsType;
    public float weaponDamage;

}
