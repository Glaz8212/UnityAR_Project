using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorChanger : MonoBehaviour
{
    public GameObject colorPalettePanel;
    private Color selectedColor;
    private bool isColorSelected = false;
    public UIController uicontroller;

    public void SelectColor(string hexColor)
    {
        Debug.Log(" ���� ����");

        Color newColor;
        if (ColorUtility.TryParseHtmlString(hexColor, out newColor))
        {
            selectedColor = newColor;
            isColorSelected = true;

            Debug.Log(selectedColor + "������");

            uicontroller.HidePanel();

            Debug.Log("�г� �����");
        }
        else
        {
            Debug.LogError("Invalid color string: " + hexColor);  // ���� ��ȯ�� �������� ��� �α� �߰�
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0 && isColorSelected)
        {
            Touch touch = Input.GetTouch(0);

            // UI ��ġ �� return
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                return;
            }

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Renderer objectRenderer = hit.transform.GetComponent<Renderer>();

                    if (objectRenderer != null)
                    {
                        objectRenderer.material.color = selectedColor;
                        isColorSelected = false;
                        Debug.Log("������Ʈ �÷�" + selectedColor + "�� ����");
                    }
                }
            }
        }
    }
}
