using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FurniturePlacer : MonoBehaviour
{
    [Header("의자 프리팹")]
    public GameObject designChairPrefab;
    public GameObject modernChairPrefab;
    public GameObject officeChairPrefab;
    public GameObject couchPrefab;
    [Space]
    [Header("책상 프리팹")]
    public GameObject computerDeskPrefab;
    public GameObject makeUpDeskPrefab;
    public GameObject modernDeskPrefab;
    public GameObject woodDeskPrefab;
    [Space]
    [Header("기타 프리팹")]
    public GameObject bedPrefab;
    public GameObject bookShelfPrefab;
    public GameObject lampPrefab;

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
        furniturePrefabs.Add("Couch", couchPrefab);

        furniturePrefabs.Add("ComputerDesk", computerDeskPrefab);
        furniturePrefabs.Add("MakeUpDesk", makeUpDeskPrefab);
        furniturePrefabs.Add("ModernDesk", modernDeskPrefab);
        furniturePrefabs.Add("WoodDesk", woodDeskPrefab);

        furniturePrefabs.Add("Bed", bedPrefab);
        furniturePrefabs.Add("BookShelf", bookShelfPrefab);
        furniturePrefabs.Add("Lamp", lampPrefab);
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
