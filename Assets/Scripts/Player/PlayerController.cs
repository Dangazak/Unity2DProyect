using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const string JUMPING = "Jumping";
    const string GROUNDED = "Grounded";
    [SerializeField] float maxJumpTime, jumpSpeed, groundCheckDistance, baseAnimationSpeed;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D charRigidbody;
    [SerializeField] LayerMask layerMask;
    float jumpTime;
    bool grounded, jumpLocked, touchInput;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
        animator.speed = baseAnimationSpeed;
    }
    void Update()
    {
        GroundedCheck();
        if (!jumpLocked && Input.GetKey(KeyCode.Space))
        {
            Jumping();
        }
        else if (!jumpLocked && Input.touchCount > 0)
        {
            Jumping();
            touchInput = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space) || (Input.touchCount == 0 && touchInput))
        {
            jumpLocked = true;
            touchInput = false;
        }
        if (charRigidbody.velocity.y <= 0)
            animator.SetBool(JUMPING, false);
    }
    void Jumping()
    {
        animator.speed = 1;
        animator.SetBool(JUMPING, true);
        jumpTime += Time.deltaTime;
        if (jumpTime < maxJumpTime)
            charRigidbody.velocity = new Vector2(0, jumpSpeed);
    }
    void GroundedCheck()
    {
        if (Physics2D.Raycast(transform.position, -transform.up, groundCheckDistance, layerMask))
        {
            jumpTime = 0;
            grounded = true;
            jumpLocked = false;
            animator.speed = baseAnimationSpeed;
            animator.SetBool(GROUNDED, true);
            return;
        }
        animator.speed = 1;
        animator.SetBool(GROUNDED, false);
        grounded = false;
    }
}
