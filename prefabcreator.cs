using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{     
    [SerializeField] private GameObject robinPrefab; // Prefab to spawn when a tracked image is detected.
    [SerializeField] private Vector3 prefabOffset;

    private GameObject robin;
    private ARTrackedImageManager aRTrackedImageManager;

    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();  
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            robin = Instantiate(robinPrefab, image.transform.position, image.transform.rotation);
            robin.transform.position += prefabOffset;  
            
        }
    }
}
