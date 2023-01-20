using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public static Placement Instance { private set; get; }
    public Color selectedColor;
    public string selectedId;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ColorPicker colorPicker = FindObjectOfType<ColorPicker>();
        colorPicker.OnColorSelect.AddListener(OnColorSelected);
    }
   

    public void OnColorSelected(Color color)
    {
        selectedColor = color;
        //Debug.Log("Selected color:." + selectedColor);
    }


    public void InitializeObjects()
    {
        //Debug.Log("Selected color:." + selectedColor);
        Vector3 position = new Vector3(0, 0.5f, 0);
        GameObject obj = Instantiate(PrefabDataBase.Instance.RequestPrefab(selectedId), position, Quaternion.identity);
        obj.GetComponent<MeshRenderer>().material.color = selectedColor;
        DataManager.Instance.AddItem(obj);
    }
}
