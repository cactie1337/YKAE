using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject _savePanel;
    [SerializeField]
    GameObject _loadPanel;

    public void openSavePanel()
    {
        _savePanel.SetActive(true);
    }
    public void closeSavePanel()
    {
        _savePanel.SetActive(false);
    }
    public void openLoadPanel()
    {
        _loadPanel.SetActive(true);
    }
    public void closeLoadPanel()
    {
        _loadPanel.SetActive(false);
    }


    public void ChangeSelection(string _id)
    {
        Placement.Instance.selectedId = _id;
    }
}
