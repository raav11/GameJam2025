using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float walkSpeed = 3f;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpPower = 8.5f;
    [SerializeField] float gravity = 10f;
    [SerializeField] float lookSpeed = 2f;
    [SerializeField] float lookXLimit = 45f;
    [SerializeField] float defaultHeight = 2f;
    [SerializeField] float crouchHeight = 1f;
    [SerializeField] float crouchSpeed = 2f;
    private float speed = 1f;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] clips;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;

    private bool canMove = true;

    private float cooldown = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {


        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftControl) && canMove)
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;

        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = 3f;
            runSpeed = 5f;

        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {

            speed = 0.5f;

        }

        else
        {

            speed = 1f;

        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {

            cooldown += Time.deltaTime;

            if (cooldown >= speed)
            {

                int clip = Random.Range(0, clips.Length);
                source.PlayOneShot(clips[clip]);

                cooldown = 0;

            }

        }


    }
}