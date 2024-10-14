using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class WallChanger : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public List<Material> wallpaperMaterials;  // ���� �ؽ�ó ���
    private int currentWallpaperIndex = 0;  // ���� ���õ� ���� �ε���
    private List<ARPlane> detectedPlanes = new List<ARPlane>();  // �νĵ� Plane ����

    private void OnEnable()
    {
        arPlaneManager.planesChanged += PlanesChanged;
    }

    private void OnDisable()
    {
        arPlaneManager.planesChanged -= PlanesChanged;
    }

    // Plane�� ������ ������
    private void PlanesChanged(ARPlanesChangedEventArgs args)
    {
        // ���� ������ Plane�� ����Ʈ�� �߰�
        foreach (var plane in args.added)
        {
            detectedPlanes.Add(plane);
        }
    }

    // ������ ��ȯ�Ͽ� ����
    public void ChangeWallpaper()
    {
        // �ε����� ��ȯ��Ŵ
        currentWallpaperIndex = (currentWallpaperIndex + 1) % wallpaperMaterials.Count;

        // ������ ��� Plane�� ���ο� ���� ����
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            Renderer renderer = plane.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = wallpaperMaterials[currentWallpaperIndex];  // ���� ����
            }
        }
    }
}
