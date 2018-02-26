using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroPlayerDirection : MonoBehaviour
{
	private GameObject playerGameObject;
	public GameObject dot;
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
        if (playerGameObject != null)
        {
            if (playerGameObject.GetComponent<Rigidbody>())
            {
                Rigidbody rb = playerGameObject.GetComponent<Rigidbody>();
                Vector2 v = new Vector2((rb.velocity.x * 200), (rb.velocity.z * 200));

                if (v.x > 100)
                    v.x = 100;
                if (v.x < -100)
                    v.x = -100;
                if (v.y > 100)
                    v.y = 100;
                if (v.y < -100)
                    v.y = -100;

                v.x += offset.x;
                v.y += offset.y;

                //Debug.Log(v);

                gameObject.transform.localPosition = v;
            }
        }
    }
}
