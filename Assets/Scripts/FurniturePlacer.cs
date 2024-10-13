using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FurniturePlacer : MonoBehaviour
{
    // 가구 프리팹 관리
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
        Debug.Log("DICTIONARY에 프리팹 추가");
        furniturePrefabs.Add("DesignChair", designChairPrefab);
        furniturePrefabs.Add("ModernChair", modernChairPrefab);
        furniturePrefabs.Add("OfficeChair", officeChairPrefab);
    }

    private void Update()
    {
        if (Input.touchCount > 0 && selectedPrefab != null)
        {
            Debug.Log("버튼 입력");
            Touch touch = Input.GetTouch(0);

            // 터치된 위치에 ar plane이 존재하면 가구 배치
            if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinBounds))
            {
                Pose hitPose = hits[0].pose;

                Instantiate(selectedPrefab, hitPose.position, hitPose.rotation);
                selectedPrefab = null;  // 배치 후 초기화
            }
        }
    }

    public void SelectFurniture(string furnitureName)
    {
        Debug.Log("Select 시작: " + furnitureName);
        if (furniturePrefabs.ContainsKey(furnitureName))
        {
            selectedPrefab = furniturePrefabs[furnitureName];
            Debug.Log("가구 선택: " + furnitureName);

            UIController.HidePanel();
            Debug.Log("패널 숨기기");
        }
    }
}
