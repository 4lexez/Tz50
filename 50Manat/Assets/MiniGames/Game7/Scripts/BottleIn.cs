using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace game7
{
    public class BottleIn : MonoBehaviour
    {
        [SerializeField] private AudioSource sounds;
        [SerializeField] private AudioClip[] clips; 

        [SerializeField] private Transform parentObject;
        [SerializeField] private JellyType[] setJelly;
        [SerializeField] private Jelly[] JellysPrefab;
        [SerializeField] private Vector3 up;
        [SerializeField] private float speed;

        [SerializeField] private Material wrongBottle;
        [SerializeField] private Material defaultMaterial;

        public static Jelly selectedJelly;

        private List<Jelly> jellies = new List<Jelly>();
        private bool isJellyUp, isJellyDown, click;

        private void Start()
        {
            selectedJelly = null;
            for (int i = 0; i < setJelly.Length; i++)
            {
                jellies.Add(Instantiate(JellysPrefab[(int)setJelly[setJelly.Length - 1 - i]], new Vector3(transform.position.x, transform.position.y-3f + i, transform.position.z), Quaternion.identity));
                jellies[i].transform.parent = parentObject;
            }
        }
        private void OnMouseDown()
        {
            if (selectedJelly == null)
            {
                click = !click;
                selectedJelly = jellies[jellies.Count - 1];
                jellies.RemoveAt(jellies.Count - 1);
                StartCoroutine(StopMove());
            }
            else
            {
                if(jellies.Count == 0)
                {
                    selectedJelly.iSelected = true;
                    isJellyUp = true;
                }
                else if (selectedJelly.iSelected == false && 
                    jellies[jellies.Count - 1].jellyType == selectedJelly.jellyType)
                     {
                    selectedJelly.iSelected = true;
                    isJellyUp = true;
                     }
            }

        }

        private void FixedUpdate()
        {
            if (isJellyUp)
            {

                selectedJelly.transform.position = Vector3.MoveTowards(selectedJelly.transform.position, up, speed);
                if (selectedJelly.transform.position == up)
                {
                    isJellyUp = false;
                    isJellyDown = true;
                }
            }

            if(isJellyDown)
            {
                selectedJelly.transform.position = Vector3.MoveTowards(selectedJelly.transform.position, new Vector3(transform.position.x, jellies.Count + transform.position.y - 3f, transform.position.z), speed);

                if (selectedJelly.transform.position == new Vector3(transform.position.x, jellies.Count + transform.position.y - 3f, transform.position.z))
                {
                    //SoundPlay(1);
                    jellies.Add(selectedJelly);
                    isJellyDown = false;
                    selectedJelly.iSelected = false;
                    selectedJelly = null;

                }  
            }
            
            if (click)
            {
               // SoundPlay(0);
                if (selectedJelly != null) selectedJelly.transform.position = Vector3.MoveTowards(selectedJelly.transform.position, up, speed);
            }
        }

        private void SoundPlay(int i)
        {
                sounds.clip = clips[i];
                sounds.Play();
        }

        IEnumerator StopMove()
        {
            yield return new WaitForSeconds(0.2f);
            isJellyUp = false;
            click = false;
        }

    }
}