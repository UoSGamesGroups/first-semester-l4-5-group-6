using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int Score = 0;
    public int PickupRange = 10;
    public GameObject CrateContainer;
    private GameObject pickedUp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * PickupRange, Color.blue);
        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, PickupRange))
            {
                if(hit.collider.gameObject.tag == "Pickup")
                {
                    if(pickedUp == null)
                    {
                        pickedUp = hit.collider.gameObject;
                        pickedUp.transform.SetParent(Camera.main.transform);
                    }
                }

            }
        } else
        {
            if(pickedUp != null)
            {
                pickedUp.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * 100, ForceMode.Impulse);
                pickedUp.transform.SetParent(CrateContainer.transform);
                pickedUp = null;
            }
        }
    }
}
