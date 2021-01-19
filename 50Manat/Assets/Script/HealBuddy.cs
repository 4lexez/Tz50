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
    private int cellValue = 0;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Buddy")) NewBuddy = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buddy"))
        {
            NewBuddy = other.GetComponent<BuddyControl>();
            for (int i = cellValue; i <= BuddyCell.Length; i++)
            {
                if(BuddyCell[i] != null)
                {
                    cellValue++;
                    var newPsycho = Instantiate(psychoBuddy[NewBuddy.type], BuddyCell[i].position, Quaternion.identity);
                    newPsycho.IsGood = NewBuddy.IsGood;
                    newPsycho.IsBad = NewBuddy.IsBad;
                    Destroy(NewBuddy.gameObject);
                    break;
                }
            }
        }
    }
}

