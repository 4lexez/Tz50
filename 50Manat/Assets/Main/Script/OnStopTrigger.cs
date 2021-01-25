using UnityEngine;
using UnityEngine.UI;

public class OnStopTrigger : MonoBehaviour
{
    [SerializeField] private Slider HowGood, HowBad;
    [SerializeField] private Slider HowGoodPsycho;
    [SerializeField] private Swipe swipe;
    [SerializeField] private Transform GoodHealth, BadHealth;
    private BuddyControl newBuddy;
    private PsychoControl psychoBuddy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buddy"))
        {
            swipe.CanUseSwipe = true;
            newBuddy = other.GetComponent<BuddyControl>();
            HowGood.value = newBuddy.IsGood;
            HowBad.value = newBuddy.IsBad;
        }
    }
    public void MakeTurn(bool IsHealthy)
    {
        if(newBuddy != null)
        {

            if (IsHealthy)
            {

                if (newBuddy.IsGood > newBuddy.IsBad)
                {
                    print("You are Right");
                }
                else
                {
                    print("You Are Wrong");
                    return;
                }
                newBuddy.StopPoint = GoodHealth;
                newBuddy.ContinueWalking(GoodHealth);
                newBuddy = null;
            }
            else
            {

                if (newBuddy.IsGood < newBuddy.IsBad)
                {
                    print("You are Right");
                }
                else
                {
                    print("You Are Wrong");
                    return;
                }
                newBuddy.StopPoint = BadHealth;
                newBuddy.ContinueWalking(BadHealth);
                newBuddy = null;
            }
        }
    }
}
