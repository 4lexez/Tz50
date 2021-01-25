using UnityEngine;
namespace game6
{
    public class MovePlatform : MonoBehaviour
    {
        [SerializeField] private float x,y,z;
        [SerializeField] private float speed;
        [SerializeField] private float maxDistanse;
        private Vector3 startVector;
        private bool down;

        private void Start()
        {
            startVector = gameObject.transform.position;
        }  
        private void FixedUpdate()
        {   if (gameObject.transform.position.y < maxDistanse && gameObject.transform.position.z < maxDistanse && down == false)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + x * speed, gameObject.transform.position.y + y * speed, gameObject.transform.position.z + z * speed);
            }
            else
            {
                down = true;
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, startVector, speed);
                if (gameObject.transform.position == startVector) down = false;
            }
        }
    }
}