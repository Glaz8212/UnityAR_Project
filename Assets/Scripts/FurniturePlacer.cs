using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FurniturePlacer : MonoBehaviour
{
    // ���� ������ ����
    public GameObject designChairPrefab;  
    public GameObject modernChairPrefab;  
    public GameObject officeChairPrefab; 

    public Dictionary<string, GameObject> furniturePrefabs = new Dictionary<string, GameObject>();

    private GameObject selectedPrefab;

    public ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public UIController UIController;

    private void Start()
    {
        furniturePrefabs.Add("DesignChair", designChairPrefab);
        furniturePrefabs.Add("ModernChair", modernChairPrefab);
        furniturePrefabs.Add("OfficeChair", officeChairPrefab);
    }

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

                    UIController.HidePanel();
                }
            }
        }
    }

    public void SelectFurniture(string furnitureName)
    {
        if (furniturePrefabs.ContainsKey(furnitureName))
        {
            selectedPrefab = furniturePrefabs[furnitureName];
        }
    }
}
