using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CarSpeedHandler : MonoBehaviour
{
    public TMP_Text EnergyText;
    public TMP_Text TireText;
    public TMP_Text SpeedText; // Text to display the car's current speed
    public Car Car;
    public float highSpeed = 40;
    public float normalSpeed = 30;
    public float lowSpeed = 20;
    public float breakSpeed = 15;
    public float Energy = 100f;
    public float TireCondition = 100f;
    private float _energyRate;
    private float _tireRate;
    public float energyRate = 5;
    public float tirerate = 0.7f;
    public bool isAi;
    public bool isChargingEnergy = false;
    public bool TireWornDown = false;
    private bool SavingTire;
    public EnergyUI EnergySlider; // Slider for energy UI
    public TyreWearUI TireSlider; // Slider for tire UI
    public NewSpeedometer speedometer;

    void Start()
    {
        ChangeSpeedNormal();
    }
    void Update()
    {
        if (EnergyText != null)
            EnergyText.text = "Energy: " + Mathf.Round(Energy).ToString();
        if (TireText != null)
            TireText.text = "Tire: " + Mathf.Round(TireCondition).ToString();
        if (SpeedText != null && Car.navMeshAgent != null)
        {
            float currentSpeed = Car.navMeshAgent.velocity.magnitude;
            SpeedText.text = "Speed: " + Mathf.RoundToInt(currentSpeed).ToString() + " km/h";
        }
        Ai();
        if (Energy <= 0)
        {
            ChangeSpeedNormal();
        }
        if (TireCondition <= 0)
        {
            CarBrokeDown();
            TireWornDown = true;
        }
        Energy += _energyRate * Time.deltaTime;
        TireCondition += _tireRate * Time.deltaTime;
        Energy = Mathf.Clamp(Energy, 0, 100);
        TireCondition = Mathf.Clamp(TireCondition, 0, 100);
        if (Car.pitting == true)
        {
            TireWornDown = false;
            TireCondition = 100f;
        }
        if (EnergySlider != null)
        {
            EnergySlider.UpdateEnergyUI(Energy); // Update energy slider directly with 0-100 range
        }
        if (TireSlider != null)
        {
            TireSlider.UpdateTyreUI(TireCondition);
        }
    }
    [ContextMenu("Change Speed High")]
    public void ChangeSpeedHigh()
    {
        if (TireWornDown)
            return;
        if(speedometer != null)
            speedometer.HighSpeedUI();
        Car.maxSpeed = highSpeed;
        _energyRate = -1 * energyRate;
        _tireRate = -2 * tirerate;
    }
    [ContextMenu("Change Speed Normal")]
    public void ChangeSpeedNormal()
    {
        if (TireWornDown)
            return;
        if(speedometer != null)
            speedometer.MedSpeedUI();
        Car.maxSpeed = normalSpeed;
        _energyRate = 1;
        _tireRate = -1 * tirerate;
    }
    [ContextMenu("Change Speed Low")]
    public void ChangeSpeedLow()
    {
        if (TireWornDown)
            return;
        if(speedometer != null)
            speedometer.LowSpeedUI();
        Car.maxSpeed = lowSpeed;
        _energyRate = 1 * energyRate;
        _tireRate = -0.3f * tirerate;
    }
    public void CarBrokeDown()
    {
        if(speedometer != null)
            speedometer.BrokeSpeedUI();
        Car.maxSpeed = breakSpeed;
        _energyRate = 1 * 0f;
    }
    public void Ai()
    {
        if (!isAi)
            return;

        if (Energy >= 100 && TireCondition > 30 && !SavingTire)
        {
            ChangeSpeedHigh();
            isChargingEnergy = false;
        }
        else if (Energy <= 0)
        {
            ChangeSpeedLow();
            isChargingEnergy = true;
        }
        else if (isChargingEnergy && Energy > 30)
        {
            ChangeSpeedNormal();
        }
        if (TireCondition <= 32 && !SavingTire)
        {
            if (Random.Range(0, 2) == 0)
            {
                SavingTire = true;
            }
            else
            {
                Car.pitLap = true;
            }

        }
        else if (TireCondition < 20 && SavingTire)
        {
            isChargingEnergy = false;
            ChangeSpeedLow();
            Car.pitLap = true;
        }
        if (Car.pitting == true)
        {
            SavingTire = false;
        }
    }
}
