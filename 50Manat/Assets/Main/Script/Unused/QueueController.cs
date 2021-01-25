using UnityEngine;

public class QueueController : MonoBehaviour
{
    public Respawn respawn;
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
