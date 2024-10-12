using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FurniturePlacer : MonoBehaviour
{
    public GameObject designChairPrefab;
    public GameObject modernChairPrefab;
    public GameObject officeChairPrefab;

    private GameObject selectedPrefab;

    public ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // ��ġ�� ��ġ�� ar plane�� �����ϸ� ���� ��ġ
            if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinBounds))
            {
                Pose hitPose = hits[0].pose;

                if (selectedPrefab != null)
                {
                    Instantiate(selectedPrefab, hitPose.position, hitPose.rotation);
                    selectedPrefab = null;  // ��ġ �� �ʱ�ȭ
                }
            }
        }
    }

    public void SelectDesignChair()
    {
        selectedPrefab = designChairPrefab;
    }

    public void SelectModernChair()
    {
        selectedPrefab = modernChairPrefab;
    }

    public void SelectOfficeChair()
    {
        selectedPrefab = officeChairPrefab;
    }
}
