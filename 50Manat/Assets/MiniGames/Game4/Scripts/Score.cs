using UnityEngine;
using UnityEngine.UI;

namespace game4
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        private int scoreCount;
        private int reward;

        public void PlusPoints()
        {
            scoreCount = scoreCount + ++reward;
            scoreText.text = $"{scoreCount}";
        }
    }
}