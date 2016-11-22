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
        if(coll.gameObject.name.Contains("Crate"))
        {
            Destroy(coll.gameObject);
            _pc.Score++;
        }
    }
}
