using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
	[Serializable]
    public class KeyType {
		public bool Red = false;
		public bool Blue = false;
    }

	[SerializeField]
	public KeyType keyType = new KeyType();
}
