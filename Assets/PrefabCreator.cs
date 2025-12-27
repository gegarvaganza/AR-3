using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class PrefabCreator : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public GameObject prefabToSpawn;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            GameObject obj = Instantiate(prefabToSpawn, trackedImage.transform);
            spawnedPrefabs[trackedImage.referenceImage.name] = obj;
        }

        foreach (var trackedImage in args.updated)
        {
            if (spawnedPrefabs.TryGetValue(trackedImage.referenceImage.name, out GameObject obj))
            {
                obj.SetActive(trackedImage.trackingState == TrackingState.Tracking);
            }
        }

        foreach (var trackedImage in args.removed)
        {
            if (spawnedPrefabs.TryGetValue(trackedImage.referenceImage.name, out GameObject obj))
            {
                Destroy(obj);
                spawnedPrefabs.Remove(trackedImage.referenceImage.name);
            }
        }
    }
}
