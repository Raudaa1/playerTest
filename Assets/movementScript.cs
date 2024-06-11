using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour {

    public Animator playerAnimator;
    public Rigidbody playerRigidbody;
    public Transform playerTransform;

    public float w_speed = 1.0f;
    public float wb_speed = 1.0f;
    public float ro_speed = 200.0f;

    private void Update() {
        HandleAnimation();
        HandleRotation();
    }

    private void FixedUpdate() {
        HandleMovement();
    }

    private void HandleAnimation() {
        // Slow Forward Run
        if(Input.GetKeyDown(KeyCode.W)) {
            playerAnimator.SetTrigger("Slow_Run");
            playerAnimator.ResetTrigger("Idle");
        }
        if(Input.GetKeyUp(KeyCode.W)) {
            playerAnimator.SetTrigger("Idle");
            playerAnimator.ResetTrigger("Slow_Run");
        }

        // Backwards Walk
        if(Input.GetKeyDown(KeyCode.S)) {
            playerAnimator.SetTrigger("Walking_Backwards");
            playerAnimator.ResetTrigger("Idle");
        }
        if(Input.GetKeyUp(KeyCode.S)) {
            playerAnimator.SetTrigger("Idle");
            playerAnimator.ResetTrigger("Walking_Backwards");
        }

        // Crouch
        if(Input.GetKeyDown(KeyCode.C)) {
            playerAnimator.SetTrigger("Crouch");
            playerAnimator.ResetTrigger("Idle");
        }
        if(Input.GetKeyUp(KeyCode.C)) {
            playerAnimator.SetTrigger("Idle");
            playerAnimator.ResetTrigger("Crouch");
        }

        // Crouch Walking
        if(Input.GetKeyDown(KeyCode.C) && Input.GetKeyDown(KeyCode.W)) {
            playerAnimator.SetTrigger("Crouch_Walk");
            playerAnimator.ResetTrigger("Idle");
        }
        if(Input.GetKeyUp(KeyCode.C) && Input.GetKeyUp(KeyCode.W)) {
            playerAnimator.SetTrigger("Idle");
            playerAnimator.ResetTrigger("Crouch_Walk");
        }

        // Jumping
        if(Input.GetKeyDown(KeyCode.Space)) {
            playerAnimator.SetTrigger("Jumping");
            playerAnimator.ResetTrigger("Idle");
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            playerAnimator.SetTrigger("Idle");
            playerAnimator.ResetTrigger("Jumping");
        }
    }

    private void HandleMovement() {
        Vector3 movement = Vector3.zero;

        if(Input.GetKey(KeyCode.W)) {
            movement = transform.forward * w_speed * Time.fixedDeltaTime;
        } else if(Input.GetKey(KeyCode.S)) {
            movement = -transform.forward * wb_speed * Time.fixedDeltaTime;
        }

        playerRigidbody.MovePosition(playerRigidbody.position + movement);
    }

    private void HandleRotation() {
        if(Input.GetKey(KeyCode.A)){
            playerTransform.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.D)){
            playerTransform.Rotate(0, ro_speed * Time.deltaTime, 0);
        }
    }
}
