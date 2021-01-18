using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStopTrigger : MonoBehaviour
{
    [SerializeField] private BuddyControl NewBuddy;
    [SerializeField] private Slider HowGood, HowBad;
    [SerializeField] private Swipe swipe;
    [SerializeField] private Transform GoodHealth, BadHealth;
    void Start()
    {
        swipe = GetComponent<Swipe>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Buddy")) NewBuddy = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buddy"))
        {
            swipe.CanUseSwipe = true;
            NewBuddy = other.GetComponent<BuddyControl>();
            HowGood.value = NewBuddy.IsGood;
            HowBad.value = NewBuddy.IsBad;
        }
    }
    public void MakeTurn(bool IsHealthy)
    {
        if(NewBuddy != null)
        {
            if (IsHealthy)
            {
                NewBuddy.StopPoint = GoodHealth;
                NewBuddy.ContinueWalking(GoodHealth);
                if (NewBuddy.IsGood > NewBuddy.IsBad)
                {
                    print("You are Right");
                }
                else
                {
                    print("You Are Wrong");
                }
            }
            else
            {
                NewBuddy.StopPoint = BadHealth;
                NewBuddy.ContinueWalking(BadHealth);
                if (NewBuddy.IsGood < NewBuddy.IsBad)
                {
                    print("You are Right");
                }
                else
                {
                    print("You Are Wrong");
                }
            }
        }
    }
}
