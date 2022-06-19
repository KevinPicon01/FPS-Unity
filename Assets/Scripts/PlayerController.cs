using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private float speed;
    [SerializeField] private float sensibility;
    [SerializeField] private WeaponsController weaponsController;
    [SerializeField] private AudioClip[] footSteps;
    private float xRotation;
    private float yRotation;
    private float gravity = -9.81f;
    private AudioSource audioSource;
    private int n;
    private bool alt;
    private float time;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
        
        //Llamar cada 0,5 segundo una funcion que cambie el sonido de los pies
        var x = (int)Time.time;
        var t = Time.time;

        if (Time.time - time > 0.3f && transform.GetComponent<CharacterController>().isGrounded)
        {
            time = Time.time;
            n = UnityEngine.Random.Range(0, footSteps.Length);
            audioSource.clip = footSteps[n];
            audioSource.Play();
            //PlayFootStepAudio();
        }

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
            weaponsController.DisableWeapons(0);
        }
        else if (other.gameObject.CompareTag("Arma Atrayente"))
        {
            weaponsController.status = 2;
            weaponsController.DisableWeapons(1);
        }
        else if (other.gameObject.CompareTag("Arma Laser"))
        {
            weaponsController.status = 3;
            weaponsController.DisableWeapons(2);
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
            weaponsController.DisableWeapons(3);
        }
    }
}

