using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealBuddy : MonoBehaviour
{
    [SerializeField] private GameObject[] psychoBuddyObject;
    [SerializeField] private Transform[] BuddyCell;
    [SerializeField] private Transform patientSeat;
    [SerializeField] private Slider slider;
    private int cellValue = 0;
    public CameraChange CamChange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buddy"))
        {
            var newBuddy = other.GetComponent<BuddyControl>();

            for (int i = cellValue; i <= BuddyCell.Length; i++)
            {
                if(BuddyCell[i] != null)
                {
                    cellValue++;
                    var newPsycho = Instantiate(psychoBuddyObject[newBuddy.type], BuddyCell[i].position, BuddyCell[i].rotation).GetComponent<PsychoControl>();
                    newPsycho.Init(newBuddy.IsGood, newBuddy.IsBad, CamChange, patientSeat, slider);
                    Destroy(newBuddy.gameObject);
                    break;
                }
            }
            if (newBuddy.isLastGet) CamChange.OnCameraChange(1);
        }
    }
}

