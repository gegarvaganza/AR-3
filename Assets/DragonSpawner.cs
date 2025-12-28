using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DragonSpawner : MonoBehaviour
{
    public GameObject dragonPrefab;

    private ARTrackedImageManager imageManager;
    private GameObject spawnedDragon;

    void Awake()
    {
        imageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        imageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var img in args.added)
        {
            if (spawnedDragon == null)
            {
                spawnedDragon = Instantiate(
                    dragonPrefab,
                    img.transform
                );

                spawnedDragon.transform.localPosition = Vector3.zero;
                spawnedDragon.transform.localRotation = Quaternion.identity;
            }
        }
    }
}
