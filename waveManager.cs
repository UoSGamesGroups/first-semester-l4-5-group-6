using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class waveManager : MonoBehaviour {

    public float waveNumber;
    public float firstTimer = 30.0f;

    public Text WaveCountText;
    public Text TimerText;
    public Text WaveStartText;

    public bool WaveActive;


    public float timeLeft;





	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown("o"))
        {
            //WaveActive = true;
        }

        if (WaveActive == true)
        {
            waveNumber++;
            WaveCountText.text = "Wave: " + waveNumber;
            timeLeft = firstTimer * waveNumber;
            
            StartTimer();
            
        }

        }
    
        public void StartTimer()
    {
        
            TimerText.text = "Time: " + timeLeft;
            timeLeft -= Time.deltaTime;       
        
           if(timeLeft < 0)
            {
            //WAVE END
            WaveActive = false;

            }
    }
    
}
