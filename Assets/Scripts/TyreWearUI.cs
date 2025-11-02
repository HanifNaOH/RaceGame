using UnityEngine;
using UnityEngine.UI;

public class TyreWearUI : MonoBehaviour
{
    [SerializeField] private Image tyreSlider; // Slider to represent energy level
    private float fillSpeed = 5f;
    private float targetFill = 1f;

    public void UpdateTyreUI(float tyre)
    {
        tyreSlider.fillAmount = Mathf.Clamp01(tyre / 100f); // Update slider value (0 to 1)
    }
    private void Update()
    {
        tyreSlider.fillAmount = Mathf.Lerp(tyreSlider.fillAmount, targetFill, Time.deltaTime * fillSpeed);
    }
}