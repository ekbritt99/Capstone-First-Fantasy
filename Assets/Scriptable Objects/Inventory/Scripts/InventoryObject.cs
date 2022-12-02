using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]

public class InventoryObject : ScriptableObject
{
    public string savePath;
    public ItemsDatabaseObject database;
    public InventorySlot[] container = new InventorySlot[24];


    public void AddItem(ItemObject _item, int _amt)
    {
        for(int i = 0; i < container.Length; i++)
        {
            if(container[i].item == _item)
            {
                container[i].AddAmount(_amt);
                return;
            }
        }

        SetEmptySlot(_item, _amt);
    }

    public InventorySlot SetEmptySlot(ItemObject _item, int _amount)
    {
        for (int i = 0; i < container.Length; i++)
        {
            if (container[i].ID <= -1)
            {
                container[i].UpdateSlot(_item.ID, _item, _amount);
                return container[i];
            }
        }

        return null;
    }

    public void OnAfterSerialization()
    {

    }

    [ContextMenu("Save")]
    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }

}