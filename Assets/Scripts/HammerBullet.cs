using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBullet : MonoBehaviour
{
    public bool back;
    public float speed;
    public Transform target;
    public GameObject orginial;
  
    // Update is called once per frame
    void Update()
    {
        if (back)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            if (transform.position == target.position)
            {
                orginial.SetActive(true);
                AutoDestroy();
            }
        }
    }
    
    public void AutoDestroy()
    {
        orginial.GetComponent<Weapons>().isFiring = false;
        Destroy(gameObject);
    }
}
