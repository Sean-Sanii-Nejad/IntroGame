using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

     public Vector2 moveValue ;
     public float speed ;
     private int count;
     private int numPickups = 5;
     public Text scoreText;
     public Text winText;
     

     void Start()
     {
         count = 0;
         winText.text = "";
         SetCountText();
     }
     void OnMove ( InputValue value ) 
     {
        moveValue = value . Get < Vector2 >() ;
     }
     void FixedUpdate () 
     {
         Vector3 movement = new Vector3 ( moveValue .x , 0.0f , moveValue . y );
         GetComponent<Rigidbody>().AddForce( movement * speed * Time.fixedDeltaTime );
     }
     
     void OnTriggerEnter ( Collider other ) {
          if (other.gameObject.tag == "PickUp")
          {
              count++;
              other.gameObject.SetActive(false);
              SetCountText();
          }
     }

     private void SetCountText()
     {
         scoreText.text = "Score: " + count.ToString();
         if (count >= numPickups)
         {
             winText.text = "You Win!";
         }
     }
 }
