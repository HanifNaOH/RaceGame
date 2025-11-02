using UnityEngine;
using UnityEngine.UI;

public class NewSpeedometer : MonoBehaviour
{   
    [SerializeField] private Sprite lowSpeed;
    [SerializeField] private Sprite medSpeed;
    [SerializeField] private Sprite highSpeed;
    private Image image;
    void Awake()
    {
        image = GetComponent<Image>();
    }
    public void LowSpeedUI()
    {  
       image.sprite = lowSpeed; 
    }
    public void MedSpeedUI()
    {  
       image.sprite = medSpeed; 
    }
    public void HighSpeedUI()
    {  
       image.sprite = highSpeed; 
    }
    public void BrokeSpeedUI()
    {  
       image.sprite = lowSpeed; 
    }
}
