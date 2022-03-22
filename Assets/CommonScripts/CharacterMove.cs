using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
  public float moveSpeed = 10.0f;
  Rigidbody body;
  
  void Start()
  {
     body = GetComponent<Rigidbody>();
  }
  
  void FixedUpdate()
  {  
   body.position += new Vector3(Input.GetAxis("Horizontal"),0 , Input.GetAxis("Vertical"))
    * moveSpeed * Time.fixedDeltaTime;
  }
}