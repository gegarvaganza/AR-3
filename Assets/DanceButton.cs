using UnityEngine;

public class DanceButton : MonoBehaviour
{
    public void OnDanceButtonPressed()
    {
        if (ARDanceController.Current != null)
        {
            ARDanceController.Current.PlayDance();
        }
        else
        {
            Debug.Log("No AR model detected yet");
        }
    }
}
