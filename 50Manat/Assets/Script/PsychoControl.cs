using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychoControl : MonoBehaviour
{
    public Animator animator;
    public float IsGood, IsBad;
    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        print("Buddy "+ this.gameObject.name);
    }
}
