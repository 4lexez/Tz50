using UnityEngine;
using UnityEngine.UI;

public class OnStopTrigger : MonoBehaviour
{
    [SerializeField] private BuddyControl NewBuddy;
    [SerializeField] private PsychoControl PsychoBuddy;
    [SerializeField] private Slider HowGood, HowBad;
    [SerializeField] private Slider HowGoodPsycho;
    [SerializeField] private Swipe swipe;
    [SerializeField] private Transform GoodHealth, BadHealth;
    [SerializeField] private int wrongAnswerValue;
    [SerializeField] private Canvas CameraButton;
    void Start()
    {
        swipe = GetComponent<Swipe>();
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
        if (other.CompareTag("Psycho"))
        {
            PsychoBuddy = other.GetComponent<PsychoControl>();
            HowGoodPsycho.value = PsychoBuddy.IsGood;
        }
    }
    public void MakeTurn(bool IsHealthy)
    {
        if(NewBuddy != null)
        {

            if (IsHealthy)
            {

                if (NewBuddy.IsGood > NewBuddy.IsBad)
                {
                    print("You are Right");
                }
                else
                {
                    print("You Are Wrong");
                    wrongAnswerValue++;
                    return;
                }
                NewBuddy.StopPoint = GoodHealth;
                NewBuddy.ContinueWalking(GoodHealth);
                NewBuddy = null;
            }
            else
            {

                if (NewBuddy.IsGood < NewBuddy.IsBad)
                {
                    print("You are Right");
                }
                else
                {
                    print("You Are Wrong");
                    wrongAnswerValue++;
                    return;
                }
                if (!CameraButton.enabled)
                    CameraButton.enabled = true;
                NewBuddy.StopPoint = BadHealth;
                NewBuddy.ContinueWalking(BadHealth);
                NewBuddy = null;
            }
        }
    }
}
