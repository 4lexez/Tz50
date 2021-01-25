using UnityEngine;
namespace game7
{
    public class Jelly : MonoBehaviour
    {
       public JellyType jellyType;
       public bool iSelected;
    }

    public enum JellyType {green, blue, pink }
}