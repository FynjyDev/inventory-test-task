using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public ItemsController itemsController;
    public InventoryController inventoryController;

    public void ShootButtonCallback()
    {
        List<Item> _items = itemsController.GetItemsByType(ItemsController.ItemTypes.patrons , -1);

        if (_items.Count == 0)
        {
            Debug.Log("” вас нет патронов данного типа дл€ выстрела");
            return;
        }

        itemsController.ChangeItemCount(_items[Random.Range(0, _items.Count)], -1);
    }

    public void AddPatronsButtonCallback()
    {
        List<Item> _items = itemsController.GetItemsByType(ItemsController.ItemTypes.patrons);

        for (int i = 0; i < _items.Count; i++)
        {
            itemsController.ChangeItemCount(_items[i], _items[i].stackCount);
        }
    }

    public void AddRandomItemButtonCallback()
    {
        List<Item> _items = itemsController.GetAllItems(ItemsController.ItemTypes.patrons);
        itemsController.ChangeItemCount(_items[Random.Range(0, _items.Count)], 1);
    }

    public void RemoveRandomItemButtonCallback()
    {
        itemsController.inventoryController.DeleteRandomSlot();
    }
}
