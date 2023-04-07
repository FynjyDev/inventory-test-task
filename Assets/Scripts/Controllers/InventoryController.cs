using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public InventorySettings inventorySettings;
    public SaveLoadManager saveLoadManager;
    public ItemsController itemsController;
    public List<InventorySlot> slots;

    private void Awake()
    {
        for (int i = slots.Count - 1; i >= inventorySettings.lockSlotsCount; i--)
        {
            slots[i].isLock = true;
            slots[i].UpdateSlot();
        }

        saveLoadManager.LoadData(this, itemsController);
    }

    public void OnItemCountChange(Item _item, int count)
    {
        InventorySlot _slot = count > 0 ? GetFreeSlot(_item) : GetSlotWithItem(_item);

        if (!_slot) { Debug.Log("У вас нет места для этого предмета"); return; }

        if (count > 0)
        {
            if (_slot.itemCount + count <= _item.stackCount)
            {
                _slot.OnItemAdd(_item, count);
            }
            else
            { 
                CreateNewStack(_item, count);
                return;
            }      
        }
        else _slot.OnItemRemove(_item, count);

        saveLoadManager.SaveData(this, itemsController);

        Debug.Log($"Изменено кол-во предмета: {_item.name} на {count} едениц");
    }

    private void CreateNewStack(Item _item, int count)
    {
        InventorySlot _slot = GetFreeSlot(_item, false);

        if (!_slot)
        {
            Debug.Log("У вас нет места для этого предмета");
            return;
        }

        _slot.OnItemAdd(_item, count);
    }

    public void DeleteRandomSlot()
    {
        List<InventorySlot> _busySlots = GetAllBusySlots();

        if (_busySlots.Count == 0) { Debug.Log("У вас нет предметов"); return; }
        else
        {
            InventorySlot _slot = _busySlots[Random.Range(0, _busySlots.Count)];

            _slot.OnItemRemove(_slot.activeItem, -_slot.itemCount);
            saveLoadManager.SaveData(this, itemsController);

            Debug.Log($"Удалены предметы из ячейки №{slots.IndexOf(_slot) + 1}");
        }
    }

    private List<InventorySlot> GetAllBusySlots()
    {
        List<InventorySlot> _busySlots = new List<InventorySlot>();

        for (int i = 0; i < slots.Count; i++)
            if (slots[i].activeItem)
                _busySlots.Add(slots[i]);

        return _busySlots;
    }

    private InventorySlot GetFreeSlot(Item _item, bool tryFindBusy = true)
    {
        if (tryFindBusy)
        {
            InventorySlot _slot = GetSlotWithItem(_item);
            if (_slot != null) return _slot;
        }

        for (int i = 0; i < slots.Count; i++)
            if (slots[i].activeItem == null && !slots[i].isLock)
                return slots[i];

        return null;
    }

    private InventorySlot GetSlotWithItem(Item _item, bool checkForBusy = true)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].activeItem == _item && !slots[i].isLock)
            {
                if (checkForBusy)
                    if (slots[i].itemCount < slots[i].activeItem.stackCount)return slots[i];
                else return slots[i];
            }
        }
        return null;
    }
}
