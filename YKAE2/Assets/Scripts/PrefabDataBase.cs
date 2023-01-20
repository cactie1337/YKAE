using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrefabDataBase : MonoBehaviour
{
    public static PrefabDataBase Instance { private set; get; }

    private void Awake()
    {
        Instance = this;
    }

    public List<PrefabItem> prefabItems = new List<PrefabItem>();


    public GameObject RequestPrefab(string prefab_id)
    {
        PrefabItem prefabItem = prefabItems.Where(p => p.prefab_ID == prefab_id).First();
        return prefabItem.prefab_gameObject;
    }


}

[System.Serializable]
public class PrefabItem
{
    public GameObject prefab_gameObject;
    public string prefab_ID;
}
