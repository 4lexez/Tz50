using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace game5
{
    public class ButtonForObject : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnClick = new UnityEvent();
        [SerializeField] private MeshRenderer mesh;
        [SerializeField] private Material selectedMaterial, baseMaterial;
        private void OnMouseDown() => OnClick.Invoke();
        private bool endClick = true;

        public void ChangeColor()
        {
            if (endClick)
            {
                endClick = false;
                mesh.material = selectedMaterial;
                StartCoroutine(ReturnColor());
            }
        }

        IEnumerator ReturnColor()
        {
            yield return new WaitForSeconds(0.5f);
            mesh.material = baseMaterial;
            endClick = true;
        }
    }
}