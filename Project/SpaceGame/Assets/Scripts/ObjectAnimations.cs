using UnityEngine;
using System.Collections;

public class ObjectAnimations : MonoBehaviour {

    private Rigidbody rb;
    
   //does the door need to be opened, has a button been pushed to open it    
    private bool doorLocked = true;
    public bool door1Open = false;


    public bool locked = false;



    private float defaultPosition; //the default positon
    public float movementHeight = 15.0f; // How far we want the door to move upwards
    

    // Use this for initialization
    void Start () {

        
        rb = gameObject.GetComponent<Rigidbody>();
        defaultPosition = transform.position.y;
    }
	
	// Update is called once per frame
	public void Update () {
        
        
        
    }
    public void doWeOpen()
    {


        float maxOpen;
        var currentPos = transform.position.y; //place the y co-ord value in the current pos - this will change
        maxOpen = defaultPosition + movementHeight;   //create a max value that can be edited. this is the max the door can move. 


        while (currentPos < maxOpen)
        {
            animationZ(); //pull the door towards or away animation
            animationY(); //pull the door up or down animation
                          //make sure the current position of the door is known
            currentPos = transform.position.y;

        }


        //if (currentPos <= maxOpen) // if the current position is less or equal too then keep going
        //{
        //    animationZ(); //pull the door towards or away animation
        //    animationY(); //pull the door up or down animation
        //    currentPos = transform.position.y; //make sure the current position of the door is known
        //}
        //else
        //{
        //    return;
        //}


    }
    public void animationY()
    {
        rb.MovePosition(transform.position + transform.up * Time.deltaTime * 2);
        
    }
    public void  animationZ()
    {
        //rb.MovePosition(transform.Translate(0, 1, 0));

    }
}
