using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    [SerializeField] private Slider energySlider; // Slider to represent energy level

    public void UpdateEnergyUI(float energy)
    {
        energySlider.value = Mathf.Clamp01(energy / 100f); // Update slider value (0 to 1)
    }
}