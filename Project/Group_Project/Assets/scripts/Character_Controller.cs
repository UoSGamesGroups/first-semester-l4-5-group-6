using UnityEngine;
using UnityEngine.UI;

public class Character_Controller : MonoBehaviour {
    
    private Rigidbody2D rb;
    private Rigidbody2D cuberb;
    public KeyCode UpKey, DownKey, LeftKey, RightKey;
    public float MaxVelocity;
    public Text velocityText;
    [Range(1f, 100f)]
    public float Velocity = 10f;



    public AudioClip PropellantJets;
    private AudioSource source;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Make movement keys adjustable by Designers.
        if (Input.GetKey(UpKey)) // Up
        {
            rb.AddForce(Vector2.up * Time.deltaTime * Velocity * 1000);
            source.PlayOneShot(PropellantJets);
        }
        if (Input.GetKey(DownKey)) // Down
        {
            rb.AddForce(Vector2.down * Time.deltaTime * Velocity * 1000);
        }
        if (Input.GetKey(LeftKey)) // Left 
        {
            rb.AddForce(Vector2.left * Time.deltaTime * Velocity * 10000);
        }
        if (Input.GetKey(RightKey)) // Right
        {
            rb.AddForce(Vector2.right * Time.deltaTime * Velocity * 10000);
        }

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxVelocity);

        // Debug velocity text.
        //TODO: Move this to a UI Controller.
        velocityText.text = "Velocity X: " + rb.velocity.x + "\n"
                          + "Velocity Y: " + rb.velocity.y + "\n"
                          + "Magnitude: " + rb.velocity.magnitude;
    }

    void OnCollisionEnter2D(Collider cube)
    {

        if (cube.gameObject.tag.Equals("xblock") == true)
        {
            return;
        }
    }



}
