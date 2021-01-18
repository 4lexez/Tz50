using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuddyControl : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Animator animator;
    public Transform StopPoint;
    public bool IsGoing, Event;
    private float minTimeSpawn = 15, maxTimeSpawn = 30;
    [SerializeField] private int eventCounter;
    public string[] Events;

    public float IsGood, IsBad;
    void Start()
    {
        RandomHealthValue();
        animator = transform.GetChild(0).GetComponent<Animator>();
        ContinueWalking(StopPoint);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buddy") && IsGoing) Stop(true);
        if (other.CompareTag("Stop")) Stop(false);
    }
    void Stop(bool Inqueue)
    {
        IsGoing = false;
        animator.SetBool("Walking", IsGoing);
        Agent.isStopped = Inqueue;
        StartCoroutine(Sneeze());
    }
    void RandomHealthValue()
    {
        IsGood = Random.Range(0, 7);
        IsBad = Random.Range(0, 7);
        if(IsGood == IsBad)
        {
            RandomHealthValue();
            return;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Buddy") && !other.CompareTag("Stop"))
        {
            Agent.isStopped = false;
            ContinueWalking(StopPoint);
        }
    }
    public void ContinueWalking(Transform Pointer)
    {
        if (Pointer != null)
        {
            Agent.SetDestination(Pointer.position);
            IsGoing = true;
            animator.SetBool("Walking", IsGoing);

        }
        if (Event) StopCoroutine(Sneeze());
    }
    IEnumerator Sneeze()
    {
        Event = true;
        
        while (!IsGoing)
        {
            eventCounter = Random.Range(0, Events.Length);
            float timeToSneeze = Random.Range(minTimeSpawn, maxTimeSpawn);
            yield return new WaitForSeconds(timeToSneeze);
            animator.SetTrigger($"{Events[eventCounter]}");
        }
    }
}
