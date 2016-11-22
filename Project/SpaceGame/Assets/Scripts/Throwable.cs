using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Throwable : MonoBehaviour
{
    //private bool isDragging;
    //public Camera cam;
    //private Plane dragPlane;
    //private Vector3 moveTo;
    //private Rigidbody rb;
    //public float dragDamper;
    //public float addToY;

    //void Start()
    //{
    //    cam = GameObject.Find("Camera").GetComponent<Camera>();
    //    rb = GetComponent<Rigidbody>();
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //    float dist;
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            if (hit.transform.root.transform == transform)
    //            {
    //                isDragging = true;
    //                rb.useGravity = false;
    //                dragPlane = new Plane(Vector3.up, transform.position + Vector3.up * addToY);
    //            }
    //        }
    //    }
    //    if (isDragging)
    //    {
    //        bool hasHit = dragPlane.Raycast(ray, out dist);
    //        if (hasHit)
    //        {
    //            moveTo = ray.GetPoint(dist);
    //        }
    //    }
    //    if (Input.GetMouseButtonUp(0) && isDragging)
    //    {
    //        isDragging = false;
    //        rb.useGravity = true;
    //    }
    //}

    //void FixedUpdate()
    //{
    //    if (!isDragging) return;
    //    Vector3 velocity = moveTo - transform.position;
    //    rb.velocity = Vector3.Lerp(rb.velocity, velocity,
    //        dragDamper * Time.deltaTime);
    //}
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
