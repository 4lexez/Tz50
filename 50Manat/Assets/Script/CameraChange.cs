using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraChange : MonoBehaviour
{
    [SerializeField] private Transform[] CameraPlace;
    [SerializeField] private int page;
    Camera MainCamera;
    private Fading Fade;
    [SerializeField] private Canvas CameraButtonMain, GraphicsCanvas, MiniGamesCanvas, RestRoomCanvas;
    void Start()
    {
        MainCamera = Camera.main;
        Fade = MainCamera.gameObject.GetComponent<Fading>();
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
            CameraButtonMain.enabled = false;
            RestRoomCanvas.enabled = false;
        }
        if (placeValue == 1)
        {
            CameraButtonMain.enabled = false;
            RestRoomCanvas.enabled = true;
        }
        if (placeValue == 0)
        {
            CameraButtonMain.enabled = true;
            RestRoomCanvas.enabled = false;
        }
        if(placeValue < 2)
        {
            GraphicsCanvas.enabled = true;
            MiniGamesCanvas.enabled = false;
        }

        Fade.Fade(-1);

        yield return new WaitForSeconds(1);
    }
}
