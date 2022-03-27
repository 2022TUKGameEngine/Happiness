using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
  public float moveSpeed = 10.0f;
  Rigidbody body;

  public Vector3 Dir;
  
  void Start()
  {
     body = GetComponent<Rigidbody>();
  }
  
  void FixedUpdate()
  {  

    Dir=new Vector3(Input.GetAxis("Horizontal"),0 , Input.GetAxis("Vertical"));
  //  body.position += new Vector3(Input.GetAxis("Horizontal"),0 , Input.GetAxis("Vertical"))
  //   * moveSpeed * Time.fixedDeltaTime;

  body.position+=Dir*moveSpeed*Time.fixedDeltaTime;

  if(Dir!=Vector3.zero)
  {
    float angle=Mathf.Atan2(Dir.x,Dir.z)*Mathf.Rad2Deg;

    //body.rotation=Quaternion.Euler(0,angle,0);

    body.rotation = Quaternion.Slerp(body.rotation, Quaternion.Euler(0, angle, 0), moveSpeed * Time.fixedDeltaTime);
  }
  }
}