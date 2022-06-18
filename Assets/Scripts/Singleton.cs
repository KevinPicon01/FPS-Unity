using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    [Header("Data")]
    public int animation;
    public static Singleton inst;
    
    private void Awake()
    {
        if (Singleton.inst == null)
        {
            Singleton.inst=this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
}
