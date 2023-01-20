using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChange : MonoBehaviour
{
    public bool toggled3;
    private Toggle _toggle3;
    public Color selectedColor;


    private void Start()
    {
        _toggle3 = GameObject.FindGameObjectWithTag("Toggle3").GetComponent<Toggle>();
        _toggle3.onValueChanged.AddListener(OnToggle3Changed);
        ColorPicker colorPicker = FindObjectOfType<ColorPicker>();
        colorPicker.OnColorSelect.AddListener(OnColorSelected);


    }
    private void Update()
    {
        ChangeColorOnPlacedObject();
    }
    public void OnColorSelected(Color color)
    {
        selectedColor = color;
    }

    public void OnToggle3Changed(bool isOn)
    {
        if (isOn)
        {
            toggled3 = true;
            GameObject.FindGameObjectWithTag("Toggle3").GetComponent<Toggle>().image.color = Color.green;
                

        }
        else
        {
            toggled3 = false;
            GameObject.FindGameObjectWithTag("Toggle3").GetComponent<Toggle>().image.color = Color.white;
        }
    }
    public void ChangeColorOnPlacedObject()
    {
        if (Input.GetMouseButtonDown(0) && toggled3)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.gameObject.GetComponent<MeshRenderer>().material.name);
                if (hit.transform.gameObject.GetComponent<MeshRenderer>().material.name == "ObjectMaterial (Instance)")
                {
                    hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = selectedColor;
                    DataManager.Instance.UpdateItemColor(hit.transform.gameObject.name, selectedColor);
                }

            }
        }
    }
}
