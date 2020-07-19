using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isPressingUp = false;
    private bool isPressingDown = false;
    private bool isPressingLeft = false;
    private bool isPressingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimation();
    }

    void SetAnimation()
    {
        //lock anim only on game over screen
        if (FindObjectOfType<Player>().currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            return;
        }
        else
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
}
