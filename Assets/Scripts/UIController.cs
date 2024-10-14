using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject furnitureTypePanel; // ���� ���� �г�
    public GameObject chairListPanel;
    public GameObject deskListPanel;
    public GameObject etcListPanel;
    public GameObject colorPalettePanel;

    public GameObject furnitureButton;
    public GameObject colorButton;
    public GameObject wallpaperButton;

    private void Start()
    {
        furnitureTypePanel.SetActive(false);
        chairListPanel.SetActive(false);
        deskListPanel.SetActive(false);
        etcListPanel.SetActive(false);
        colorPalettePanel.SetActive(false);
    }

    public void TypePanel()
    {
        // ���� ���� ���� �г�
        furnitureTypePanel.SetActive(true);
        furnitureButton.SetActive(false);
        colorButton.SetActive(false);
        wallpaperButton.SetActive(false);
    }

    public void ShowPanel(GameObject panelToShow)
    {
        // ��� �г� ��Ȱ��ȭ
        HidePanel();
        furnitureButton.SetActive(false);
        colorButton.SetActive(false);
        wallpaperButton.SetActive(false);
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

    public void ShowColorPalette()
    {
        ShowPanel(colorPalettePanel);
    }

    public void HidePanel()
    {
        chairListPanel.SetActive(false);
        deskListPanel.SetActive(false);
        etcListPanel.SetActive(false);
        colorPalettePanel.SetActive(false);
        furnitureTypePanel.SetActive(false);
        furnitureButton.SetActive(true); 
        colorButton.SetActive(true);
        wallpaperButton.SetActive(true);
    }
}
