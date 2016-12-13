using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int Score = 0;
    public int PickupRange = 10;
    public GameObject CrateContainer;
    private GameObject pickedUp;
    [SerializeField] private MouseLook m_MouseLook;
	// Use this for initialization
	void Start () {
        m_MouseLook.Init(transform, Camera.main.transform);
    }
	
	// Update is called once per frame
	void Update () {
        RotateView();
	}

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * PickupRange, Color.blue);
        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, PickupRange))
            {
                if (hit.collider.gameObject.tag == "Pickup")
                {
                    if(pickedUp == null)
                    {
                    pickedUp = hit.collider.gameObject;
                        pickedUp.GetComponent<Rigidbody>().useGravity = false;
                        pickedUp.transform.SetParent(Camera.main.transform);
                    //pickedUp.transform.position = transform.TransformPoint(new Vector3(0, 0, 10));
                    }
                }

            }
        }
        else
        {
            if (pickedUp != null)
            {
                pickedUp.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * 100, ForceMode.Impulse);
                pickedUp.transform.SetParent(CrateContainer.transform);
                pickedUp.GetComponent<Rigidbody>().useGravity = true;
                pickedUp = null;
            }
        }

        m_MouseLook.UpdateCursorLock();
    }

    private void RotateView()
    {
        m_MouseLook.LookRotation(transform, Camera.main.transform);
    }
}
