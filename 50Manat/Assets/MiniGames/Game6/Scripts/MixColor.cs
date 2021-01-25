using UnityEngine;
namespace game6
{
    public class MixColor : MonoBehaviour
    {
        [SerializeField] private Color[] colors;

       public Color MixedColors(Color firstColor, Color secondColor)
       {
            for (int i = 0; i <= colors.Length; i++)
            {
                if (colors[i].createColorls[0] == firstColor.material)
                {
                    if (colors[i].createColorls[1] == secondColor.material)
                    {
                        return colors[i];
                    }
                }
                else if (colors[i].createColorls[1] == firstColor.material)
                {
                    if (colors[i].createColorls[0] == secondColor.material)
                    {
                        return colors[i];
                    }
                }
            }
            return null;
       }
    }
}