using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject furnitureTypePanel; // 가구 종류 패널
    public GameObject furnitureListPanel; // 가구 목록 패널

    private void Start()
    {
        furnitureTypePanel.SetActive(false);
        furnitureListPanel.SetActive(false);
    }

    public void TypePanel()
    {
        // 가구 종류 선택 패널
        furnitureTypePanel.SetActive(true);
    }

    public void ListPanel()
    {
        // 종류 선택 후 목록 선택 패널
        furnitureTypePanel.SetActive(false);
        furnitureListPanel.SetActive(true);
    }
}
