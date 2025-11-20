using UnityEngine;
using UnityEngine.UI;

public class TyreWearUI : MonoBehaviour
{
    [SerializeField] private Image tyreSlider; // Slider to represent energy level

    public void UpdateTyreUI(float tyre)
    {
        tyreSlider.fillAmount = Mathf.Clamp01(tyre / 100f); // Update slider value (0 to 1)
    }
}