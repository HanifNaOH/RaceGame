using UnityEngine;
using UnityEngine.UI;

public class TyreWearUI : MonoBehaviour
{
    [SerializeField] private Slider tyreWearSlider; // Slider to represent tyre wear

    public void UpdateTyreWearUI(float wearLevel)
    {
        tyreWearSlider.value = Mathf.Clamp01(wearLevel); // Update slider value (0 to 1)
    }
}