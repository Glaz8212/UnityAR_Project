using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject furnitureTypePanel; // ���� ���� �г�
    public GameObject chairListPanel; // ���� ��� �г�
    public GameObject 
    public GameObject furnitureButton;

    private void Start()
    {
        furnitureTypePanel.SetActive(false);
        chairListPanel.SetActive(false);
    }

    public void TypePanel()
    {
        // ���� ���� ���� �г�
        furnitureTypePanel.SetActive(true);
        furnitureButton.SetActive(false);
    }

    public void ListPanel()
    {
        // ���� ���� �� ��� ���� �г�
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
