using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Throwable : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 oldMouse;
    private Vector3 mouseSpeed;
    public int speed;
    public Camera cam;


    void Start()
    {
        cam = GameObject.Find("Camera").GetComponent<Camera>();
    }

    void OnMouseDown()
    {
        oldMouse = Input.mousePosition;
        screenPoint = cam.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        //Vector3 curScreenPoint = new Vector3(cam.transform.position.x, cam.transform.position.y, screenPoint.z);
        Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    void OnMouseUp()
    {
        mouseSpeed = oldMouse - Input.mousePosition;
        GetComponent<Rigidbody>().AddForce(mouseSpeed * speed * -1, ForceMode.Force);
    }
}
