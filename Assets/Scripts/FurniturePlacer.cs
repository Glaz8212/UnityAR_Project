using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

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

    // 가구 목록 관리
    public Dictionary<string, GameObject> furniturePrefabs = new Dictionary<string, GameObject>();

    // 가구 배치 관련
    private GameObject selectedPrefab;
    private GameObject placedFurniture;

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

            // 가끔씩 터치가 두 번 발생하는 것 같은 경우 발생
            // 터치가 UI에서 발생한 경우 무시
            // 영향을 받는 UI가 있을 경우 True -> Return
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                return;
            }

            // 터치된 위치에 ar plane이 존재하면 가구 배치
            if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinBounds))
            {
                Pose hitPose = hits[0].pose;

                placedFurniture = Instantiate(selectedPrefab, hitPose.position, hitPose.rotation);
                selectedPrefab = null;  // 배치 후 초기화                
            }
        }

        if (placedFurniture != null && Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float rotationSpeed = 0.1f;
                placedFurniture.transform.Rotate(0, touch.deltaPosition.x * rotationSpeed, 0);
            }
        }
    }

    public void SelectFurniture(string furnitureName)
    {
        if (furniturePrefabs.ContainsKey(furnitureName))
        {
            selectedPrefab = furniturePrefabs[furnitureName];
            Debug.Log("가구 선택: " + furnitureName);

            UIController.HidePanel();
            Debug.Log("패널 숨기기");
        }
    }
}
