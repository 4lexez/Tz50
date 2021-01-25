using UnityEngine;
namespace game6
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private MeshRenderer mesh;
        [SerializeField] private Rigidbody rg;
        [SerializeField] private MixColor mixColor;
        [SerializeField] private Color MyCyrrentColor;
        [SerializeField] private GameObject[] VFX;
        public Material playerColor { get { return mesh.material; }}

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D)) rg.AddForce(new Vector3(4, 0),ForceMode.Impulse);
            if (Input.GetKeyDown(KeyCode.A)) rg.AddForce(new Vector3(-4, 0),ForceMode.Impulse);
            if (Input.GetKeyDown(KeyCode.W))
            {
                rg.AddForce(new Vector3(0, 8), ForceMode.Impulse);
                Instantiate(VFX[0], new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z - 0.1f), Quaternion.identity);
            }
            }

        private void OnTriggerEnter(Collider other)
        {
            var result = mixColor.MixedColors(MyCyrrentColor, other.gameObject.GetComponent<Color>());
            if (result == null) GameOver();
            MyCyrrentColor = result;
            mesh.material = MyCyrrentColor.material;
            Instantiate(VFX[1], new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y - 0.5f, other.gameObject.transform.position.z - 0.1f), Quaternion.identity);
            Destroy(other.gameObject);
           
        }

        private void GameOver()
        {
            Debug.Log("Lose");
        }
    }
}
