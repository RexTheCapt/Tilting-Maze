using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Key : MonoBehaviour
{
	[Serializable]
	public class KeyType{
		public bool Red = false;
		public bool Blue = false;
	}

	public AudioClip audioClip;
	[SerializeField]
	public KeyType keyType = new KeyType();

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Key");

            foreach (GameObject go in gameObjects)
            {
                if (go.GetComponent<Lock>())
                    if (go.GetComponent<Lock>().keyType.Red && keyType.Red)
                    {
                        Destroy(go);
                        PlaySound(other);
                    }
                    else if (go.GetComponent<Lock>().keyType.Blue && keyType.Blue)
                    {
                        Destroy(go);
                        PlaySound(other);
                    }
            }
        }
	}

	void PlaySound(Collider other)
	{
			other.gameObject.GetComponent<AudioSource>().clip = audioClip;
			other.gameObject.GetComponent<AudioSource>().Play();
			Destroy(gameObject);
	}
}
