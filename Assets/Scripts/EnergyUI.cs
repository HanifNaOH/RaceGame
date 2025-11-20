using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    [SerializeField] private Image energySlider;
    public void UpdateEnergyUI(float energy)
    {
        Debug.Log($"Updating energy: {energy}");
        energySlider.fillAmount = Mathf.Clamp01(energy / 100f);
    }
}