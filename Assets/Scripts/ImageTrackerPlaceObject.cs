using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTrackerPlaceObject : MonoBehaviour
{

    [SerializeField] 
    private GameObject prefab;

    private ARTrackedImageManager arTrackedImageManager;

    // Start is called before the first frame update
    private void Awake() {
        arTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable() {
        arTrackedImageManager.trackedImagesChanged += OnImageTracked;
    }

    private void OnDisable() {
        arTrackedImageManager.trackedImagesChanged -= OnImageTracked;
    }

    private void OnImageTracked(ARTrackedImagesChangedEventArgs  eventArgs) {
        foreach(var newImage in eventArgs.added) {
            GameObject obj = Instantiate(prefab, newImage.transform);
        }
    }
    
}
