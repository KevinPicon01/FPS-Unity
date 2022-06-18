using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
   [Header("Data")]
   [SerializeField] private RuntimeAnimatorController[] animatorControllers;
   [SerializeField] private GameObject model;

   [Header("Singleton")]
   [SerializeField] public Singleton mySesion;
   private int animationIndex;

   private void Start()
   {
      mySesion = FindObjectOfType<Singleton>();
      animationIndex = mySesion.animation;
      model.GetComponent<Animator>().runtimeAnimatorController = animatorControllers[animationIndex];
   }

   public void PlayAnimator(int index)
   {
      model.GetComponent<Animator>().runtimeAnimatorController = animatorControllers[index];
      mySesion.animation = index;
   }
   
   public void CScene()
   {
      SceneManager.LoadScene("Play");
   }
}
