using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace game3
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Score score;
        [SerializeField] private GameObject GameOverPanel;
        [SerializeField] private GameObject VFX;
        private float speed;
        private int height;
        private List<GameObject> mineCubes = new List<GameObject>();
        private bool isEnter;
        private bool win;

        public void StartGame() => speed = 0.2f;


        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -2f)
            {
                gameObject.transform.position = new Vector3(transform.position.x-0.05f, transform.position.y, transform.position.z);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 2f)
            {
                gameObject.transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
            }
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Pill")
            {
                mineCubes.Add(collision.gameObject);
                height++;
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                collision.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - height, transform.position.z);
                collision.gameObject.transform.parent = gameObject.transform;
                collision.gameObject.tag = "Mine";

                SpawnVFX(transform.position.x, transform.position.y - height, transform.position.z);
            }
            if(collision.gameObject.tag == "Wall" && !isEnter)
            {
               isEnter = true;
               var wall = collision.gameObject.GetComponent<Wall>();
               if (mineCubes.Count + 1 <= wall.height && !win)
               {
                    GameOver();
               }
               for(int i = 1; i<=wall.height; i++)
               {
                    mineCubes[mineCubes.Count-1].transform.parent = null;
                    mineCubes.RemoveAt(mineCubes.Count-1);
                    height--;
               }
                StartCoroutine(ReturnEnterTrue());
            }
        }

        private void SpawnVFX(float x, float y, float z) => Instantiate(VFX, new Vector3(x, y,z),Quaternion.identity);

        private void GameOver()
        {
            speed = 0;
            GameOverPanel.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            print("Trigger");
            win = true;
            score.score = mineCubes.Count + 1;
            score.Win();
        }


       IEnumerator ReturnEnterTrue()
       {
        yield return new WaitForSeconds(0.2f);
        isEnter = false;
       }
    } 
}
