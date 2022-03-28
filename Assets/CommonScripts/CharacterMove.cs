using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
  public float moveSpeed = 10.0f;
  public float rotateSpeed = 10.0f;
  public Animator playerAnimController;
  Rigidbody body;

  private float fHorizontal;
  private float fVertical;
  private Vector3 playerMovement;

  void Start()
  {
    body = GetComponent<Rigidbody>();
     
    playerAnimController.SetBool("isWalking", false);
  }
  
  void Update()
  {  
    SetPlayerMovement();
    MovePlayer();
    RotatePlayer();
  }

  void SetPlayerMovement()
  {
    fHorizontal = Input.GetAxis("Horizontal");
    fVertical = Input.GetAxis("Vertical");

    //Debug.Log(fHorizontal + fVertical);

    if (Mathf.Abs(fHorizontal) + Mathf.Abs(fVertical) <= 0)
    {
      playerAnimController.SetBool("isWalking", false);
    }
    else
    {
      playerAnimController.SetBool("isWalking", true);
    }
    
    playerMovement.Set(fHorizontal,0,fVertical);
  }

  void MovePlayer()
  {
    playerMovement = playerMovement.normalized*moveSpeed*Time.fixedDeltaTime;
    body.MovePosition(body.position + playerMovement);
  }

  void RotatePlayer()
  {
    if (fHorizontal == 0 && fVertical == 0) {
      return;
    }

    body.rotation = Quaternion.Slerp(body.rotation,Quaternion.LookRotation(playerMovement), rotateSpeed * Time.fixedDeltaTime);
  }
}