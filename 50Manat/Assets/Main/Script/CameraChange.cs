using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraChange : MonoBehaviour
{
    [SerializeField] private Transform[] CameraPlace;
    [SerializeField] private int page;
    [SerializeField] private Fading Fade;
    [SerializeField] private Canvas GraphicsCanvas, MiniGamesCanvas, RestRoomCanvas;

    private Camera MainCamera;

    private void Start()
    {
        MainCamera = Camera.main;
    }

    // Update is called once per frame
    public void OnCameraChange(int placeValue)
    {
        StartCoroutine(CameraFade(placeValue));

    }

    IEnumerator CameraFade(int placeValue)
    {
        Fade.Fade(1f);
        
        yield return new WaitForSeconds(1);
        MainCamera.gameObject.transform.position = CameraPlace[placeValue].position;
        MainCamera.gameObject.transform.rotation = CameraPlace[placeValue].rotation;
        if (placeValue == 2)
        {
            GraphicsCanvas.enabled = false;
            MiniGamesCanvas.enabled = true;
            //RestRoomCanvas.enabled = false;
        }
        /*if (placeValue == 1 && CheakSitplace.freeSitPlace == true)
        {
                RestRoomCanvas.enabled = true;
        }
        if (placeValue == 0)
        {
            RestRoomCanvas.enabled = false;
        }*/
        if(placeValue < 2)
        {
            GraphicsCanvas.enabled = true;
            MiniGamesCanvas.enabled = false;
        }

        Fade.Fade(-1);

        yield return new WaitForSeconds(1);
    }
}
