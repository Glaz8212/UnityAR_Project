using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject furnitureTypePanel; // 가구 종류 패널
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
        // 가구 종류 선택 패널
        furnitureTypePanel.SetActive(true);
        furnitureButton.SetActive(false);
        colorButton.SetActive(false);
        wallpaperButton.SetActive(false);
    }

    public void ShowPanel(GameObject panelToShow)
    {
        // 모든 패널 비활성화
        HidePanel();
        furnitureButton.SetActive(false);
        colorButton.SetActive(false);
        wallpaperButton.SetActive(false);
        // 선택된 패널만 활성화
        panelToShow.SetActive(true);
    }

    public void ChairListPanel()
    {
        ShowPanel(chairListPanel);  // Chair 패널 활성화
    }

    public void DeskListPanel()
    {
        ShowPanel(deskListPanel);  // Desk 패널 활성화
    }

    public void EtcListPanel()
    {
        ShowPanel(etcListPanel);  // Etc 패널 활성화
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
