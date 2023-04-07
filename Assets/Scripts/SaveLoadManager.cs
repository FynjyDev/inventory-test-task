using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public void LoadData(InventoryController inventoryController, ItemsController itemsController)
    {
        SaveData data = SaveLoadSystem.Load();

        if (data == null)
        {
            SaveData(inventoryController, itemsController);
            return;
        }

        for (int i = 0; i < data.itemName.Count; i++)
            for (int j = 0; j < itemsController.items.Count; j++)
                if (itemsController.items[j].itemName == data.itemName[i])
                    itemsController.items[j].count = data.itemCount[i];

        for (int i = 0; i < data.slotItemName.Count; i++)
            for (int j = 0; j < inventoryController.slots.Count; j++)
                if (inventoryController.slots[i].isLock) return;
                else if (data.slotItemName[i] != "null")
                {
                    inventoryController.slots[i].activeItem = itemsController.GetItemByName(data.slotItemName[i]);
                    inventoryController.slots[i].itemCount = data.slotItemCount[i];
                    inventoryController.slots[i].UpdateSlot();
                }
                else inventoryController.slots[i].UpdateSlot(true);

    }

    public void SaveData(InventoryController inventoryController, ItemsController itemsController)
    {
        SaveLoadSystem.Save(itemsController.items, inventoryController.slots);
    }
}
