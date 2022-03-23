using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
  public float moveSpeed = 10.0f;
  Rigidbody body;

  private float fHorizontal;
  private float fVertical;
  private Vector3 playerMovement;

  void Start()
  {
     body = GetComponent<Rigidbody>();
  }
  
  void FixedUpdate()
  {  
    SetPlayerMovement();
    MovePlayer();
  }

  void SetPlayerMovement()
  {
    fHorizontal = Input.GetAxis("Horizontal");
    fVertical = Input.GetAxis("Vertical");
    
    playerMovement.Set(fHorizontal,0,fVertical);
  }

  void MovePlayer()
  {
    playerMovement = playerMovement.normalized*moveSpeed*Time.fixedDeltaTime;
    body.MovePosition(transform.position + playerMovement);
  }
  }
}