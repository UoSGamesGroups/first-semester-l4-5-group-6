
using UnityEngine;
using System.Collections;
using UnityEngine.UI;





public class Enemy : MonoBehaviour {

	public float speed = 10f;

	public int Money = 1000;
	public int Basket = 0;

	public Color hoverColor;

	private Renderer rend;
	private Color startColor;


	private Transform target;

	private int wavepointIndex = 0;

	public Text CustomerStat;

	void Start ()
	{
		target = Waypoints.points[0];
		rend = GetComponent<Renderer>();
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
		CustomerStat.text = "Money: " + Money;
	}


	void Update ()
	{
		CustomerStat.text = "Money: " + Money;

		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}
	}


	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			Destroy(gameObject);
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}


	public void UpdateScore(int addedValue)
	{
		Money += addedValue;
	}



	void OnTriggerEnter(Collider other)
	{
				Money -=100;
				Basket += 100;
	}
		

	void OnMouseEnter ()
	{
		rend.material.color = hoverColor;
	}

	void OnMouseExit ()
	{
		rend.material.color = startColor;
	}


}


