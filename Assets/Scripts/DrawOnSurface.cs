using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DrawOnSurface : MonoBehaviour
{
    public TrackableType surfaceToDetect;

    private ARRaycastManager arOrigin;

    // Start is called before the first frame update
    void Start()
    {
        arOrigin = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centerPoint = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));

        List<ARRaycastHit> validHits = new List<ARRaycastHit>();
        arOrigin.Raycast(centerPoint, validHits, surfaceToDetect);

        gameObject.transform.position = validHits[0].pose.position;
        gameObject.transform.rotation = validHits[0].pose.rotation;
    }
}