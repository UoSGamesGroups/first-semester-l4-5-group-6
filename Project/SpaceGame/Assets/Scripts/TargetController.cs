using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TargetController : MonoBehaviour
{
    public GameObject Player;
    private PlayerController _pc;

	// Use this for initialization
	void Start ()
	{
	    _pc = Player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision coll)
    {
        print("Collided with: " + coll.gameObject.name);

        if (coll.gameObject.tag == "Pickup" && LevelController.RoundStarted)
        {
            Destroy(coll.gameObject);
            _pc.Score++;
        }
    }
}
