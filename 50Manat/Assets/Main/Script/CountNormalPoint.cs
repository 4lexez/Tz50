using UnityEngine;
using UnityEngine.UI;

public class CountNormalPoint : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    public static Slider slider;
    public static PsychoControl currentPatient;

    private void Start()
    {
        slider = _slider;
    }

    public static void ChangeCurrentPatient(PsychoControl psycho) => currentPatient = psycho;
    public static void AddPoints(float num) => currentPatient.isGood++;
    public static void UpdateSlider() => slider.value = currentPatient.isGood;
}
