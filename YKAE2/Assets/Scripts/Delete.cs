using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delete : MonoBehaviour
{
    public bool toggled2;

    private Toggle _toggle2;


    private void Start()
    {
        _toggle2 = GameObject.FindGameObjectWithTag("Toggle2").GetComponent<Toggle>();
        _toggle2.onValueChanged.AddListener(OnToggle2Changed);
    }
    private void Update()
    {
        DeleteObject();
    }

    public void OnToggle2Changed(bool isOn)
    {
        if(isOn)
        {
            toggled2 = true;
            GameObject.FindGameObjectWithTag("Toggle2").GetComponent<Toggle>().image.color = Color.green;
        }
        else
        {
            toggled2 = false;
            GameObject.FindGameObjectWithTag("Toggle2").GetComponent<Toggle>().image.color = Color.white;
        }
    }
    public void DeleteObject()
    {
        if (Input.GetMouseButtonDown(0) && toggled2)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.gameObject.GetComponent<MeshRenderer>().material.name);
                if (hit.transform.gameObject.GetComponent<MeshRenderer>().material.name == "ObjectMaterial (Instance)")
                {
                    DataManager.Instance.RemoveItem(hit.transform.gameObject.name);
                    Destroy(hit.transform.gameObject);
                }

            }
        }
    }


}
