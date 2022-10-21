using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMovement : MonoBehaviour
{

    public Animator anim;
    public Vector3 moveDir;
    private CharacterController _charC;

    public float speed, jumpSpeed = 8, gravity = 20, crouch = 2.5f, walk = 5, run = 10;

    
    void Start()
    { // Get component that IS ATTACHED to THIS object. E.g Its attached to the model, so it will autofil in the Animator slot (Rather than click drag)
        anim = GetComponent<Animator>();
        anim.SetFloat("isCrouching", 1);
        _charC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(_charC.isGrounded == true)
        {
            anim.SetFloat("isCrouching", 1);
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            
            if (moveDir == Vector3.zero)
            {
                speed = 0;
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speed = run;
                }
                else if (Input.GetKey(KeyCode.LeftControl))
                {
                    speed = crouch;
                    anim.SetFloat("isCrouching", 0);
                }
                else
                {
                    speed = walk;
                }
            }

            anim.SetFloat("moveSpeed", speed);
            anim.SetFloat("horizontal", moveDir.x);
            anim.SetFloat("vertical", moveDir.y);
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
        }
        moveDir.y -= gravity * Time.deltaTime;
        _charC.Move(moveDir * Time.deltaTime);

    }

   

}
