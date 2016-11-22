using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text VelocityText;
    public Text FPSText;
    public Text ScoreText;
    private GameObject _player;
    private Rigidbody _playerRB;
    private PlayerController _pc;

	// Use this for initialization
	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
	    _playerRB = _player.GetComponent<Rigidbody>();
	    _pc = _player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    VelocityText.text = "<b>Velocity</b>\n" +
	                        "F: " + _player.transform.InverseTransformDirection(_playerRB.velocity).z.ToString("F") + "\n" + 
                            "S: " + Mathf.Abs(_player.transform.InverseTransformDirection(_playerRB.velocity).x).ToString("F");
	    FPSText.text = "<b>FPS: </b> " + (1.0f/Time.smoothDeltaTime).ToString("F0");
	    ScoreText.text = "Score: " + _pc.Score;
	}
}
