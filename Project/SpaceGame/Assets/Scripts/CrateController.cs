using UnityEngine;
using System.Collections;

public class CrateController : MonoBehaviour
{

    public Camera cam;
    private RaycastHit hit;
    private Color meshColor;

	// Use this for initialization
	void Start ()
	{
	    cam = GameObject.Find("Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(Controls.ActionKey))
	    {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = new Color(gameObject.GetComponent<MeshRenderer>().material.color.r, gameObject.GetComponent<MeshRenderer>().material.color.g, gameObject.GetComponent<MeshRenderer>().material.color.b, 128);
                }
            }
        }
	
	}


}
