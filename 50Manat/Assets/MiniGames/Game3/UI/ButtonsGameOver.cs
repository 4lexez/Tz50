using UnityEngine;
using UnityEngine.SceneManagement;

namespace game3
{
    public class ButtonsGameOver : MonoBehaviour
    {
        public void TryAgain()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name,LoadSceneMode.Additive);
            SceneManager.UnloadScene(SceneManager.GetActiveScene().name);
        }
    }
}