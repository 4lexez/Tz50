using UnityEngine;

public class DeleteBuddy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buddy")) Destroy(other.gameObject);
    }
}
