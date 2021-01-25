using UnityEngine;
using UnityEngine.UI;

namespace game4
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject VFX;
        [SerializeField] private Score score;
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private Image ImagePos;
        [SerializeField] private GameObject GameOverPanel;
        private float speed;
        private int correctSelect;
        private bool lose,canSelectet,selected = true;

        public void StartGame() => speed = 0.2f;

        public void Select(int selectIn)
        {
            if (canSelectet)
            {
                if (selectIn == correctSelect) CorrectSelect();
                else WrongSelect();
                selected = true;
                canSelectet = false;
            }
        }

        private void WrongSelect()
        {
            lose = true;
            GameOverPanel.SetActive(true);
        }

        private void CorrectSelect()
        {
            ImagePos.gameObject.SetActive(false);
            score.PlusPoints();
            speed = speed + speed / 25;
        }

        private void FixedUpdate()
        {
           if(lose == false) gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
        }
        private void OnTriggerEnter(Collider other) => Enter();

        private void Enter()
        {
            if (selected == false) WrongSelect();
            Instantiate(VFX, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
            selected = false;
            canSelectet = true;
            correctSelect = Random.Range(0, 4);
            ImagePos.gameObject.SetActive(true);
            ImagePos.sprite = sprites[correctSelect];
        }
    } 
}
