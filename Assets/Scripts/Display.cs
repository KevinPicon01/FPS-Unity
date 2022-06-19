using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    private float time = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (Time.time > time)
        {
            gameObject.SetActive(false);
        }
        
    }
}
