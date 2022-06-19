using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    private float time = 0.5f;

    private void Update()
    {
        if (Time.time > time)
        {
            gameObject.SetActive(false);
        }
    }
}
