using UnityEngine;
using System.Collections;

public enum DoorState
{
    Closed,
    Open
}

public class DoorController : MonoBehaviour
{

    public float MaxHeight;
    public float MovementSpeed;
    public DoorState State = DoorState.Closed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void MoveDoorUp()
    {
        Debug.Log("Moving Door Up");
        //for (var i = transform.position.y; i < transform.position.y + MaxHeight; i += MovementSpeed)
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y + i, transform.position.z);
        //}
        transform.position = new Vector3(transform.position.x, transform.position.y + MaxHeight, transform.position.z);
        State = DoorState.Open;
    }

    void MoveDoorDown()
    {
        Debug.Log("Moving Door Down");
        //for (var i = transform.position.y; i < transform.position.y - MaxHeight; i -= MovementSpeed)
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y + i, transform.position.z);
        //}
        transform.position = new Vector3(transform.position.x, transform.position.y - MaxHeight, transform.position.z);
        State = DoorState.Closed;
    }

    public void MoveDoor()
    {
        switch (State)
        {
                case DoorState.Closed:
                MoveDoorUp();
                break;
                case DoorState.Open:
                MoveDoorDown();
                break;
        }
    }



}
