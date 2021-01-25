using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    private BuddyControl ColliderBuddy;
    void Start()
    {
        ColliderBuddy = transform.parent.GetComponent<BuddyControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buddy") && ColliderBuddy.IsGoing) ColliderBuddy.Stop(true);
    }
}
