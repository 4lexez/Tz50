using UnityEngine;
namespace game4
{
    public class SpawnPlatform : MonoBehaviour
    {
        [SerializeField] private Transform parentTransform;
        [SerializeField] private GameObject[] platforms;
        [SerializeField] private int countRoad;

        private int z = 100;

        private void Awake()
        {
            int lastColor = 0;
            int currentColor = 0;
          for(int i = 0;i<=countRoad;i++)
          {
                currentColor = Random.Range(0, 4);
                if(lastColor == currentColor) while(lastColor==currentColor) currentColor = Random.Range(0, 4);
                var newObj = Instantiate(platforms[currentColor], new Vector3(0, 0, z), Quaternion.identity);
                newObj.transform.parent = parentTransform;
                z = z + 20;
                lastColor = currentColor;
          }
        }
    }
}