using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychoControl : MonoBehaviour
{
    public Animator animator;
    public float IsGood, IsBad;
    private bool sit;
    [SerializeField] private Transform patientSeat;
    public CameraChange CamChange;
    void Start()
    {
        CamChange = Camera.main.GetComponent<CameraChange>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        patientSeat = GameObject.Find("PatientSitplace").transform;
    }
    private void OnMouseDown()
    {
        StartCoroutine(WaitForSit());
    }
    IEnumerator WaitForSit()
    {
        CamChange.OnCameraChange(false);
        yield return new WaitForSeconds(1f);
        sit = true;
        animator.SetBool("Sit", sit);
        //yield return new WaitForSeconds(0.2f);
        transform.position = patientSeat.position;
        transform.rotation = patientSeat.rotation;
    }
}
