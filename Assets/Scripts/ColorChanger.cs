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
        Debug.Log(" 색상 선택");

        Color newColor;
        if (ColorUtility.TryParseHtmlString(hexColor, out newColor))
        {
            selectedColor = newColor;
            isColorSelected = true;

            Debug.Log(selectedColor + "색상선택");

            uicontroller.HidePanel();

            Debug.Log("패널 숨기기");
        }
        else
        {
            Debug.LogError("Invalid color string: " + hexColor);  // 색상 변환이 실패했을 경우 로그 추가
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0 && isColorSelected)
        {
            Touch touch = Input.GetTouch(0);

            // UI 터치 시 return
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
                        Debug.Log("오브젝트 컬러" + selectedColor + "로 변경");
                    }
                }
            }
        }
    }
}
