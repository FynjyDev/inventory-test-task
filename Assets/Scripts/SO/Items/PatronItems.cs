using UnityEngine;

[CreateAssetMenu(fileName = "Patron Item", menuName = "Items/Patron Item")]
public class PatronItems : Item
{
    [Header("Patron Pharameters")]
    public ItemsController.PatronsTypes patronsType;
}
