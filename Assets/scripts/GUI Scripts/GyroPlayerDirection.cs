using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroPlayerDirection : MonoBehaviour
{
	private GameObject playerGameObject;
	public GameObject dot;
	public float multiplier = 1f;
	public Vector2 offset = new Vector2();

	void Start()
	{
		playerGameObject = GameObject.Find("Player");
		if(playerGameObject != null)
		{
			Debug.Log("Player found");
		}
		else
		{
			Debug.Log("Player not found");
			gameObject.SetActive(false);
		}
	}

	void Update()
	{
		Rigidbody rb = playerGameObject.GetComponent<Rigidbody>();
		Vector2 v = new Vector2((rb.velocity.x * multiplier) + offset.x, (rb.velocity.z * multiplier) + offset.y);
		transform.localPosition = v;
	}
}
