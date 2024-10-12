using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject furnitureTypePanel; // ���� ���� �г�
    public GameObject furnitureListPanel; // ���� ��� �г�

    private void Start()
    {
        furnitureTypePanel.SetActive(false);
        furnitureListPanel.SetActive(false);
    }

    public void TypePanel()
    {
        // ���� ���� ���� �г�
        furnitureTypePanel.SetActive(true);
    }

    public void ListPanel()
    {
        // ���� ���� �� ��� ���� �г�
        furnitureTypePanel.SetActive(false);
        furnitureListPanel.SetActive(true);
    }
}
