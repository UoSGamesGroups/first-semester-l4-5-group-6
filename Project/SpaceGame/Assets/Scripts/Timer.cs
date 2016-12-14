using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Mono.Security;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public float RoundTime;
    public KeyCode RoundStartKey;

    public static float RoundTimeLeft;
	// Update is called once per frame
    void Start()
    {
        ResetTimer();
    }
	void Update () {
	    if (Input.GetKeyDown(RoundStartKey) && LevelController.RoundStarted == false)
	    {
            ResetTimer();
            LevelController.RoundStarted = true;
	    }
	    if (LevelController.RoundStarted)
	    {
	        if (RoundTimeLeft > 0)
	        {
                RoundTimeLeft -= Time.deltaTime;
	        }
	        else
	        {
                LevelController.RoundStarted = false;
	        }
	    }
        // F1 Means to 1 decimal place.
        TimerText.text = RoundTimeLeft.ToString("F1");
	}

    void ResetTimer()
    {
        RoundTimeLeft = RoundTime;
    }
}
