using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    [SerializeField] private Image[] batteryBars; // Array to hold the 6 battery bar images

    public void UpdateBatteryUI(int energy)
    {
        int barsToShow = Mathf.Clamp(energy / 16, 0, 6); // Calculate the number of bars to show (0-6)

        for (int i = 0; i < batteryBars.Length; i++)
        {
            batteryBars[i].enabled = i < barsToShow; // Enable or disable bars based on energy level
        }
    }
}