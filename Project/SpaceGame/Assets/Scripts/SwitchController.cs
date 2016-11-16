using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

    public GameObject Door1Button;
    private Rigidbody DoorButtonCube;


    string whatDoor;
	// Use this for initialization
	void Start () {

       DoorButtonCube = gameObject.GetComponent<Rigidbody>();

        //if ()
        //{
        //    whatDoor = "Door1";
        //    //onMouseDown();

        //}
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    

    void OnMouseDown()
    {
        
        if (gameObject.name == "Door1Button")
        {
            
            GameObject.Find("SlidingDoor").GetComponent<ObjectAnimations>().locked = true;
            GameObject.Find("SlidingDoor").GetComponent<ObjectAnimations>().doWeOpen();

        }

    }
}
