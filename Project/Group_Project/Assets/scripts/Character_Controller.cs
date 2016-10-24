using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour {


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

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;

    }



     void Update()
    {

        //get the screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //get the screen positon of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);


        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }


    Vector3 lastPosition = Vector3.zero;


    void FixedUpdate()
    {

        

        if (Input.GetKey(up_Key))
        {
            rb.AddForce(Vector2.up * thrust);            
        }
        else if (Input.GetKey(down_Key))
        {
            rb.AddForce(Vector2.down * thrust);
        }
        else if (Input.GetKey(right_Key))
        {
            rb.AddForce(Vector2.right * thrust);
        }
        else if (Input.GetKey(left_Key))
        {
            // rb.AddForce(Vector2(-1, 0) * 10);
            rb.AddForce(Vector2.left * thrust);
        }




        //trying to display a speed per second kinda thnig. Not working yet D.B
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
        score_Text.text = speed + "km p/h";





    }

    // Update is called once per frame
   

}
