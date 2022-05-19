using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
    public static CharacterMove data;
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 10.0f;
    public Animator playerAnimController;
    Rigidbody body;

    private Vector3 playerMovement;

    private bool freeze;

    void Awake()
    {
        data = this;
    }
    void Start()
    {
        freeze = false;
        body = GetComponent<Rigidbody>();

        playerAnimController.SetBool("isWalking", false);
    }

    void FixedUpdate()
    {
        if (!freeze)
        {
            SetPlayerMovement();
            MovePlayer();
            RotatePlayer();
        }
    }

    void SetPlayerMovement()
    {
        //Debug.Log(fHorizontal + fVertical);

        if (Mathf.Abs(playerMovement.x) + Mathf.Abs(playerMovement.z) <= 0)
        {
            playerAnimController.SetBool("isWalking", false);
        }
        else
        {
            playerAnimController.SetBool("isWalking", true);
        }

    }

    public void OnMove(InputValue value)
    {
        if (playerAnimController.GetBool("isFishing"))
        {
            return;
        }
        Vector2 input = value.Get<Vector2>();
        playerMovement = new Vector3(input.x, 0, input.y);
    }

    void MovePlayer()
    {
        playerMovement = playerMovement.normalized * moveSpeed * Time.fixedDeltaTime;
        body.MovePosition(body.position + playerMovement);
    }

    void RotatePlayer()
    {
        if (playerMovement == Vector3.zero)
        {
            return;
        }

        body.rotation = Quaternion.Slerp(body.rotation, Quaternion.LookRotation(playerMovement), rotateSpeed * Time.fixedDeltaTime);
    }

    public void Purchase()
    {
        freeze = true;
        playerAnimController.SetTrigger("Payment");

    }
    public void PurchaseEnd()
    {
        freeze = false;
        playerAnimController.SetTrigger("PaymentEnd");
    }
}