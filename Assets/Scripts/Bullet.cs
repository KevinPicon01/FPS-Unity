using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float time;
    
    [SerializeField] private float lifeTime;

    private void Start()
    {
        time = Time.time;
    }

    private void Update()
    {
        if (Time.time - time > lifeTime) DestroyImmediate(gameObject);
    }
    
    
    
    
}
