using UnityEngine;
using Yarn.Unity;
using TMPro;
using UnityEngine.UIElements;
public class RacingManager : MonoBehaviour
{
    public int totalLaps;
    public static RacingManager Instance;
    public int currentPosition;
    public float currentSpeed;
    public Car McCar;
    public DialogueRunner _dialogueRunner;
    private int lastPosition = 5;
    public TMP_Text positionText;
    public TMP_Text Lap;
    public bool GameCompleted = false;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        currentPosition = DriverStandingManager.Instance.raceStandings.IndexOf(McCar) + 1;
    }
    void Overtaking()
    {
        if (!_dialogueRunner.IsDialogueRunning)
        {
            _dialogueRunner.StartDialogue("Overtaking");
        }
    }
    void OverTaken()
    {
        if (!_dialogueRunner.IsDialogueRunning)
        {
            _dialogueRunner.StartDialogue("Overtaken");
        }
    }
    public void Pitting()
    {

         if (!_dialogueRunner.IsDialogueRunning)
        {
            _dialogueRunner.StartDialogue("Enterpit");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        positionText.text= "Position: " + currentPosition + "/" + DriverStandingManager.Instance.raceStandings.Count;
        currentSpeed = Mathf.Lerp(0f, 180f, McCar.navMeshAgent.velocity.magnitude / 40f);
        currentPosition = DriverStandingManager.Instance.raceStandings.IndexOf(McCar) + 1;
        if (McCar.lap > totalLaps && !GameCompleted)
        {
            Debug.Log("Game Completed");
            GameCompleted = true;
            StartCoroutine(CameraManager.Instance.SwitchToMenuCam(0f));
            Lap.text = "Lap: " + totalLaps + "/" + totalLaps;
        }
        else
            Lap.text = "Lap: " + McCar.lap + "/" + totalLaps;
        if (lastPosition > currentPosition)
        {
            Overtaking();
        }
        else if (lastPosition < currentPosition)
        {
            OverTaken();
        }
        lastPosition = currentPosition;
    }
}
