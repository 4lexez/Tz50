using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PsychoControl : MonoBehaviour
{
    public float isGood { get { return IsGood; } set { IsGood = value;}}

    private float IsGood, IsBad;
    private Animator animator;
    private Transform patientSeat;
    private CameraChange CamChange;
    private Slider sliderNormalPount;
    [SerializeField] private bool HasAnimation;


    private bool sit;

    public void Init(float _IsGood, float _IsBad, CameraChange _CamChange, Transform _patientSeat, Slider _sliderNormalPount)
    {
        IsGood = _IsGood;
        IsBad = _IsBad;
        CamChange = _CamChange;
        patientSeat = _patientSeat;
        gameObject.transform.parent =  MainSceneManager.mainScene.transform;
        sliderNormalPount = _sliderNormalPount;
        if (HasAnimation)
        {
            animator = transform.GetChild(0).GetComponent<Animator>();
            animator.SetBool("Sit", true);
            animator.cullingMode = AnimatorCullingMode.CullCompletely;
        }

    }

    private void OnMouseDown()
    {
        if (CheakSitplace.freeSitPlace == true)
        {
            CheakSitplace.freeSitPlace = false;
            StartCoroutine(WaitForSit());
        }
    }
    private void FixedUpdate()
    {
        if (sit) SetSitAnimation();
    }

    IEnumerator WaitForSit()
    {
        CamChange.OnCameraChange(2);
        yield return new WaitForSeconds(1f);
        SetSitAnimation();
        CountNormalPoint.ChangeCurrentPatient(this);
    }

    private void SetSitAnimation()
    {
        transform.position = patientSeat.position;
        transform.rotation = patientSeat.rotation;
        sliderNormalPount.value = IsGood;
    }
}
