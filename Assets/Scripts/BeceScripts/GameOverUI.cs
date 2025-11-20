using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Image[] driverImages;

    public void ShowResults()
    {
        var manager = DriverStandingManager.Instance;
        var standings = manager.raceStandings;

        for (int i = 0; i < driverImages.Length; i++)
        {
            if (i < standings.Count && standings[i] != null && standings[i].driverSprite != null)
            {
                driverImages[i].sprite = standings[i].driverSprite;
                driverImages[i].enabled = true;
            }
            else
            {
                driverImages[i].sprite = null;
                driverImages[i].enabled = false;
            }
        }
    }
}
