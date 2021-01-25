using UnityEngine;
using UnityEngine.UI;

namespace game3
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private GameObject winPanel;
        [SerializeField] private Text scoreCountText;
        private int scoreCount;
        public int score { set { scoreCount = value; } }

        public void Win()
        {
            CountNormalPoint.AddPoints(scoreCount + 5);
            winPanel.SetActive(true);
            scoreCountText.text = $"{scoreCount}";
        }
    }
}