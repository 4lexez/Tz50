using UnityEngine;
using UnityEngine.UI;

namespace game5
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Text scoreCountText;
        private int scoreCount;

        public void PointAdd()
        {
            scoreCountText.text = $"{++scoreCount}";
        }
    }
}