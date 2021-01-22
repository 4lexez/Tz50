using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealBuddy : MonoBehaviour
{
    [SerializeField] private BuddyControl NewBuddy;
    [SerializeField] private PsychoControl[] psychoBuddy;
    [SerializeField] private Slider HowGood, HowBad;
    [SerializeField] private Transform[] BuddyCell;
    [SerializeField] private Transform patientSeat;
    private int cellValue = 0;
    public CameraChange CamChange;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Buddy")) NewBuddy = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buddy"))
        {
            NewBuddy = other.GetComponent<BuddyControl>();
            /*if (cellValue < 1)
            {
                cellValue++;
                var newPsycho = Instantiate(psychoBuddy[NewBuddy.type], patientSeat.position, patientSeat.rotation);
                newPsycho.IsGood = NewBuddy.IsGood;
                newPsycho.IsBad = NewBuddy.IsBad;
                Destroy(NewBuddy.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }*/
            // For queue
            for (int i = cellValue; i <= BuddyCell.Length; i++)
            {
                if(BuddyCell[i] != null)
                {
                    cellValue++;
                    var newPsycho = Instantiate(psychoBuddy[NewBuddy.type], BuddyCell[i].position, BuddyCell[i].rotation);
                    newPsycho.IsGood = NewBuddy.IsGood;
                    newPsycho.IsBad = NewBuddy.IsBad;
                    newPsycho.CamChange = CamChange; 
                    Destroy(NewBuddy.gameObject);
                    break;
                }
            }
        }
    }
}

