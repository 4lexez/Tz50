using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    private Vector2 startPos;
    [SerializeField] private bool fingerDown;
    [SerializeField] private int distanceFromFinger = 20;


    // Update is called once per frame
    void Update()
    {
        if (
            fingerDown == false
            && Input.touchCount > 0
            && Input.touches[0].phase == TouchPhase.Began
            )
        {
            startPos = Input.touches[0].position;
            fingerDown = true;
        }
        if (Input.mousePosition.y >= startPos.y + distanceFromFinger)
        {
            fingerDown = false;
            print("Up");
        }
        //PC
        if (
            fingerDown == false
            && Input.GetMouseButtonDown(0)
            )
        {
            startPos = Input.mousePosition;
            fingerDown = true;
        }
        if(fingerDown && Input.GetMouseButtonUp(0))
        {
            fingerDown = false;
        }
    }
}
