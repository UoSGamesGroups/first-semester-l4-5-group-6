using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour {

    //with thrust im assuming it is based in M p/s as thats what Unity works in. 
    public float thrust = 0.5f;
    public Rigidbody2D rb;


    //Speed
    public float speed = 0;

    //Control Strings
    public string up_Key;
    public string down_Key;
    public string left_Key;
    public string right_Key;
   

    private GUIText score_Text;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();


    }

   //Float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
   // {
       // return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;

   // }



     void Update()
    {


        //  IGNORE ALL OF THIS, TRYING OUT ROTATIONS

        //get the screen positions of the object
        // Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //get the screen positon of the mouse
        // Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //get the angle between the points
        // float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);


        //transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

      //  Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
       // Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
       // lookPos = lookPos - transform.position;
       // float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
       // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


  //  Vector3 lastPosition = Vector3.zero;


    void FixedUpdate()
    {

        

        if (Input.GetKey(up_Key))
        {
            rb.AddForce(Vector2.up * thrust);
            Terminal_Velocity();
        }
        else if (Input.GetKey(down_Key))
        {
            rb.AddForce(Vector2.down * thrust);
            Terminal_Velocity();
        }
        else if (Input.GetKey(right_Key))
        {
            rb.AddForce(Vector2.right * thrust);
            Terminal_Velocity();
        }
        else if (Input.GetKey(left_Key))
        {
            // rb.AddForce(Vector2(-1, 0) * 10); <- this is needed for more ease of directional flight
            rb.AddForce(Vector2.left * thrust);
            Terminal_Velocity();
        }




        //trying to display a speed per second kinda thnig. Not working yet D.B
       // speed = (transform.position - lastPosition).magnitude;
      //  lastPosition = transform.position;
      //  score_Text.text = speed + "km p/h";





    }
    public void Terminal_Velocity()
    {
        if (thrust != 100)
        {
            thrust = thrust + 0.5f; //if thrust is not to high carry on increasing, Mayabe turn this into Termial Veloicy or some sort?
        }



    }
    // Update is called once per frame


}
