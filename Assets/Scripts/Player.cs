using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private bool isPressingUp = false;
    private bool isPressingDown = false;
    private bool isPressingLeft = false;
    private bool isPressingRight = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        SetAnimation();

    }

    void SetAnimation()
    {
        isPressingUp = Input.GetKeyDown(KeyCode.W);
        isPressingDown = Input.GetKeyDown(KeyCode.S);
        isPressingLeft = Input.GetKeyDown(KeyCode.A);
        isPressingRight = Input.GetKeyDown(KeyCode.D);

        animator.SetBool("isFacingUp", isPressingUp);
        animator.SetBool("isFacingDown", isPressingDown);
        animator.SetBool("isFacingLeft", isPressingLeft);
        animator.SetBool("isFacingRight", isPressingRight);
    }
    
}
