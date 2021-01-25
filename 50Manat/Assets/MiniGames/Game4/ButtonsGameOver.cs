using UnityEngine;
using UnityEngine.SceneManagement;

namespace game4
{
    public class ButtonsGameOver : MonoBehaviour
    {
        public void TryAgain()
        {
            SceneManager.LoadScene("MiniGame4", LoadSceneMode.Single);
        }
    }
}