using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject furnitureTypePanel; // ���� ���� �г�
    public GameObject chairListPanel;
    public GameObject deskListPanel;
    public GameObject etcListPanel;
    public GameObject furnitureButton;

    private void Start()
    {
        furnitureTypePanel.SetActive(false);
        chairListPanel.SetActive(false);
        deskListPanel.SetActive(false);
        etcListPanel.SetActive(false);
    }

    public void TypePanel()
    {
        // ���� ���� ���� �г�
        furnitureTypePanel.SetActive(true);
        furnitureButton.SetActive(false);
    }

    public void ShowPanel(GameObject panelToShow)
    {
        // ��� �г� ��Ȱ��ȭ
        HidePanel();
        // ���õ� �гθ� Ȱ��ȭ
        panelToShow.SetActive(true);
    }

    public void ChairListPanel()
    {
        ShowPanel(chairListPanel);  // Chair �г� Ȱ��ȭ
    }

    public void DeskListPanel()
    {
        ShowPanel(deskListPanel);  // Desk �г� Ȱ��ȭ
    }

    public void EtcListPanel()
    {
        ShowPanel(etcListPanel);  // Etc �г� Ȱ��ȭ
    }
    public void HidePanel()
    {
        chairListPanel.SetActive(false);
        deskListPanel.SetActive(false);
        etcListPanel.SetActive(false);
        furnitureTypePanel.SetActive(false);
        furnitureButton.SetActive(true);
    }
}
