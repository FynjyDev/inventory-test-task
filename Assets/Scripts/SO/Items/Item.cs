using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public Sprite itemIcon;

    [Header("Count Pharameters")]
    public int count;
    public int stackCount;

    [Header("Basic Pharameters")]
    public ItemsController.ItemTypes itemType;
    public string itemName;
    public float itemWeight;
}
