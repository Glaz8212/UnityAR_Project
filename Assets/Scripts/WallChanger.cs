using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class WallChanger : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public List<Material> wallpaperMaterials;  // 벽지 텍스처 목록
    private int currentWallpaperIndex = 0;  // 현재 선택된 벽지 인덱스
    private List<ARPlane> detectedPlanes = new List<ARPlane>();  // 인식된 Plane 저장

    private void OnEnable()
    {
        arPlaneManager.planesChanged += PlanesChanged;
    }

    private void OnDisable()
    {
        arPlaneManager.planesChanged -= PlanesChanged;
    }

    // Plane이 감지될 때마다
    private void PlanesChanged(ARPlanesChangedEventArgs args)
    {
        // 새로 감지된 Plane을 리스트에 추가
        foreach (var plane in args.added)
        {
            detectedPlanes.Add(plane);
        }
    }

    // 벽지를 순환하여 변경
    public void ChangeWallpaper()
    {
        // 인덱스를 순환시킴
        currentWallpaperIndex = (currentWallpaperIndex + 1) % wallpaperMaterials.Count;

        // 감지된 모든 Plane에 새로운 벽지 적용
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            Renderer renderer = plane.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = wallpaperMaterials[currentWallpaperIndex];  // 벽지 변경
            }
        }
    }
}
