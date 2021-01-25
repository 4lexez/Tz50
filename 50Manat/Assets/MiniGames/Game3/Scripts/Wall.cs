using UnityEngine;
namespace game3
{
    public class Wall : MonoBehaviour
    {
        [SerializeField] private int heightWall;
        public int height 
        {
            get { return heightWall;}   
        }

    }
}