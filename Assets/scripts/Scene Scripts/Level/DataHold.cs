using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHold : MonoBehaviour
{
    public int Level = 0;

    private void Start()
    {
        if (Level == 0)
            throw new IndexOutOfRangeException();
    }
}
