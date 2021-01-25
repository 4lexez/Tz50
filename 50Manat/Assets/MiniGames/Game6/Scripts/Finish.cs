using UnityEngine;
namespace game6
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private Material myColor;
        private void OnCollisionEnter(Collision collision)
        {
            try
            {
               var player =  collision.gameObject.GetComponent<PlayerControl>();
                if (myColor == player.playerColor) Debug.Log("Finish!");
            }
            catch
            {
                return;
            }
            finally
            {
                
            }
        }
    }
}                       
