using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Movement Variables

    public float speed;
    public FixedJoystick movementJoystick;
    private Rigidbody rb;

    #endregion

    public Animator playerAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        MovementHandler();
    }

    private void Update()
    {
        
    }

    private void MovementHandler()
    {
        Vector3 direction = Vector3.forward * movementJoystick.Vertical + Vector3.right * movementJoystick.Horizontal;
        rb.velocity = direction * speed;

        if(rb.velocity.magnitude > 0f)
        {
            playerAnimator.SetBool("isRunning", true);

            transform.rotation = Quaternion.LookRotation(direction);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }
    }
}
