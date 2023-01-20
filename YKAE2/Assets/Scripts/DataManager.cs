using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; set; }
    public ItemDB ItemDB;
    void Start()
    {
        Instance = this;
    }
    public void AddItem(GameObject obj)
    {
        Item item = new Item();
        item.PrefabID = Placement.Instance.selectedId;
        item.ItemID = item.PrefabID + ItemDB.items.Count + ToString();
        obj.name = item.ItemID;
        item.Position = obj.transform.position;
        item.color = obj.GetComponent<MeshRenderer>().material.color;
        ItemDB.items.Add(item);
    }
    public void UpdateItemPosition(string itemId, Vector3 position)
    {
        Item item = ItemDB.items.Where(p => p.ItemID == itemId).First();

        item.Position = position;
    }
    public void UpdateItemColor(string itemId, Color color)
    {
        Item item = ItemDB.items.Where(p => p.ItemID == itemId).First();

        item.color = color;
    }

    public void RemoveItem(string itemId)
    {
        Item item = ItemDB.items.Where(p => p.ItemID == itemId).First();
        ItemDB.items.Remove(item);
    }

    public void SaveData(int slot)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(ItemDB));
        FileStream stream = new FileStream(Application.dataPath + "/StreamFiles/Game_data"+slot+".xml", FileMode.Create);
        xmlSerializer.Serialize(stream, ItemDB);
        stream.Close();
    }

    /// <summary>
    /// This is getting called on my load game buttons
    /// </summary>
    public void LoadData(int slot)
    {
        if (!File.Exists(Application.dataPath + "/StreamFiles/Game_data"+slot+".xml")) return;
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(ItemDB));
        FileStream stream = new FileStream(Application.dataPath + "/StreamFiles/Game_data"+slot+".xml", FileMode.Open);
        ItemDB = xmlSerializer.Deserialize(stream) as ItemDB;
        stream.Close();

        foreach(Item item in ItemDB.items)
        {
            GameObject obj = Instantiate(PrefabDataBase.Instance.RequestPrefab(item.PrefabID), item.Position, Quaternion.identity);
            obj.transform.name = item.ItemID;
            obj.GetComponent<MeshRenderer>().material.color = item.color;
        }
    }
    /// <summary>
    /// Don't know why my Data loads before the scene resets.
    /// I've tried Async and making Coroutines, still didn't work :/
    /// this method is here just to show that I think I have the idea of how
    /// the loading should work
    /// </summary>
    public void LoadGame(int slot)
    {
        // load the scene
        // load the data from my xml file

        //SceneManager.LoadScene("SampleScene");
        //LoadData(slot);
        
    }
    

}


[System.Serializable]
public class ItemDB
{
    public List<Item> items = new List<Item>();
}

[System.Serializable]
public class Item
{
    public string PrefabID;
    public string ItemID;
    public Vector3 Position;
    public Color color;
}
