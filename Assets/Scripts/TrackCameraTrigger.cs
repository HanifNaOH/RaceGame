using UnityEngine;

public class TrackCameraTrigger : MonoBehaviour
{
    public int index;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (index < 0)
            {
                CameraManager.Instance.SwitchBackCamera();
            }
            else 
                CameraManager.Instance.SwitchToTrackCamera(index);
        }
    }
}
