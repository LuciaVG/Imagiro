using UnityEngine;
using System.Collections;

public class MainCharacter: MonoBehaviour
{
    public float speed = 8.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    float vertVel;
    //6 speed 5 jump 4 grav is glide; max distance is 15
    //8 speed 10 jump 20 grav is normal; max distance is 8.15
    //4 speed 16 jump 20 grav is high jump; max distance is 6.4

    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                speed = 6.0F;
                jumpSpeed = 5.0F;
                gravity = 4.0F;
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                speed = 8.0F;
                jumpSpeed = 10.0F;
                gravity = 20.0F;
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                speed = 4.0F;
                jumpSpeed = 16.0F;
                gravity = 20.0F;
            }
        }

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
                vertVel = jumpSpeed;
        }
        vertVel -= gravity * Time.deltaTime;
        moveDirection.y = vertVel;
        controller.Move(moveDirection * Time.deltaTime);
    }
}