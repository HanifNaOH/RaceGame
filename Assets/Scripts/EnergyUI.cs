using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    [SerializeField] private Image energySlider; // Slider to represent energy level
    private float fillSpeed = 5f;
    private float targetFill = 1f;

    public void UpdateEnergyUI(float energy)
    {
        Debug.Log($"Updating energy: {energy}");
        energySlider.fillAmount = Mathf.Clamp01(energy / 100f); // Update slider value (0 to 1)
    }
    private void Update()
    {
        energySlider.fillAmount = Mathf.Lerp(energySlider.fillAmount, targetFill, Time.deltaTime * fillSpeed);
    }
}