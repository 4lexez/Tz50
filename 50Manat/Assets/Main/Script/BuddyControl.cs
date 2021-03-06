﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuddyControl : MonoBehaviour
{
    [SerializeField] private bool isLast;
    public bool isLastGet => isLast;

    public NavMeshAgent Agent;
    public Animator animator;

    public Transform StopPoint;
    public bool IsGoing, Event;
    private float minTimeSpawn = 15, maxTimeSpawn = 25;
    [SerializeField] private int eventCounter;
    [SerializeField]
    private bool IsUseAnimator;
    public string[] Events;
    public int type;

    public float IsGood, IsBad;

    private void Start()
    {
        //RandomHealthValue();
        if(IsUseAnimator)
            animator = transform.GetChild(0).GetComponent<Animator>();
        ContinueWalking(StopPoint);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stop")) 
        {

            Stop(false);
            StopPoint = null;
        }
    }
    public void Stop(bool Inqueue)
    {
        IsGoing = false;
        if(IsUseAnimator)
            animator?.SetBool("Walking", IsGoing);
        Agent.isStopped = Inqueue;
        StartCoroutine(Sneeze());
    }
    /*void RandomHealthValue()
    {
        IsGood = Random.Range(0, 7);
        IsBad = Random.Range(0, 7);
        if(IsGood == IsBad)
        {
            RandomHealthValue();
            return;
        }
    }*/
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Buddy") && StopPoint != null)
        {

            ContinueWalking(StopPoint);
        }
    }

    public void ContinueWalking(Transform Pointer)
    {
        if (Pointer != null)
        {
            Agent.isStopped = false;
            Agent.SetDestination(Pointer.position);
            IsGoing = true;
            if(IsUseAnimator)
                animator?.SetBool("Walking", IsGoing);

        }
        if (Event) StopCoroutine(Sneeze());
        Event = false;
    }
    IEnumerator Sneeze()
    {
        Event = true;
        
        while (!IsGoing)
        {
            eventCounter = Random.Range(0, Events.Length);
            float timeToSneeze = Random.Range(minTimeSpawn, maxTimeSpawn);
            yield return new WaitForSeconds(timeToSneeze);
            if(IsUseAnimator)
                animator?.SetTrigger($"{Events[eventCounter]}");
        }
    }
}
