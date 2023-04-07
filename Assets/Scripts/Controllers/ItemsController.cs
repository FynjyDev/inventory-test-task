using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    public enum ItemTypes { patrons, weapon, armor }
    public enum PatronsTypes { firstType, secondType }
    public enum ArmorProtectionTypes { body, head}

    public InventoryController inventoryController;
    public List<Item> items;

    public void ChangeItemCount(Item _item, int count)
    {
        if (count < 0 && _item.count <= 0) return;
        inventoryController.OnItemCountChange(_item, count);
    }

    public Item GetItemByName(string _name)
    {
        Item item = new Item();
        for (int i = 0; i < items.Count; i++) if (items[i].itemName == _name) item = items[i];
        return item;
    }

    public List<Item> GetItemsByType(ItemTypes _filter, int count = 1)
    {
        List<Item> _items = new List<Item>();

        for (int i = 0; i < items.Count; i++)
            if (items[i].itemType == _filter)
            {
                if (count > 0 || items[i].count > 0)
                    _items.Add(items[i]);
            }
        return _items;
    }

    public List<Item> GetAllItems(ItemTypes _filter)
    {
        List<Item> _items = new List<Item>();

        for (int i = 0; i < items.Count; i++)
            if (items[i].itemType != _filter) _items.Add(items[i]);

        return _items;
    }
}
