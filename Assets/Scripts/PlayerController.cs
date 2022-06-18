using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private float speed;
    [SerializeField] private float sensibility;
    [SerializeField] private WeaponsController weaponsController;
    
    private float xRotation;
    private float yRotation;
    private float gravity = -9.81f;
    
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        //Camera rotation
        yRotation += mouseX * sensibility;
        xRotation -= mouseY * sensibility;
        xRotation = Mathf.Clamp(xRotation, -70, 70);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        Cursor.lockState = CursorLockMode.Locked;
        
        //Player Move
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * moveHorizontal + moveVertical * transform.forward;
        transform.GetComponent<CharacterController>().Move(movement * speed * Time.deltaTime);
        
        //Player Gravity
        Vector3 gravityVector = new Vector3(0, gravity, 0);
        transform.GetComponent<CharacterController>().Move(gravityVector * Time.deltaTime);
    }

    //Player Switch Weapon
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arma Parabolica"))
        { 
            weaponsController.status = 1;
            weaponsController.DesactiveWeapons(0);
        }
        else if (other.gameObject.CompareTag("Arma Atrayente"))
        {
            weaponsController.status = 2;
            weaponsController.DesactiveWeapons(1);
        }
        else if (other.gameObject.CompareTag("Arma Laser"))
        {
            weaponsController.status = 3;
            weaponsController.DesactiveWeapons(2);
        }
    }

    //Player Out of the WeaponsZone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Arma Atrayente") || other.CompareTag("Arma Parabolica") || other.CompareTag("Arma Laser"))
        {
            
            try
            {
                weaponsController.weaponsAnim[weaponsController.status-1].SetActive(true);
                weaponsController.weapons[2].GetComponent<Weapons>().hammerBullets.GetComponent<HammerBullet>().AutoDestroy();
            }
            catch (Exception)
            {
                // ignored
            }
            weaponsController.DesactiveWeapons(3);
        }
    }
}

