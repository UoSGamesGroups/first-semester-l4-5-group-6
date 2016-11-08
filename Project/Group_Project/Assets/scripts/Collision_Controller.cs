using UnityEngine;
using System.Collections;

public class Collision_Controller : MonoBehaviour {


    private Rigidbody2D cuberb;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	GetComponent<Rigidbody>().velocity = Vector3.zero;

	}

    void OnCollisionEnter2D(Collider cube)
    {

        if (cube.gameObject.tag.Equals("switch") == true)
        {
            return;
        }
    }




    //void onCollisionEnter(Collision c)
    //{
    //    float force = 100;

    //    if (c.gameObject.tag == "block")
    //    {
    //        cuberb = gameObject.GetComponent<Rigidbody2D>();
    //        Vector3 dir = c.contacts[0].point - transform.position;

    //        dir = dir.normalized;

    //        GetComponent<Rigidbody>().AddForce(dir * force);



    //    }

    //}


    //public float pushPower = 2.0f;
    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    Rigidbody body = hit.collider.attachedRigidbody;

    //    //if (body == null || body.velocity)
    //    //{
    //    //    return;
    //    //}
    //    //if (hit.moveDirection.y < -0.3f)
    //    //{
    //    //    return; 
    //    //}
    //    Vector3 pushDir = new Vector2(hit.moveDirection.x, 0);
    //    body.velocity = pushDir * pushPower;


    //}
}
