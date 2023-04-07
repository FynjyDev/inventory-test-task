using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [NonSerialized] public Item activeItem;
    [NonSerialized] public int itemCount;
    [NonSerialized] public bool isLock;

    public InventoryController inventoryController;
    public Image itemIcon;
    public TextMeshProUGUI nameLabel, countLabel;

    public void OnItemAdd(Item _item, int count)
    {
        activeItem = _item;
        _item.count += count;
        itemCount += count;

        UpdateSlot();
    }

    public void OnItemRemove(Item _item, int count)
    {
        itemCount += count;
        _item.count += count;
        countLabel.text = itemCount.ToString();

        if (itemCount <= 0) UpdateSlot(true);
    }

    public void UpdateSlot(bool setNull = false)
    {
        if (setNull)
        {
            itemIcon.sprite = null;
            activeItem = null;
            nameLabel.text = "";
            countLabel.text = "";
            return;
        }
        if (isLock)
        {
            itemIcon.sprite = inventoryController.inventorySettings.lockIcon;
            nameLabel.text = inventoryController.inventorySettings.unlockSlotPrice.ToString();
            return;
        }

        countLabel.text = itemCount.ToString();
        nameLabel.text = activeItem.itemName;
        itemIcon.sprite = activeItem.itemIcon;
    }
}
