using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameSceneManager : MonoBehaviour
{
    [SerializeField] private int indexScene;
    private void Start() => SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(indexScene));
 
    public void CloseScene()
    {
        SceneManager.UnloadSceneAsync(indexScene);
        MainSceneManager.mainScene.SetActive(true);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
    }
}
