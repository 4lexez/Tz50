using UnityEngine;
using System.Collections;

public class Swipe : MonoBehaviour
{

    Vector2 firstPressPos;
    Vector2 currentSwipe;
    public bool CanUseSwipe;
    [SerializeField] private bool CursorDown;
    [SerializeField] private int distanceFromFinger = 20;
    [SerializeField] private OnStopTrigger Trigger;

    private void Start()
    {
        Trigger = GetComponent<OnStopTrigger>();
    }
    void Update()
    {
        if(CanUseSwipe)
        {
            if (Input.GetMouseButtonDown(0))
            {
                firstPressPos = Input.mousePosition;
                CursorDown = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                currentSwipe = (Vector2)Input.mousePosition - firstPressPos;
                if (CursorDown && Input.mousePosition.x >= firstPressPos.x + distanceFromFinger)
                {
                    Trigger.MakeTurn(false);
                }
                else if (CursorDown && Input.mousePosition.x <= firstPressPos.x - distanceFromFinger)
                {
                    Trigger.MakeTurn(true);
                }
                CursorDown = false;
            }
        }
    }
}
