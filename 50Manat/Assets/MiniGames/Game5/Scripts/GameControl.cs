using System.Collections.Generic;
using System.Collections;
using UnityEngine;
namespace game5
{
    public class GameControl : MonoBehaviour
    {
        [SerializeField] private ButtonForObject[] buttons;
        [SerializeField] private Score score;
        [SerializeField] private GameObject losePanel;
        private List<int> Sequence = new List<int>();
        private bool ReplayMode = true;
        private int currentNum;

        private void Start()
        {
            StartRound();
        }

        private void StartRound()
        {
            SetSeqience();
            StartCoroutine(ReadSeqience());
        }


        public void Select(int num)
        {
            if (ReplayMode == false)
            {
                if (Sequence[currentNum++] == num)
                {
                    score.PointAdd();
                    buttons[num].ChangeColor();

                    if (currentNum == Sequence.Count)
                    {
                        StartRound();
                        ReplayMode = true;
                        currentNum = 0;
                    }
                }
                else
                {
                    losePanel.SetActive(true);
                }
            }
        }

        private void SetSeqience()
        {
         int value = Random.Range(0, 4);
         Sequence.Add(value);
        }

        IEnumerator ReadSeqience()
        {
            for (int i = 0; i < Sequence.Count; i++)
            {
                yield return new WaitForSeconds(1f);
                buttons[Sequence[i]].ChangeColor();
            }
            ReplayMode = false;
        }
    }
}