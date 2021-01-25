using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideBuddyStatus : MonoBehaviour
{
    private Camera mainCamera;
    public Transform CameraPoint;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Buddy"))
            mainCamera.gameObject.transform.position = CameraPoint.position;
    }
}
