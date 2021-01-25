using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private float minTimeSpawn = 4, maxTimeSpawn = 8;
    [SerializeField] private BuddyControl Buddy;
    [SerializeField] private Transform[] spawners;
    public bool BigAmountOfBuddys = false;
    [SerializeField] private Transform Destination;
    void Start()
    {
        StartCoroutine(Spawn());
    }
    public IEnumerator Spawn()
    {
        while (!BigAmountOfBuddys)
        {
            float random = Random.Range(minTimeSpawn, maxTimeSpawn);
            yield return new WaitForSeconds(random);
            int RandomTransform = Random.Range(0, spawners.Length);
            var newObj = Instantiate(Buddy, spawners[RandomTransform].position, Quaternion.identity);
            newObj.StopPoint = Destination;
        }

    }
}
