using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class FurniturePlacer : MonoBehaviour
{
    [Header("���� ������")]
    public GameObject designChairPrefab;
    public GameObject modernChairPrefab;
    public GameObject officeChairPrefab;
    public GameObject couchPrefab;
    [Space]
    [Header("å�� ������")]
    public GameObject computerDeskPrefab;
    public GameObject makeUpDeskPrefab;
    public GameObject modernDeskPrefab;
    public GameObject woodDeskPrefab;
    [Space]
    [Header("��Ÿ ������")]
    public GameObject bedPrefab;
    public GameObject bookShelfPrefab;
    public GameObject lampPrefab;

    // ���� ��� ����
    public Dictionary<string, GameObject> furniturePrefabs = new Dictionary<string, GameObject>();

    // ���� ��ġ ����
    private GameObject selectedPrefab;
    private GameObject placedFurniture;

    public ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public UIController UIController;


    private void Start()
    {
        Debug.Log("DICTIONARY�� ������ �߰�");
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
            Debug.Log("��ư �Է�");
            Touch touch = Input.GetTouch(0);

            // ������ ��ġ�� �� �� �߻��ϴ� �� ���� ��� �߻�
            // ��ġ�� UI���� �߻��� ��� ����
            // ������ �޴� UI�� ���� ��� True -> Return
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                return;
            }

            // ��ġ�� ��ġ�� ar plane�� �����ϸ� ���� ��ġ
            if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinBounds))
            {
                Pose hitPose = hits[0].pose;

                placedFurniture = Instantiate(selectedPrefab, hitPose.position, hitPose.rotation);
                selectedPrefab = null;  // ��ġ �� �ʱ�ȭ                
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
            Debug.Log("���� ����: " + furnitureName);

            UIController.HidePanel();
            Debug.Log("�г� �����");
        }
    }
}
