using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueController : MonoBehaviour
{
    public Respawn respawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buddy"))
        {
            bool isGoing = other.GetComponent<BuddyControl>().IsGoing;
            if (!isGoing)
            {
                respawn.BigAmountOfBuddys = true;
            }
        }

    }
}
