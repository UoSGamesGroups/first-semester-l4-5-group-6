using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;

public class CharacterMovement : MonoBehaviour
{
    [Range(1f, 100f)]
    public float SpeedModifier;
    [Range(0f, 1f)]
    public float StrafeSpeedRatio;

    [Range(10f, 300f)]
    public float LookSpeed;

    [Range(5f, 100f)]
    public float ForwardVelocityCap;

    [Range(-5f, -100f)]
    public float BackwardVelocityCap;

    [Range(5f, 100f)]
    public float StrafeVelocityCap;

    public KeyCode ForwardKey;
    public KeyCode StrafeLeftKey;
    public KeyCode StrafeRightKey;
    public KeyCode BackwardKey;

    private Rigidbody _rb;

    // Use this for initialization
    void Start ()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        // Rotation
        //transform.Rotate(new Vector3(0, Input.GetAxisRaw("Mouse X"), 0) * Time.deltaTime * LookSpeed);

        // Translation
        if (Input.GetKey(ForwardKey))
	    {
            if(transform.InverseTransformDirection(_rb.velocity).z < ForwardVelocityCap)
	            _rb.AddRelativeForce(Vector3.forward * Time.deltaTime * SpeedModifier, ForceMode.Impulse);
	    }
        if (Input.GetKey(BackwardKey))
        {
            if (transform.InverseTransformDirection(_rb.velocity).z > BackwardVelocityCap)
                _rb.AddRelativeForce(Vector3.back * Time.deltaTime * SpeedModifier, ForceMode.Impulse);
        }
        if (Input.GetKey(StrafeLeftKey))
        {
                _rb.AddRelativeForce(Vector3.left * Time.deltaTime * SpeedModifier * StrafeSpeedRatio, ForceMode.Impulse);
        }
        if (Input.GetKey(StrafeRightKey))
        {
                _rb.AddRelativeForce(Vector3.right * Time.deltaTime * SpeedModifier * StrafeSpeedRatio, ForceMode.Impulse);
        }

	    if (transform.InverseTransformDirection(_rb.velocity).x > StrafeVelocityCap)
	    {
	        _rb.velocity = new Vector3(StrafeVelocityCap, _rb.velocity.y, _rb.velocity.z);
	    }
        if (transform.InverseTransformDirection(_rb.velocity).x < -StrafeVelocityCap)
        {
            _rb.velocity = new Vector3(-StrafeVelocityCap, _rb.velocity.y, _rb.velocity.z);
        }
    }
}
