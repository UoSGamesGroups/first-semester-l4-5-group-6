using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text VelocityText;
    private GameObject _player;
    private Rigidbody _playerRB;

	// Use this for initialization
	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
	    _playerRB = _player.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update ()
	{
	    VelocityText.text = "<b>Velocity</b>\n" +
	                        "F: " + _player.transform.InverseTransformDirection(_playerRB.velocity).z.ToString("F") + "\n" + 
                            "S: " + Mathf.Abs(_player.transform.InverseTransformDirection(_playerRB.velocity).x).ToString("F");
	}
}
