using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject furnitureTypePanel; // 가구 종류 패널
    public GameObject chairListPanel; // 가구 목록 패널
    public GameObject 
    public GameObject furnitureButton;

    private void Start()
    {
        furnitureTypePanel.SetActive(false);
        chairListPanel.SetActive(false);
    }

    public void TypePanel()
    {
        // 가구 종류 선택 패널
        furnitureTypePanel.SetActive(true);
        furnitureButton.SetActive(false);
    }

    public void ListPanel()
    {
        // 종류 선택 후 목록 선택 패널
        furnitureTypePanel.SetActive(false);
        chairListPanel.SetActive(true);
    }

    public void HidePanel()
    {
        chairListPanel.SetActive(false);
        furnitureTypePanel.SetActive(false);
        furnitureButton.SetActive(true);
    }
}
