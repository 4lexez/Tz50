using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainScene;
    [SerializeField] private Fading Fade;

    public static GameObject mainScene;
    private void Start()=>mainScene = _mainScene;

    public void LoadScene(string indexScene) => StartCoroutine(WaitFade(indexScene));

    IEnumerator WaitFade(string indexScene)
    {
        Fade.Fade(1f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(indexScene, LoadSceneMode.Additive);
        asyncOperation.allowSceneActivation = false;
        yield return new WaitForSeconds(0.8f);
        asyncOperation.allowSceneActivation = true;
        Fade.Fade(-1);
        mainScene.SetActive(false);
    }
}
