using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychoControl : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private bool IsUseAnimator;
    public float IsGood, IsBad;
    private bool sit;
    public Transform patientSeat;
    public CameraChange CamChange;
    void Start()
    {
        CamChange = Camera.main.GetComponent<CameraChange>();
        if(IsUseAnimator)
            animator = transform.GetChild(0).GetComponent<Animator>();
        //patientSeat = GameObject.Find("PatientSitplace").transform;
    }
    private void OnMouseDown()
    {
        StartCoroutine(WaitForSit());
    }
    IEnumerator WaitForSit()
    {
        CamChange.OnCameraChange(2);
        yield return new WaitForSeconds(1f);
        sit = true;
        if(IsUseAnimator)
            animator.SetBool("Sit", sit);
        //yield return new WaitForSeconds(0.2f);
        transform.position = patientSeat.position;
        transform.rotation = patientSeat.rotation;
    }
}
