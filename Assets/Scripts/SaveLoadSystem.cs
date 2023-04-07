using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    public static void Save(List<Item> _itemData, List<InventorySlot> _inventorySlots)
    {
        SaveData _data = new SaveData();

        for (int i = 0; i < _itemData.Count; i++)
        {
            _data.itemName.Add(_itemData[i].itemName);
            _data.itemCount.Add(_itemData[i].count);
        }

        for (int i = 0; i < _inventorySlots.Count; i++)
        {
            _data.slotItemName.Add(_inventorySlots[i].activeItem ? _inventorySlots[i].activeItem.itemName : "null");
            _data.slotItemCount.Add(_inventorySlots[i].itemCount);
        }

        string json = JsonUtility.ToJson(_data, false);

        if (!File.Exists(GetFilePath())) File.Create(GetFilePath());
        File.WriteAllText(GetFilePath(), json);
    }

    public static SaveData Load()
    {
        if (!File.Exists(GetFilePath()))
        {
            File.Create(GetFilePath());
            return null;
        }

        string json = File.ReadAllText(GetFilePath());
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        Debug.Log($"Сохранение загруженно: { GetFilePath() }");

        return data;
    }

    private static string GetFilePath()
    {
        return Application.persistentDataPath + "/Data.json";
    }
}

public class SaveData
{
    public List<string> itemName = new List<string>();
    public List<int> itemCount = new List<int>();

    public List<string> slotItemName = new List<string>();
    public List<int> slotItemCount = new List<int>();
}
