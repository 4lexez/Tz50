using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraChange : MonoBehaviour
{
    [SerializeField] private Transform[] CameraPlace;
    private int placeValue;
    Camera MainCamera;
    private bool IsOnMainHall = true;
    private Fading Fade;
    [SerializeField] private Canvas CameraButton, GraphicsCanvas;
    void Start()
    {
        MainCamera = Camera.main;
        Fade = MainCamera.gameObject.GetComponent<Fading>();
    }

    // Update is called once per frame
    public void OnCameraChange(bool IsButton)
    {
        StartCoroutine(CameraFade(IsButton));
        /*if (IsButton)
        {
            if (IsOnMainHall)
            {
                placeValue = 1;

            }
            else
            {
                placeValue = 0;
            }
            IsOnMainHall = !IsOnMainHall;
            MainCamera.gameObject.transform.position = CameraPlace[placeValue].position;
            MainCamera.gameObject.transform.rotation = CameraPlace[placeValue].rotation;
        }
        else
        {
            IsOnMainHall = false;
            placeValue = 2;
            MainCamera.gameObject.transform.position = CameraPlace[placeValue].position;
            MainCamera.gameObject.transform.rotation = CameraPlace[placeValue].rotation;
        }*/
    }

    IEnumerator CameraFade(bool IsButton)
    {
        //float fadeTime = MainCamera.GetComponent<Fading>().Fade(1f);
        //float fadeTime = Fade.Fade(1f);
        Fade.Fade(1f);
        CameraButton.enabled = false;
        //float fadeTime = fading.Fade(1f);
        yield return new WaitForSeconds(1);
        if (IsButton)
        {
            if (IsOnMainHall)
            {
                placeValue = 1;

            }
            else
            {
                placeValue = 0;
            }
            IsOnMainHall = !IsOnMainHall;
            MainCamera.gameObject.transform.position = CameraPlace[placeValue].position;
            MainCamera.gameObject.transform.rotation = CameraPlace[placeValue].rotation;
        }
        else
        {
            IsOnMainHall = false;
            placeValue = 2;
            MainCamera.gameObject.transform.position = CameraPlace[placeValue].position;
            MainCamera.gameObject.transform.rotation = CameraPlace[placeValue].rotation;
            GraphicsCanvas.enabled = false;
        }
        Fade.Fade(-1);
        CameraButton.enabled = true;
        
        yield return new WaitForSeconds(1);
    }
}
