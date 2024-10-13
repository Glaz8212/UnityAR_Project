using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject furnitureTypePanel; // ���� ���� �г�
    public GameObject furnitureListPanel; // ���� ��� �г�
    public GameObject furnitureButton;

    private void Start()
    {
        furnitureTypePanel.SetActive(false);
        furnitureListPanel.SetActive(false);
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
        furnitureListPanel.SetActive(true);
    }

    public void HidePanel()
    {
        furnitureListPanel.SetActive(false);
        furnitureTypePanel.SetActive(false);
        furnitureButton.SetActive(true);
    }
}
